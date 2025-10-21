// ========================================================================================================
// HEAPSORT - Algoritmo de Ordenamiento Basado en Heap (Montículo)
// ========================================================================================================
// Heapsort es un algoritmo que usa una estructura de datos llamada "heap" o "montículo".
// Un heap es como un árbol donde el elemento más grande siempre está en la raíz (arriba).
//
// ANALOGÍA: Imagina una pirámide de números donde cada "padre" siempre es mayor que sus "hijos".
// El número más grande está en la cima. Tomamos ese número, lo ponemos al final, y reorganizamos
// la pirámide. Repetimos hasta que todos los números estén ordenados.
//
// COMPLEJIDAD: O(n log n) en todos los casos (mejor, promedio y peor)
// VENTAJAS: 
// - Siempre tarda lo mismo, no depende del orden inicial
// - No necesita memoria extra (ordena en el mismo arreglo)
// DESVENTAJAS:
// - Más difícil de entender que otros algoritmos
// - En la práctica, suele ser más lento que QuickSort

using System;

namespace MetodosAlgoritmicosyBusqueda
{
    // Esta clase implementa la interfaz ISorter
    public class HeapSorter : ISorter
    {
        // Propiedad Name - Devuelve el nombre del algoritmo para mostrarlo en el menú
        public string Name => "Heapsort (Ordenamiento por Montículo)";

        // Contadores para estadísticas (para fines educativos)
        private int comparisons = 0;
        private int swaps = 0;

        // ================================================================================================
        // MÉTODO PRINCIPAL SORT - Ordena el arreglo usando Heapsort
        // ================================================================================================
        public void Sort(int[] arr)
        {
            // Reiniciar contadores
            comparisons = 0;
            swaps = 0;

            int n = arr.Length;

            // ========================================================================================
            // FASE 1: CONSTRUIR EL MAX-HEAP
            // ========================================================================================
            // Un Max-Heap es una estructura donde cada padre es mayor que sus hijos.
            // Empezamos desde el último padre (n/2 - 1) y vamos hacia atrás,
            // "hundiendo" cada elemento para que esté en su posición correcta en el heap.
            //
            // ¿Por qué empezar desde n/2 - 1?
            // Porque los elementos después de n/2 son "hojas" (no tienen hijos),
            // así que ya están en posición correcta como heaps de un solo elemento.

            Console.WriteLine("\n--- FASE 1: Construyendo Max-Heap ---");
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            if (VisualizationHelper.ShowStepByStep)
            {
                Console.WriteLine("\nMax-Heap construido:");
                ArrayPrinter.Print(arr);
                Console.WriteLine("(El elemento más grande está ahora en la posición 0)");
                VisualizationHelper.WaitForUser();
            }

            // ========================================================================================
            // FASE 2: EXTRAER ELEMENTOS DEL HEAP UNO POR UNO
            // ========================================================================================
            // El elemento en la raíz (posición 0) es siempre el más grande.
            // Lo intercambiamos con el último elemento y reducimos el tamaño del heap.
            // Luego reorganizamos el heap para que el siguiente elemento más grande suba a la raíz.
            // Repetimos hasta que el heap tenga tamaño 1.

            Console.WriteLine("\n--- FASE 2: Extrayendo elementos y ordenando ---");
            for (int i = n - 1; i > 0; i--)
            {
                // Mover la raíz actual (máximo) al final
                Swap(arr, 0, i);
                swaps++;

                if (VisualizationHelper.ShowStepByStep)
                {
                    VisualizationHelper.ShowStep(arr, 
                        $"Intercambiando el máximo ({arr[i]}) al final. Ahora reorganizamos el heap.", 0, i);
                }

                // Llamar a heapify en el heap reducido
                // El heap ahora tiene tamaño i (excluimos el elemento que ya ordenamos)
                Heapify(arr, i, 0);
            }

            // Mostrar estadísticas finales
            Console.WriteLine($"\n📊 Estadísticas de Heapsort:");
            Console.WriteLine($"   Comparaciones: {comparisons}");
            Console.WriteLine($"   Intercambios: {swaps}");
        }

        // ================================================================================================
        // MÉTODO HEAPIFY - Reorganiza un subárbol para mantener la propiedad de Max-Heap
        // ================================================================================================
        // Este método "hunde" un elemento hacia abajo en el heap hasta que esté en la posición correcta.
        //
        // Parámetros:
        // - arr: el arreglo
        // - n: tamaño del heap (puede ser menor que arr.Length)
        // - i: índice del elemento que queremos hundir
        //
        // PROPIEDAD DE MAX-HEAP: Para cualquier nodo i:
        // - Hijo izquierdo está en 2*i + 1
        // - Hijo derecho está en 2*i + 2
        // - El padre debe ser mayor que ambos hijos
        private void Heapify(int[] arr, int n, int i)
        {
            int largest = i;           // Asumimos que el padre es el más grande
            int left = 2 * i + 1;      // Índice del hijo izquierdo
            int right = 2 * i + 2;     // Índice del hijo derecho

            // Si el hijo izquierdo existe Y es mayor que el padre
            if (left < n)
            {
                comparisons++;
                if (arr[left] > arr[largest])
                {
                    largest = left;
                }
            }

            // Si el hijo derecho existe Y es mayor que el más grande hasta ahora
            if (right < n)
            {
                comparisons++;
                if (arr[right] > arr[largest])
                {
                    largest = right;
                }
            }

            // Si el más grande no es el padre, intercambiar y seguir hundiendo
            if (largest != i)
            {
                Swap(arr, i, largest);
                swaps++;

                // Recursivamente hundir el elemento en su nueva posición
                // Esto asegura que todo el subárbol mantenga la propiedad de max-heap
                Heapify(arr, n, largest);
            }
        }

        // ================================================================================================
        // MÉTODO SWAP - Intercambia dos elementos en el arreglo
        // ================================================================================================
        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
