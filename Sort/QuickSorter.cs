using System;

namespace MetodosAlgoritmicosyBusqueda
{
    /// <summary>
    /// QUICKSORT (Ordenamiento Rápido)
    /// 
    /// ¿Cómo funciona?
    /// Este es uno de los algoritmos más rápidos. Usa la estrategia "divide y vencerás":
    /// 1. Elige un elemento "pivote" (generalmente el último)
    /// 2. Reorganiza el arreglo: elementos menores al pivote a la izquierda, mayores a la derecha
    /// 3. Repite el proceso para cada mitad recursivamente
    /// 
    /// Ejemplo visual:
    /// Inicio:           [5, 2, 8, 1, 9]
    ///                                ↑ pivote = 9
    /// 
    /// Paso 1: Particionar usando 9 como pivote
    ///                   [5, 2, 8, 1, 9]
    ///                   Todos son menores que 9, así que quedan a la izquierda
    ///                   [5, 2, 8, 1] [9] [ ]
    ///                    ↑menores↑   pivote  mayores
    /// 
    /// Paso 2: Particionar [5, 2, 8, 1] usando 1 como pivote
    ///                   [1] [5, 2, 8]
    ///                    ↑    ↑mayores
    ///                 pivote
    /// 
    /// Paso 3: Particionar [5, 2, 8] usando 8 como pivote
    ///                   [5, 2] [8]
    ///                   ↑menores pivote
    /// 
    /// ...y así sucesivamente hasta que todo está ordenado: [1, 2, 5, 8, 9]
    /// 
    /// Es "rápido" porque divide el problema en problemas más pequeños.
    /// </summary>
    public class QuickSorter : ISorter
    {
        // Nombre del algoritmo
        public string Name => "Quicksort";

        // Variables privadas para llevar el conteo de operaciones
        // "private" significa que solo esta clase puede acceder a ellas
        private int comparisons = 0;  // Cuántas comparaciones hacemos
        private int swaps = 0;        // Cuántos intercambios hacemos

        // Método público que se llama desde fuera para ordenar el arreglo
        public void Sort(int[] arr)
        {
            // Reiniciamos los contadores a cero al comenzar
            comparisons = 0;
            swaps = 0;

            // Llamamos al método recursivo Quicksort
            // Le pasamos el arreglo completo: desde posición 0 hasta la última posición
            Quicksort(arr, 0, arr.Length - 1);

            // Al terminar, mostramos las estadísticas
            if (!VisualizationHelper.ShowStepByStep)
            {
                Console.WriteLine($"\nEstadísticas: {comparisons} comparaciones, {swaps} intercambios");
            }
            else
            {
                Console.WriteLine($"\n✓ Completado: {comparisons} comparaciones, {swaps} intercambios");
            }
        }

        /// <summary>
        /// Método recursivo principal de Quicksort
        /// 
        /// ¿Qué es recursivo? Es un método que se llama a sí mismo.
        /// Es como una muñeca rusa: abres una y encuentras otra más pequeña dentro.
        /// 
        /// Parámetros:
        /// - arr: el arreglo completo
        /// - low: posición inicial del segmento que vamos a ordenar
        /// - high: posición final del segmento que vamos a ordenar
        /// </summary>
        void Quicksort(int[] arr, int low, int high)
        {
            // CASO BASE: Si low < high, significa que hay al menos 2 elementos para ordenar
            // Si low >= high, hay 0 o 1 elementos, lo cual ya está "ordenado"
            if (low < high)
            {
                // Mostramos qué rango estamos procesando
                if (VisualizationHelper.ShowStepByStep)
                {
                    Console.WriteLine($"\n--- Particionando rango [{low}..{high}] ---");
                }

                // PARTICIONAR: Reorganizamos el arreglo y obtenemos la posición final del pivote
                // "pi" = "pivot index" (índice del pivote)
                var pi = Partition(arr, low, high);

                // Mostramos dónde quedó el pivote
                if (VisualizationHelper.ShowStepByStep)
                {
                    Console.WriteLine($"  → Pivote colocado en posición {pi}");
                    VisualizationHelper.ShowStep(arr, "Estado actual", pi, -1);
                }

                // RECURSIÓN: Ahora ordenamos las dos mitades
                // 1. Todo lo que está a la IZQUIERDA del pivote (desde low hasta pi-1)
                Quicksort(arr, low, pi - 1);

                // 2. Todo lo que está a la DERECHA del pivote (desde pi+1 hasta high)
                Quicksort(arr, pi + 1, high);

                // Nota: No necesitamos ordenar el pivote porque ya está en su posición correcta
            }
        }

        /// <summary>
        /// Método de Partición
        /// 
        /// Este método reorganiza el arreglo de modo que:
        /// - Todos los elementos menores al pivote quedan a la izquierda
        /// - El pivote queda en su posición final
        /// - Todos los elementos mayores al pivote quedan a la derecha
        /// 
        /// Retorna: La posición final del pivote
        /// </summary>
        int Partition(int[] arr, int low, int high)
        {
            // Elegimos el último elemento como pivote
            // (podríamos elegir cualquier otro, pero esto es más simple)
            var pivot = arr[high];

            if (VisualizationHelper.ShowStepByStep)
            {
                Console.WriteLine($"  Pivote seleccionado: {pivot}");
            }

            // "i" marca la frontera entre elementos menores y mayores al pivote
            // Empieza en low - 1 (antes del inicio)
            int i = (low - 1);

            // Recorremos todos los elementos desde "low" hasta "high - 1"
            // (no incluimos "high" porque ese es el pivote)
            for (int j = low; j < high; j++)
            {
                comparisons++;  // Contamos cada comparación

                // COMPARACIÓN: ¿El elemento actual es menor que el pivote?
                if (arr[j] < pivot)
                {
                    // Si es menor, debe ir a la zona de "menores"
                    i++;  // Movemos la frontera una posición a la derecha

                    // Intercambiamos el elemento actual con el que está en la frontera
                    // (solo si no son el mismo elemento)
                    if (i != j)
                    {
                        if (VisualizationHelper.ShowStepByStep)
                        {
                            Console.WriteLine($"    Intercambiando {arr[i]} y {arr[j]}");
                        }

                        // Intercambio de valores
                        (arr[i], arr[j]) = (arr[j], arr[i]);
                        swaps++;
                    }
                }
                // Si arr[j] >= pivot, no hacemos nada, ese elemento se queda donde está
            }

            // COLOCACIÓN FINAL DEL PIVOTE:
            // Ahora "i + 1" es la posición correcta del pivote
            // Intercambiamos el pivote (que está en "high") con el elemento en "i + 1"
            (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
            swaps++;

            // Retornamos la posición final del pivote
            return i + 1;
        }
    }
}
