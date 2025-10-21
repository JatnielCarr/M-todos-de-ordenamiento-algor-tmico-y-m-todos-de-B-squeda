using System;

namespace MetodosAlgoritmicosyBusqueda
{
    /// <summary>
    /// BUBBLE SORT (Ordenamiento de Burbuja)
    /// 
    /// ¿Cómo funciona?
    /// Imagina que tienes números en una fila. Este algoritmo compara números vecinos (uno al lado del otro)
    /// y los intercambia si están en el orden incorrecto. Es como burbujas que suben a la superficie:
    /// los números más grandes "flotan" hacia el final del arreglo.
    /// 
    /// Ejemplo visual:
    /// Inicio:   [5, 2, 8, 1]
    /// Paso 1:   [2, 5, 8, 1]  (comparó 5 y 2, los intercambió)
    /// Paso 2:   [2, 5, 8, 1]  (comparó 5 y 8, no los intercambió porque ya están bien)
    /// Paso 3:   [2, 5, 1, 8]  (comparó 8 y 1, los intercambió - el 8 llegó al final)
    /// ...continúa hasta ordenar todo...
    /// 
    /// Esta clase implementa la interfaz ISorter (cumple el "contrato")
    /// </summary>
    public class BubbleSorter : ISorter
    {
        // Nombre del algoritmo que se mostrará en el menú
        public string Name => "Bubble Sort (Burbuja)";

        // Método principal que ordena el arreglo
        public void Sort(int[] arr)
        {
            // "n" guarda cuántos elementos tiene el arreglo
            // Ejemplo: si arr = [5, 2, 8], entonces n = 3
            var n = arr.Length;

            // Variables para llevar la cuenta de lo que hace el algoritmo
            int comparisons = 0;  // Cuántas veces comparamos dos números
            int swaps = 0;        // Cuántas veces intercambiamos números de posición

            // CICLO EXTERNO: Recorre el arreglo completo
            // "i" representa el número de pasada (primera pasada, segunda pasada, etc.)
            // Se repite "n - 1" veces porque en la última pasada ya estará ordenado
            for (int i = 0; i < n - 1; i++)
            {
                // Si el usuario eligió ver paso a paso, mostramos en qué pasada estamos
                if (VisualizationHelper.ShowStepByStep)
                {
                    Console.WriteLine($"\n--- Pasada {i + 1} ---");
                }

                // Variable para optimización: detecta si en esta pasada no hubo intercambios
                // Si no hubo intercambios, significa que ya está ordenado y podemos parar
                bool swapped = false;

                // CICLO INTERNO: Compara elementos vecinos
                // "j" es la posición actual que estamos comparando
                // "n - i - 1" porque los últimos "i" elementos ya están en su lugar
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Aumentamos el contador de comparaciones
                    comparisons++;

                    // Mostramos visualmente qué elementos estamos comparando (si está activado)
                    VisualizationHelper.ShowStep(arr, $"Comparando posiciones {j} y {j + 1}", j, j + 1);

                    // COMPARACIÓN PRINCIPAL: ¿El elemento actual es mayor que el siguiente?
                    // Si arr[j] > arr[j + 1], significa que están en orden incorrecto
                    if (arr[j] > arr[j + 1])
                    {
                        // Mostramos que SÍ vamos a intercambiar
                        VisualizationHelper.ShowComparison(arr[j], arr[j + 1], true);

                        // INTERCAMBIO: Cambiamos de lugar los dos números
                        // Ejemplo: si arr[j] = 5 y arr[j+1] = 2
                        // Después del intercambio: arr[j] = 2 y arr[j+1] = 5
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);

                        // Aumentamos contadores
                        swaps++;      // Contamos que hicimos un intercambio
                        swapped = true;  // Marcamos que hubo al menos un intercambio en esta pasada
                    }
                    else
                    {
                        // Los elementos ya están en orden correcto, no intercambiamos
                        VisualizationHelper.ShowComparison(arr[j], arr[j + 1], false);
                    }
                }

                // OPTIMIZACIÓN: Si en toda esta pasada no hubo intercambios,
                // significa que el arreglo ya está ordenado, podemos terminar
                if (!swapped && VisualizationHelper.ShowStepByStep)
                {
                    Console.WriteLine("  → No hubo intercambios, arreglo ordenado!");
                    break;  // "break" sale del ciclo for inmediatamente
                }
            }

            // Al final, mostramos las estadísticas de lo que hizo el algoritmo
            if (!VisualizationHelper.ShowStepByStep)
            {
                // Si no está en modo paso a paso, solo mostramos el resumen
                Console.WriteLine($"\nEstadísticas: {comparisons} comparaciones, {swaps} intercambios");
            }
            else
            {
                // Si estuvo en modo paso a paso, mostramos un mensaje de completado
                Console.WriteLine($"\n✓ Completado: {comparisons} comparaciones, {swaps} intercambios");
            }
        }
    }
}
