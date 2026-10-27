using System;
using System.Collections.Generic;
using System.Drawing;

namespace Deber3.Figuras
{
    public enum Orientacion { Antihorario, Horario, Colineal }

    // Punto y vector 2D: contiene solo las operaciones usadas por las figuras.
    public struct Vector2D
    {
        public const double Eps = 1e-9;
        public readonly double X, Y;
        public Vector2D(double x, double y)
        {
            if (double.IsNaN(x) || double.IsNaN(y) || double.IsInfinity(x) || double.IsInfinity(y))
                throw new ArgumentException("Coordenadas no validas.");
            X = x; Y = y;
        }
        public double Magnitud { get { return Math.Sqrt(X * X + Y * Y); } }
        public double Direccion { get { return Math.Atan2(Y, X) * 180 / Math.PI; } }

        //  Formula de polar, producto punto, determinante, distancia 
        public static Vector2D Polar(double radio, double angulo) {
            return new Vector2D(radio * Math.Cos(angulo), radio * Math.Sin(angulo)); }
        public static double Punto(Vector2D a, Vector2D b) { 
            return a.X * b.X + a.Y * b.Y; }
        public static double Determinante(Vector2D a, Vector2D b) {
            return a.X * b.Y - a.Y * b.X; }
        public static double Distancia(Vector2D a, Vector2D b) {
            return (a - b).Magnitud; }
        public bool IgualA(Vector2D otro, double tolerancia = 1e-6) { 
            return Math.Abs(X - otro.X) < tolerancia && Math.Abs(Y - otro.Y) < tolerancia; }


        //Sobrecarga de operadores se utiliza para simplificar las operaciones vectoriales
        public static Vector2D operator +(Vector2D a, Vector2D b) {
            return new Vector2D(a.X + b.X, a.Y + b.Y); }
        public static Vector2D operator -(Vector2D a, Vector2D b) { return new Vector2D(a.X - b.X, a.Y - b.Y); }
        public static Vector2D operator *(double n, Vector2D v) { return new Vector2D(n * v.X, n * v.Y); }
        public override string ToString() { return string.Format("({0:0.##}, {1:0.##})", X, Y); }
    }

    // Matriz 3x3 afin: se guardan solo sus seis valores variables.




    //Transformaciones Afines en 2D mediante Coordenadas Homogéneas
    public class Matriz3x3
    {
        readonly double a, b, c, d, x, y;


        //Transformaciones basicas de traslacion, rotacion y escalamiento
        Matriz3x3(double a, double b, double c, double d, double x, double y)
        {
            foreach (double valor in new[] { a, b, c, d, x, y })
                if (double.IsNaN(valor) || double.IsInfinity(valor))
                    throw new ArgumentException("La matriz necesita valores finitos.");
            this.a = a; this.b = b; this.c = c; this.d = d; this.x = x; this.y = y;
        }
        public static Matriz3x3 Traslacion(double x, double y) { return new Matriz3x3(1, 0, 0, 1, x, y); }
        public static Matriz3x3 Rotacion(double grados)
        {
            double r = grados * Math.PI / 180;
            return new Matriz3x3(Math.Cos(r), -Math.Sin(r), Math.Sin(r), Math.Cos(r), 0, 0);
        }
        public static Matriz3x3 Escalamiento(double x, double y)
        {
            if (x == 0 || y == 0) throw new ArgumentException("La escala no puede ser cero.");
            return new Matriz3x3(x, 0, 0, y, 0, 0);
        }
        // Sobrecarga de operador para multiplicar matrices 3x3
        public static Matriz3x3 operator *(Matriz3x3 m, Matriz3x3 n)
        {
            return new Matriz3x3(m.a * n.a + m.b * n.c, m.a * n.b + m.b * n.d,
                m.c * n.a + m.d * n.c, m.c * n.b + m.d * n.d,
                m.a * n.x + m.b * n.y + m.x, m.c * n.x + m.d * n.y + m.y);
        }
        public Vector2D Transformar(Vector2D p) { return new Vector2D(a * p.X + b * p.Y + x, c * p.X + d * p.Y + y); }
    }

    public class Parte { public Vector2D[] Vertices; public Color Color; }

    // Base comun de las tres figuras y de sus calculos geometricos.
    public abstract class Figura
    {
        protected List<Parte> partes = new List<Parte>();
        protected Vector2D[] contorno = new Vector2D[0];
        double x, y, angulo, escala = 1;


        // Propiedades y metodos publicos para acceder a la figura y sus transformaciones
        public double X { get { return x; } set { Validar(value); x = value; } }
        public double Y { get { return y; } set { Validar(value); y = value; } }
        public double AnguloGrados { get { return angulo; } set { Validar(value); angulo = value; } }
        public double Escala { get { return escala; } set { Validar(value); if (value <= 0) throw new ArgumentException("La escala debe ser positiva."); escala = value; } }
        public int NumeroPartes { get { return partes.Count; } }
        Matriz3x3 Matriz { get { return Matriz3x3.Traslacion(x, y) * Matriz3x3.Rotacion(angulo) * Matriz3x3.Escalamiento(escala, escala); } }

