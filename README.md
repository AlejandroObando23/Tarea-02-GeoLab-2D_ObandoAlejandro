Deber 3: Figuras geométricas 2D en C#

Autor: Alejandro Obando Universidad de las Fuerzas Armadas "ESPE"

Aplicación de escritorio (Windows Forms, .NET Framework 4.7.2) que dibuja y analiza tres figuras geométricas en 2D:

Hexágono de seis colores (seis triángulos equiláteros).
Margarita: cinco pétalos pentagonales girados 72° entre sí, con un círculo central.
Polígono estrellado de N puntas, con radio exterior y radio interior configurables.

Todos los vértices se calculan con seno y coseno; no hay coordenadas escritas a mano.

Qué hace
Dibuja cada figura en un lienzo de 800 × 600 con el origen en el centro (eje Y hacia arriba, ángulos antihorarios).
Permite cambiar el tamaño (lado, número de puntas o radio), la posición X e Y, el ángulo y la escala.
Permite elegir el color de cada parte de la figura.
Muestra el área y el perímetro de la figura.
Al hacer clic en el lienzo analiza el punto: magnitud y dirección de los vectores, producto punto, determinante, orientación respecto a un segmento, punto más cercano del contorno y si el punto está dentro o fuera.
Valida los datos: valores no válidos (lado o escala menores o iguales a cero, NaN, estrella con N < 3, radio interior fuera de rango) lanzan ArgumentException y el formulario muestra el mensaje.
Estructura
Deber3/
├── MenuDeb3.cs                  Ventana principal con el menú
├── Hexagonofrm.cs               Formulario del hexágono
├── MargaritaFrm.cs              Formulario de la margarita
├── Poli_estrelladoFrm.cs        Formulario del polígono estrellado
└── Figuras/
    ├── Figura.cs                Vector2D, Matriz3x3 y la clase base Figura
    ├── Hexagono.cs
    ├── Margarita.cs
    └── PoligonoEstrellado.cs
Pruebas.cs                       Programa de pruebas de las clases de Figuras/

Hexagono, Margarita y PoligonoEstrellado heredan de Figura. Los formularios solo dibujan y recogen datos; la geometría está en las clases de Figuras/.

Fórmulas principales
Qué	Fórmula
Punto desde radio y ángulo	(r·cos θ , r·sin θ)
Área de un polígono	½ · |Σ det(Pi, Pi+1)|
Orientación de P respecto a A→B	d = det(B − A, P − A)
Punto más cercano en AB	t = ((P−A)·(B−A)) / |B−A|² (0 ≤ t ≤ 1), Q = A + t·(B−A)
Transformación de cada figura	M = T · R · S (traslación, rotación, escala)
Hexágono	Área = (3√3/2)·L², Perímetro = 6·L
Pétalo de la margarita	R = L / (2·sin 36°)
Estrella	Área = N·R·r·sin(180°/N), con 0 < razón < cos(180°/N)

El detalle de cada fórmula, qué hace y para qué se usa está en el informe técnico.

Cómo ejecutarlo

Requisitos: Windows y Visual Studio con soporte para .NET Framework 4.7.2.

Abrir Deber3.slnx (o el proyecto Deber3/Deber3.csproj) en Visual Studio.
Compilar y ejecutar (F5).
En el menú elegir Hexagono, Margarita o Poligonos_estrellados.
Pruebas

Pruebas.cs es un programa de consola aparte que usa las clases reales de Figuras/ y compara sus resultados con valores calculados a mano (hexágono, pétalos de la margarita, estrella, vectores, matrices y errores). No prueba los formularios.

Para ejecutarlo con Mono, desde la carpeta Deber3/:

mcs -out:Pruebas.exe -r:System.Drawing ../Pruebas.cs Figuras/Figura.cs Figuras/Hexagono.cs Figuras/Margarita.cs Figuras/PoligonoEstrellado.cs
mono Pruebas.exe

Resultado obtenido: 117 de 117 pruebas correctas (hexágono 26, margarita 39, estrella 36, vectores y geometría 16).

El elemento de menú "Pruebas" de la aplicación no está conectado a este programa.