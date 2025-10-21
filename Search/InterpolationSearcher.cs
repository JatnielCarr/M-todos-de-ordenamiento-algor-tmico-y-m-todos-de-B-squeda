// ========================================================================================================
// BÚSQUEDA POR INTERPOLACIÓN - Búsqueda Mejorada para Datos Uniformemente Distribuidos
// ========================================================================================================
// La Búsqueda por Interpolación es similar a la Búsqueda Binaria, pero en lugar de siempre
// dividir el arreglo por la mitad, "adivina" dónde podría estar el elemento basándose en su valor.
//
// ANALOGÍA: Imagina que buscas una palabra en un diccionario.
// - Si buscas "Manzana", abres el diccionario más o menos por la mitad
// - Si buscas "Abeja", abres cerca del inicio
// - Si buscas "Zebra", abres cerca del final
// ¡No siempre abres exactamente en la mitad! Usas el valor para estimar dónde buscar.
//
// REQUISITO: El arreglo DEBE estar ordenado (como la Búsqueda Binaria)
//
// COMPLEJIDAD:
// - Mejor caso: O(1) - encuentra el elemento inmediatamente
// - Caso promedio (datos uniformes): O(log log n) - ¡más rápido que Binaria!
// - Peor caso (datos agrupados): O(n) - puede ser lento si los datos no son uniformes
//
// VENTAJAS:
// - Muy rápida cuando los datos están uniformemente distribuidos
// - Usa menos comparaciones que Búsqueda Binaria en promedio
// DESVENTAJAS:
// - Requiere arreglo ordenado
// - Puede ser lenta si los datos tienen muchos duplicados o están agrupados
// - Más compleja de implementar que Búsqueda Binaria

using System;

namespace MetodosAlgoritmicosyBusqueda
{
    // Esta clase implementa la interfaz ISearcher
    public class InterpolationSearcher : ISearcher
    {
        // Propiedad Name - Devuelve el nombre del algoritmo para mostrarlo en el menú
        public string Name => "Búsqueda por Interpolación";

        // Propiedad RequiresSorted - Indica que el arreglo DEBE estar ordenado
        // La interpolación solo funciona correctamente con datos ordenados
        public bool RequiresSorted => true;

        // Contador de comparaciones para fines educativos
        private int comparisons = 0;

