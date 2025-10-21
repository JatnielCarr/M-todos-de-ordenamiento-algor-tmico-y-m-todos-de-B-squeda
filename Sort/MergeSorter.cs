// ========================================================================================================
// MERGESORT - Algoritmo de Ordenamiento por Mezcla (Divide y Conquista)
// ========================================================================================================
// MergeSort es un algoritmo que divide el arreglo en mitades, ordena cada mitad,
// y luego las mezcla de manera ordenada.
//
// ANALOGÍA: Imagina que tienes un mazo de cartas desordenado.
// 1. Divides el mazo en dos montones
// 2. Divides cada montón en dos más (y así sucesivamente hasta tener cartas individuales)
// 3. Empiezas a mezclar las cartas de dos en dos, siempre manteniendo el orden
// 4. Al final, todo el mazo queda ordenado
//
// COMPLEJIDAD: O(n log n) en todos los casos (mejor, promedio y peor)
// VENTAJAS:
// - Siempre tarda lo mismo, muy predecible
// - Es "estable": mantiene el orden relativo de elementos iguales
// - Excelente para ordenar listas enlazadas
// DESVENTAJAS:
// - Necesita memoria extra (O(n)) para los arreglos temporales
// - Más lento que QuickSort en la práctica para arreglos pequeños

using System;

namespace MetodosAlgoritmicosyBusqueda
{
    // Esta clase implementa la interfaz ISorter
    public class MergeSorter : ISorter
    {
        // Propiedad Name - Devuelve el nombre del algoritmo para mostrarlo en el menú
        public string Name => "MergeSort (Ordenamiento por Mezcla)";

        // Contadores para estadísticas (para fines educativos)
        private int comparisons = 0;
        private int merges = 0;

        // ================================================================================================
        // MÉTODO PRINCIPAL SORT - Ordena el arreglo usando MergeSort
        // ================================================================================================
        public void Sort(int[] arr)
        {
            // Reiniciar contadores
            comparisons = 0;
            merges = 0;

            Console.WriteLine("\n--- Iniciando MergeSort ---");
            Console.WriteLine("Este algoritmo divide el arreglo recursivamente hasta tener elementos individuales,");
            Console.WriteLine("luego los mezcla de forma ordenada.");

            // Llamar al método recursivo que hace el trabajo real
            // Parámetros: el arreglo, índice inicial (0), índice final (longitud - 1)
            MergeSort(arr, 0, arr.Length - 1);

            // Mostrar estadísticas finales
            Console.WriteLine($"\n📊 Estadísticas de MergeSort:");
            Console.WriteLine($"   Comparaciones: {comparisons}");
            Console.WriteLine($"   Mezclas realizadas: {merges}");
        }

        // ================================================================================================
        // MÉTODO MERGESORT RECURSIVO - Divide el arreglo y ordena las partes
        // ================================================================================================
        // Este es el corazón del algoritmo. Usa RECURSIÓN (se llama a sí mismo).
        //
        // Parámetros:
        // - arr: el arreglo completo
        // - left: índice inicial del segmento que vamos a ordenar
        // - right: índice final del segmento que vamos a ordenar
        //
        // CASO BASE: Si left >= right, significa que tenemos 0 o 1 elementos, ya está "ordenado"
        // CASO RECURSIVO: Dividir en dos mitades, ordenar cada mitad, y mezclarlas
        private void MergeSort(int[] arr, int left, int right)
        {
            // CASO BASE: Si tenemos 1 o menos elementos, no hay nada que ordenar
            if (left >= right)
            {
                return;
            }

            // ========================================================================================
            // DIVIDIR: Encontrar el punto medio
            // ========================================================================================
            // El punto medio divide el segmento en dos partes aproximadamente iguales
            // Ejemplo: Si left=0 y right=7, entonces mid=3
            //          Primera mitad: [0, 1, 2, 3]
            //          Segunda mitad: [4, 5, 6, 7]
            int mid = left + (right - left) / 2;

            if (VisualizationHelper.ShowStepByStep)
            {
                Console.WriteLine($"\n🔪 Dividiendo segmento [{left}...{right}] en el punto medio {mid}");
                VisualizationHelper.WaitForUser();
            }

            // ========================================================================================
            // CONQUISTAR: Ordenar recursivamente cada mitad
            // ========================================================================================
            // Primera llamada recursiva: ordena la mitad izquierda
            MergeSort(arr, left, mid);
            
            // Segunda llamada recursiva: ordena la mitad derecha
            MergeSort(arr, mid + 1, right);

            // ========================================================================================
            // COMBINAR: Mezclar las dos mitades ordenadas
            // ========================================================================================
            Merge(arr, left, mid, right);
        }

