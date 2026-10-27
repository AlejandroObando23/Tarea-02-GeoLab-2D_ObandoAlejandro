# Revisión de requisitos

La versión conserva todos los archivos fuente del ZIP original, sus nombres de
formulario y el menú con sus tres opciones. Se añadieron los cálculos y controles
necesarios para la tarea. Las opciones adicionales se pueden plegar.

| Criterio | Implementación y comprobación |
| --- | --- |
| Hexágono de seis colores | Seis vértices calculados con seno y coseno, lado configurable y seis triángulos equiláteros con colores distintos. |
| Flor de margarita | Cinco pentágonos regulares separados por giros de 72°. Se conserva el detalle central. El área y el perímetro corresponden a la silueta completa, sin contar dos veces las superposiciones. |
| Polígono estrellado | N puntas configurables, radios exterior e interior y colores por sector. El radio interior se limita para mantener la forma de estrella. |
| Construcción matemática | Los vértices dependen de dimensiones y ángulos; no hay listas de coordenadas de dibujo fijas. |
| Vectores | Magnitud, dirección, producto punto y determinante en `Vector2D`. El análisis del clic muestra sus resultados. |
| Geometría | Área, perímetro, tres orientaciones y pertenencia con inclusión de los bordes. |
| Proyecciones | Punto más cercano al segmento rojo, con proyección limitada a sus extremos; incluye segmentos de longitud cero. |
| Transformaciones | Matrices afines homogéneas 3 × 3, almacenadas con sus seis coeficientes variables. Composición T × R × S: escala, rotación y traslación. |
| Interactividad | Dimensiones, puntas y colores en la vista básica; posición, ángulo, escala y análisis completo en «Más opciones». |
| Validación por pruebas | 32 casos matemáticos incluidos y accesibles desde el menú Pruebas o F5. |
| Plataforma | Proyecto C# para .NET Framework 4.7.2 y Windows Forms. |
| Gráficos | Uso de `Graphics`, `Pen`, `SolidBrush` y `PointF`; los recursos creados se liberan con `using`. |
| Lienzo mínimo | Área de dibujo real de 800 × 600 píxeles. Las ventanas pequeñas usan desplazamiento y conservan ese tamaño. |
| Separación y POO | `Figura`, `Hexagono`, `Margarita` y `PoligonoEstrellado` contienen la geometría; los formularios contienen controles y dibujo. |
| Manejo de errores | Límites en entradas numéricas, rechazo de dimensiones y escalas inválidas, validación de valores finitos y mensajes de error. Cada prueba registra sus fallos y permite continuar con las demás. |

En esta implementación, N es el número de puntas de la estrella: su contorno
alterna N vértices exteriores y N interiores, para un total de 2N vértices.

## Verificación realizada

El proyecto compiló en Release con Mono. Pasaron los 32 casos matemáticos y
87 comprobaciones en total al incluir la interfaz: despliegue de opciones,
cambios de tamaño y transformaciones, ajuste de puntas, conservación de valores,
menú original, apertura MDI y lienzo de 800 × 600 incluso al reducir ventanas.
También se revisaron las vistas generadas de las tres figuras.

La ejecución nativa en Windows y el diseñador de Visual Studio no se verificaron
en este equipo Linux. La herramienta de compilación Mono advirtió que su
toolset antiguo no declara soporte para v4.7.2; la compilación terminó sin errores.
