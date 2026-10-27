using System;

namespace Deber3.Figuras
{
    public class Margarita : Figura
    {
        double lado;
        public Margarita(double lado) { Lado = lado; }
        // Propiedad para acceder y modificar el lado de la margarita, validando que sea positivo y reconstruyendo la figura
        public double Lado
        {
            get { return lado; }
            set { Validar(value); if (value <= 0) throw new ArgumentException("El lado debe ser positivo."); lado = value; Reconstruir(); }
        }
        // Implementacion del metodo abstracto Construir para crear las partes y el contorno de la margarita    
        protected override void Construir()
        {
            double radio = lado / (2 * Math.Sin(Math.PI / 5));
            contorno = new Vector2D[15];
            for (int i = 0; i < 5; i++)
            {
                double angulo = Math.PI / 2 + 2 * Math.PI * i / 5;
                Vector2D[] petalo = PoligonoRegular(5, radio, angulo + Math.PI, Vector2D.Polar(radio, angulo));
                Agregar(petalo, i);
            }
            // Borde exterior: dos vertices de cada petalo y su cruce con el anterior.
            // Asi las zonas superpuestas no se cuentan dos veces en area y perimetro.
            for (int i = 0; i < 5; i++)
            {
                Vector2D[] actual = partes[i].Vertices;
                Vector2D[] anterior = partes[(i + 4) % 5].Vertices;
                Vector2D u = actual[2] - actual[1];
                Vector2D v = anterior[4] - anterior[3];
                double t = Vector2D.Determinante(anterior[3] - actual[1], v) / Vector2D.Determinante(u, v);
                contorno[3 * i] = actual[1] + t * u;
                contorno[3 * i + 1] = actual[2];
                contorno[3 * i + 2] = actual[3];
            }
            Agregar(PoligonoRegular(16, lado * .3, 0, new Vector2D(0, 0)), 2);
        }
        // Implementacion del metodo abstracto Describir para devolver una cadena con la informacion de la margarita
        public override string Describir()
        {
            Vector2D[] p = Contorno();
            return string.Format("Margarita (5 pentagonos)\r\nLado: {0:0.##}\r\nArea total: {1:0.00}\r\nPerimetro exterior: {2:0.00}", lado * Escala, Area(p), Perimetro(p));
        }
    }
}
