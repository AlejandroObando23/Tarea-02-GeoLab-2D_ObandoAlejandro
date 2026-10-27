using System;

namespace Deber3.Figuras
{
    public class PoligonoEstrellado : Figura
    {
        int n;
        double radio, razon;
        public PoligonoEstrellado(int n, double radio, double razon) { Configurar(n, radio, razon); }
        // Metodo para configurar el poligono estrellado, validando los parametros y reconstruyendo la figura
        public void Configurar(int n, double radio, double razon)
        {
            Validar(radio); Validar(razon);
            if (n < 3 || radio <= 0 || razon <= 0 || razon >= Math.Cos(Math.PI / n))
                throw new ArgumentException("La estrella necesita al menos 3 puntas y un radio interior menor que la apotema exterior.");
            this.n = n; this.radio = radio; this.razon = razon; Reconstruir();
        }
        // Implementacion del metodo abstracto Construir para crear las partes y el contorno del poligono estrellado
        protected override void Construir()
        {
            contorno = new Vector2D[2 * n];
            for (int i = 0; i < n; i++)
            {
                double angulo = Math.PI / 2 + 2 * Math.PI * i / n;
                contorno[2 * i] = Vector2D.Polar(radio, angulo);
                contorno[2 * i + 1] = Vector2D.Polar(radio * razon, angulo + Math.PI / n);
            }
            for (int i = 0; i < n; i++)
                Agregar(new[] { new Vector2D(0, 0), contorno[(2 * i + 2 * n - 1) % (2 * n)], contorno[2 * i], contorno[2 * i + 1] }, i);
        }
        // Implementacion del metodo abstracto Describir para devolver una cadena con la informacion del poligono estrellado
        public override string Describir()
        {
            Vector2D[] p = Contorno();
            return string.Format("Estrella de {0} puntas\r\nRadio: {1:0.##}\r\nArea: {2:0.00}\r\nPerimetro: {3:0.00}", n, radio * Escala, Area(p), Perimetro(p));
        }
    }
}
