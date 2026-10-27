using System;

namespace Deber3.Figuras
{
    public class Hexagono : Figura
    {
        double lado;
        public Hexagono(double lado) { Lado = lado; }
        // Propiedad para acceder y modificar el lado del hexagono, validando que sea positivo y reconstruyendo la figura
        public double Lado
        {
            get { return lado; }
            set { Validar(value); if (value <= 0) throw new ArgumentException("El lado debe ser positivo."); lado = value; Reconstruir(); }
        }
        // Implementacion del metodo abstracto Construir para crear las partes y el contorno del hexagono
        protected override void Construir()
        {
            contorno = PoligonoRegular(6, lado, 0, new Vector2D(0, 0));
            for (int i = 0; i < 6; i++) Agregar(new[] { new Vector2D(0, 0), contorno[i], contorno[(i + 1) % 6] }, i);
        }
        // Implementacion del metodo abstracto Describir para devolver una cadena con la informacion del hexagono
        public override string Describir()
        {
            Vector2D[] p = Contorno();
            return string.Format("Hexagono\r\nLado: {0:0.##}\r\nArea: {1:0.00}\r\nPerimetro: {2:0.00}", lado * Escala, Area(p), Perimetro(p));
        }
    }
}
