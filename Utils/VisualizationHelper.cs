using System;
using System.Threading;  // Necesario para usar Thread.Sleep() que pausa la ejecución

namespace MetodosAlgoritmicosyBusqueda
{
    /// <summary>
    /// VISUALIZATION HELPER (Ayudante de Visualización)
    /// 
    /// Esta clase ayuda a mostrar los algoritmos paso a paso de forma visual.
    /// Es como tener un "profesor" que va explicando y mostrando cada paso
    /// con pausas y colores para que sea más fácil de entender.
    /// 
    /// Funcionalidades:
    /// - Muestra el estado del arreglo en cada paso
    /// - Resalta elementos que se están comparando
    /// - Usa colores para indicar si se va a intercambiar o no
    /// - Permite ajustar la velocidad de las animaciones
    /// </summary>
    public class VisualizationHelper
    {
        // PROPIEDADES ESTÁTICAS (compartidas por toda la aplicación)
        
        /// <summary>
        /// Indica si el modo paso a paso está activado
        /// "static" significa que es una variable compartida, no hay una copia por objeto
        /// "bool" solo puede ser true (sí) o false (no)
        /// Por defecto es false (desactivado)
        /// </summary>
        public static bool ShowStepByStep { get; set; } = false;

        /// <summary>
        /// Tiempo de espera en milisegundos entre cada paso
        /// "Ms" significa milisegundos (1 segundo = 1000 milisegundos)
        /// 500ms = medio segundo de pausa entre cada paso
        /// </summary>
        public static int DelayMs { get; set; } = 500;

        /// <summary>
        /// Muestra el estado actual del arreglo con elementos resaltados
        /// 
        /// ¿Qué hace este método?
        /// Imprime el arreglo completo, pero resalta en AMARILLO los elementos
        /// que se están procesando en ese momento.
        /// </summary>
        /// <param name="arr">El arreglo a mostrar</param>
        /// <param name="message">Mensaje descriptivo de qué está pasando</param>
        /// <param name="highlightIndex1">Posición del primer elemento a resaltar (-1 si no hay)</param>
        /// <param name="highlightIndex2">Posición del segundo elemento a resaltar (-1 si no hay)</param>
        public static void ShowStep(int[] arr, string message, int highlightIndex1 = -1, int highlightIndex2 = -1)
        {
            // Si el modo paso a paso no está activado, no hacemos nada
            // "return" termina la ejecución del método inmediatamente
            if (!ShowStepByStep) return;

            // Imprimimos el mensaje descriptivo
            Console.Write($"{message}: ");

            // Recorremos todos los elementos del arreglo
            for (int i = 0; i < arr.Length; i++)
            {
                // ¿Este elemento es uno de los que debemos resaltar?
                if (i == highlightIndex1 || i == highlightIndex2)
                {
                    // Cambiamos el color del texto a AMARILLO
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    
                    // Imprimimos el elemento entre corchetes para destacarlo más
                    // Ejemplo: [5] en lugar de solo 5
                    Console.Write($"[{arr[i]}] ");
                    
                    // Volvemos al color normal
                    Console.ResetColor();
                }
                else
                {
                    // Elemento normal, sin resaltar
                    Console.Write($"{arr[i]} ");
                }
            }
            
            // Hacemos un salto de línea al final
            Console.WriteLine();
            
            // PAUSA: Esperamos un tiempo antes de continuar
            // Esto permite que el usuario vea este paso antes de que aparezca el siguiente
            // Thread.Sleep() detiene la ejecución por la cantidad de milisegundos indicada
            Thread.Sleep(DelayMs);
        }

        /// <summary>
        /// Muestra el resultado de una comparación con colores
        /// 
        /// ¿Qué hace este método?
        /// Cuando se comparan dos números, muestra si se van a intercambiar o no:
        /// - ROJO: Sí se van a intercambiar (están en orden incorrecto)
        /// - VERDE: No se intercambiarán (ya están en orden correcto)
        /// </summary>
        /// <param name="val1">Primer valor a comparar</param>
        /// <param name="val2">Segundo valor a comparar</param>
        /// <param name="willSwap">true si se van a intercambiar, false si no</param>
        public static void ShowComparison(int val1, int val2, bool willSwap)
        {
            // Si el modo paso a paso no está activado, no hacemos nada
            if (!ShowStepByStep) return;

            // Elegimos el color según si se van a intercambiar o no
            // Operador ternario: condición ? valor_si_true : valor_si_false
            // Si willSwap es true → Rojo, si es false → Verde
            Console.ForegroundColor = willSwap ? ConsoleColor.Red : ConsoleColor.Green;
            
            // Mostramos el mensaje con el color elegido
            // También usamos operador ternario para el texto final
            Console.WriteLine($"  → Comparando {val1} y {val2} → {(willSwap ? "Intercambiar" : "No intercambiar")}");
            
            // Volvemos al color normal
            Console.ResetColor();
        }

        /// <summary>
        /// Pregunta al usuario si quiere activar el modo paso a paso
        /// y a qué velocidad
        /// 
        /// ¿Qué hace este método?
        /// Antes de ejecutar un algoritmo, pregunta al usuario:
        /// 1. ¿Quieres verlo paso a paso?
        /// 2. Si responde que sí, ¿a qué velocidad? (rápido, normal o lento)
        /// </summary>
        public static void AskForStepByStepMode()
        {
            // Preguntamos al usuario
            Console.Write("\n¿Deseas ver la ejecución paso a paso? (s/n): ");
            
            // Leemos la respuesta y la convertimos a minúsculas
            // El "?" es un operador de null-safety que evita errores si ReadLine() es null
            var response = Console.ReadLine()?.ToLower();
            
            // Activamos el modo paso a paso si respondió "s", "si" o "sí"
            // El || es el operador OR (o): se cumple si cualquiera de las condiciones es verdadera
            ShowStepByStep = response == "s" || response == "si" || response == "sí";

            // Si el usuario activó el modo paso a paso
            if (ShowStepByStep)
            {
                // Preguntamos por la velocidad
                Console.Write("¿Qué velocidad prefieres? (1=Rápido 300ms, 2=Normal 800ms, 3=Lento 1500ms): ");
                var speed = Console.ReadLine();
                
                // "switch expression" - es una forma moderna de hacer muchas comparaciones
                // Dependiendo de la respuesta, asignamos diferentes valores a DelayMs
                DelayMs = speed switch
                {
                    "1" => 300,    // Rápido: 300 milisegundos (0.3 segundos)
                    "3" => 1500,   // Lento: 1500 milisegundos (1.5 segundos)
                    _ => 800       // Por defecto (cualquier otra respuesta): 800ms (0.8 segundos)
                };
                // El "_" es el caso por defecto, como "default" en un switch normal
            }
        }
        
        // ================================================================================================
        // MÉTODO WAITFORUSER - Espera a que el usuario presione Enter
        // ================================================================================================
        // Este método pausa la ejecución hasta que el usuario presione Enter.
        // Es útil para el modo paso a paso donde queremos que el usuario vea cada paso.
        public static void WaitForUser()
        {
            if (ShowStepByStep)
            {
                Console.WriteLine("\n[Presiona Enter para continuar...]");
                Console.ReadLine();
            }
        }
    }
}