        // Metodos publicos para acceder a los vertices y colores de las partes, y al contorno de la figura
        public Color ColorParte(int i) { return partes[i].Color; }
        public void CambiarColor(int i, Color color) { partes[i].Color = color; }
        public Vector2D[] Contorno() { return Transformar(contorno); }
        public List<Parte> Partes()
        {
            var resultado = new List<Parte>();
            foreach (Parte p in partes) resultado.Add(new Parte { Color = p.Color, Vertices = Transformar(p.Vertices) });
            return resultado;
        }
        public bool Contiene(Vector2D punto)
        {
            foreach (Parte p in Partes()) if (Dentro(p.Vertices, punto)) return true;
            return false;
        }

        // Operaciones requeridas para las figuras y el analisis del clic.
        public static double Area(Vector2D[] p)
        {
            ValidarPoligono(p); double suma = 0;
            for (int i = 0; i < p.Length; i++) suma += Vector2D.Determinante(p[i], p[(i + 1) % p.Length]);
            return Math.Abs(suma) / 2;
        }
        public static double Perimetro(Vector2D[] p)
        {
            ValidarPoligono(p); double suma = 0;
            for (int i = 0; i < p.Length; i++) suma += Vector2D.Distancia(p[i], p[(i + 1) % p.Length]);
            return suma;
        }
        public static Orientacion OrientacionPunto(Vector2D a, Vector2D b, Vector2D p)
        {
            double d = Vector2D.Determinante(b - a, p - a);
            return Math.Abs(d) < Vector2D.Eps ? Orientacion.Colineal : d > 0 ? Orientacion.Antihorario : Orientacion.Horario;
        }
        public static Vector2D PuntoMasCercano(Vector2D a, Vector2D b, Vector2D p)
        {
            Vector2D lado = b - a; double largo2 = Vector2D.Punto(lado, lado);
            if (largo2 == 0) return a;
            double t = Math.Max(0, Math.Min(1, Vector2D.Punto(p - a, lado) / largo2));
            return a + t * lado;
        }
        // Reconstruye la figura manteniendo los colores de las partes
        protected void Reconstruir()
        {
            var colores = new List<Color>(); foreach (Parte p in partes) colores.Add(p.Color);
            partes.Clear(); Construir();
            for (int i = 0; i < colores.Count && i < partes.Count; i++) partes[i].Color = colores[i];
        }
        // Metodo abstracto que cada figura concreta debe implementar para construir sus partes y contorno
        protected abstract void Construir();
        protected static readonly Color[] Paleta = { Color.Red, Color.Orange, Color.Gold, Color.ForestGreen, Color.DeepSkyBlue, Color.MediumPurple };
        // Agrega una parte a la figura con los vertices y color especificados
        protected void Agregar(Vector2D[] vertices, int color) { partes.Add(new Parte { Vertices = vertices, Color = Paleta[color % Paleta.Length] }); }
        protected static Vector2D[] PoligonoRegular(int lados, double radio, double angulo, Vector2D centro)
        {
            var puntos = new Vector2D[lados];
            for (int i = 0; i < lados; i++) puntos[i] = centro + Vector2D.Polar(radio, angulo + 2 * Math.PI * i / lados);
            return puntos;
        }
        public abstract string Describir();
        // Metodo abstracto que cada figura concreta debe implementar para describir sus partes y contorno
        Vector2D[] Transformar(Vector2D[] puntos)
        {
            var resultado = new Vector2D[puntos.Length]; var matriz = Matriz;
            for (int i = 0; i < puntos.Length; i++) resultado[i] = matriz.Transformar(puntos[i]);
            return resultado;
        }
        // Metodo que determina si un punto esta dentro de un poligono, incluyendo sus vertices y lados
        static bool Dentro(Vector2D[] p, Vector2D punto)
        {
            bool dentro = false; ValidarPoligono(p);
            for (int i = 0, j = p.Length - 1; i < p.Length; j = i++)
            {
                if (Vector2D.Distancia(punto, PuntoMasCercano(p[j], p[i], punto)) < 1e-7) return true;
                if ((p[i].Y > punto.Y) != (p[j].Y > punto.Y) && punto.X < (p[j].X - p[i].X) * (punto.Y - p[i].Y) / (p[j].Y - p[i].Y) + p[i].X) dentro = !dentro;
            }
            return dentro;
        }
        protected static void Validar(double valor) { if (double.IsNaN(valor) || double.IsInfinity(valor)) throw new ArgumentException("Valor no valido."); }
        static void ValidarPoligono(Vector2D[] p) { if (p == null || p.Length < 3) throw new ArgumentException("Un poligono necesita 3 vertices."); }
    }
}