        // ================================================================================================
        // MÉTODO SEARCH - Busca un elemento usando Búsqueda por Interpolación
        // ================================================================================================
        // Parámetros:
        // - arr: el arreglo donde buscar (DEBE estar ordenado)
        // - target: el número que queremos encontrar
        //
        // Retorna:
        // - El índice donde se encuentra el elemento (0, 1, 2, ...)
        // - -1 si el elemento no existe en el arreglo
        public int Search(int[] arr, int target)
        {
            // Reiniciar contador
            comparisons = 0;

            Console.WriteLine("\n🔍 Búsqueda por Interpolación");
            Console.WriteLine("Este algoritmo 'adivina' la posición del elemento basándose en su valor.");

            // Validación: verificar que el arreglo no esté vacío
            if (arr.Length == 0)
            {
                Console.WriteLine("❌ El arreglo está vacío.");
                return -1;
            }

            // Índices del rango de búsqueda
            int low = 0;                // Índice inicial
            int high = arr.Length - 1;  // Índice final

            // ========================================================================================
            // BUCLE DE BÚSQUEDA
            // ========================================================================================
            // Continuamos mientras:
            // 1. El rango sea válido (low <= high)
            // 2. El valor buscado esté dentro del rango de valores posibles
            //
            // ¿Por qué verificar target >= arr[low] && target <= arr[high]?
            // Si el target está fuera de este rango, sabemos que NO existe en el arreglo
            // porque el arreglo está ordenado.
            while (low <= high && target >= arr[low] && target <= arr[high])
            {
                // CASO ESPECIAL: Si low == high, solo hay un elemento en el rango
                if (low == high)
                {
                    comparisons++;
                    if (arr[low] == target)
                    {
                        Console.WriteLine($"✓ Encontrado en la posición {low} (único elemento en el rango)");
                        Console.WriteLine($"📊 Comparaciones realizadas: {comparisons}");
                        return low;
                    }
                    else
                    {
                        Console.WriteLine($"✗ No encontrado. Comparaciones: {comparisons}");
                        return -1;
                    }
                }

                // ========================================================================================
                // FÓRMULA DE INTERPOLACIÓN - El "Corazón" del Algoritmo
                // ========================================================================================
                // Esta fórmula estima dónde podría estar el elemento basándose en su valor.
                //
                // La fórmula es:
                // pos = low + ((target - arr[low]) * (high - low)) / (arr[high] - arr[low])
                //
                // EXPLICACIÓN INTUITIVA:
                // - (target - arr[low]) / (arr[high] - arr[low]) = qué fracción del rango de VALORES es target
                // - (high - low) = tamaño del rango de ÍNDICES
                // - Multiplicamos la fracción por el tamaño para obtener la posición estimada
                //
                // EJEMPLO:
                // Arreglo: [10, 20, 30, 40, 50]  (índices 0-4)
                // Buscamos: 35
                // low=0, high=4, arr[low]=10, arr[high]=50
                // 
                // (35 - 10) / (50 - 10) = 25/40 = 0.625  (35 está al 62.5% del rango de valores)
                // 0.625 * (4 - 0) = 2.5 ≈ 2                (estimamos que está en el índice 2 o cerca)
                // pos = 0 + 2 = 2
                //
                // Verificamos arr[2] = 30. Como 35 > 30, buscamos a la derecha.

                int pos = low + ((target - arr[low]) * (high - low)) / (arr[high] - arr[low]);

                // Asegurarnos de que pos esté dentro del rango válido
                // (La aritmética entera puede causar que pos salga del rango)
                if (pos < low) pos = low;
                if (pos > high) pos = high;

                if (VisualizationHelper.ShowStepByStep)
                {
                    Console.WriteLine($"\n📍 Estimando posición:");
                    Console.WriteLine($"   Rango: [{low}...{high}]  Valores: [{arr[low]}...{arr[high]}]");
                    Console.WriteLine($"   Buscando: {target}");
                    Console.WriteLine($"   Posición estimada: {pos} (valor: {arr[pos]})");
                    
                    // Mostrar el arreglo con la posición estimada resaltada
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (i == pos)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"[{arr[i]}] ");
                            Console.ResetColor();
                        }
                        else if (i >= low && i <= high)
                        {
                            Console.Write($"{arr[i]} ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write($"{arr[i]} ");
                            Console.ResetColor();
                        }
                    }
                    Console.WriteLine();
                    VisualizationHelper.WaitForUser();
                }

                // ========================================================================================
                // COMPARAR Y DECIDIR
                // ========================================================================================
                comparisons++;

                if (arr[pos] == target)
                {
                    // ¡ENCONTRADO!
                    Console.WriteLine($"✓ Encontrado en la posición {pos}");
                    Console.WriteLine($"📊 Comparaciones realizadas: {comparisons}");
                    return pos;
                }

                if (arr[pos] < target)
                {
                    // El elemento está a la DERECHA
                    // Ajustamos low para buscar en la mitad derecha
                    if (VisualizationHelper.ShowStepByStep)
                    {
                        Console.WriteLine($"   {arr[pos]} < {target} → Buscar a la derecha");
                    }
                    low = pos + 1;
                }
                else
                {
                    // El elemento está a la IZQUIERDA
                    // Ajustamos high para buscar en la mitad izquierda
                    if (VisualizationHelper.ShowStepByStep)
                    {
                        Console.WriteLine($"   {arr[pos]} > {target} → Buscar a la izquierda");
                    }
                    high = pos - 1;
                }
            }

            // Si salimos del bucle, el elemento no existe
            Console.WriteLine($"✗ No encontrado. Comparaciones: {comparisons}");
            return -1;
        }
    }
}