        // ================================================================================================
        // MÉTODO MERGE - Mezcla dos segmentos ordenados en uno solo ordenado
        // ================================================================================================
        // Este método toma dos partes del arreglo que YA ESTÁN ORDENADAS
        // y las combina en una sola parte ordenada.
        //
        // Parámetros:
        // - arr: el arreglo completo
        // - left: inicio del primer segmento
        // - mid: fin del primer segmento (el segundo empieza en mid+1)
        // - right: fin del segundo segmento
        //
        // Ejemplo: Si tenemos [3, 8] y [1, 9], los mezclamos en [1, 3, 8, 9]
        private void Merge(int[] arr, int left, int mid, int right)
        {
            // ========================================================================================
            // CREAR ARREGLOS TEMPORALES
            // ========================================================================================
            // Necesitamos copiar los datos a arreglos temporales para poder compararlos
            // sin perder información al sobrescribir el arreglo original
            
            // Tamaño del segmento izquierdo
            int n1 = mid - left + 1;
            // Tamaño del segmento derecho
            int n2 = right - mid;

            // Crear arreglos temporales
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            // Copiar datos a los arreglos temporales
            for (int i = 0; i < n1; i++)
            {
                leftArray[i] = arr[left + i];
            }
            for (int j = 0; j < n2; j++)
            {
                rightArray[j] = arr[mid + 1 + j];
            }

            if (VisualizationHelper.ShowStepByStep)
            {
                Console.WriteLine($"\n🔀 Mezclando segmentos:");
                Console.Write("   Izquierda: ");
                ArrayPrinter.Print(leftArray);
                Console.Write("   Derecha: ");
                ArrayPrinter.Print(rightArray);
            }

            // ========================================================================================
            // MEZCLAR LOS ARREGLOS
            // ========================================================================================
            // Usamos tres índices:
            // - i: posición actual en leftArray
            // - j: posición actual en rightArray
            // - k: posición donde vamos a escribir en el arreglo original
            //
            // En cada paso, comparamos leftArray[i] con rightArray[j]
            // y ponemos el menor en arr[k]

            int iLeft = 0;      // Índice para leftArray
            int jRight = 0;     // Índice para rightArray
            int k = left;       // Índice para arr (empieza en 'left', no en 0)

            // Mientras tengamos elementos en AMBOS arreglos
            while (iLeft < n1 && jRight < n2)
            {
                comparisons++;

                // Comparar el elemento actual de cada arreglo
                if (leftArray[iLeft] <= rightArray[jRight])
                {
                    // El elemento de la izquierda es menor (o igual), lo tomamos
                    arr[k] = leftArray[iLeft];
                    iLeft++;
                }
                else
                {
                    // El elemento de la derecha es menor, lo tomamos
                    arr[k] = rightArray[jRight];
                    jRight++;
                }
                k++;
            }

            // ========================================================================================
            // COPIAR ELEMENTOS RESTANTES
            // ========================================================================================
            // Si quedaron elementos en leftArray (rightArray ya se acabó)
            while (iLeft < n1)
            {
                arr[k] = leftArray[iLeft];
                iLeft++;
                k++;
            }

            // Si quedaron elementos en rightArray (leftArray ya se acabó)
            while (jRight < n2)
            {
                arr[k] = rightArray[jRight];
                jRight++;
                k++;
            }

            merges++;

            // Mostrar el resultado de la mezcla
            if (VisualizationHelper.ShowStepByStep)
            {
                Console.Write("   Resultado: ");
                int[] segment = new int[right - left + 1];
                Array.Copy(arr, left, segment, 0, segment.Length);
                ArrayPrinter.Print(segment);
                VisualizationHelper.WaitForUser();
            }
        }
    }
}
