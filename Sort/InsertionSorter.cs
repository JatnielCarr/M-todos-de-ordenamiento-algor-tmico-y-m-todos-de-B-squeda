using System;

namespace MetodosAlgoritmicosyBusqueda
{
    /// <summary>
    /// INSERTION SORT (Ordenamiento por Inserción)
    /// 
    /// ¿Cómo funciona?
    /// Imagina que estás ordenando cartas en tu mano. Tomas una carta nueva y la insertas
    /// en su posición correcta entre las cartas que ya tienes ordenadas.
    /// 
    /// Ejemplo visual:
    /// Inicio:        [5, 2, 8, 1]
    ///                 ↑ (esta parte ya está "ordenada" - solo tiene 1 elemento)
    /// 
    /// Paso 1: Tomar el 2
    ///                [5, 2, 8, 1]
    ///                    ↑ vamos a insertar el 2
    ///                Desplazamos el 5 a la derecha
    ///                Insertamos el 2 al inicio
    ///                Resultado: [2, 5, 8, 1]
    ///                            ↑----↑ (ahora esta parte está ordenada)
    /// 
    /// Paso 2: Tomar el 8
    ///                [2, 5, 8, 1]
    ///                       ↑ el 8 ya está en su lugar, no movemos nada
    ///                Resultado: [2, 5, 8, 1]
    ///                            ↑-------↑ (esta parte está ordenada)
    /// 
    /// Paso 3: Tomar el 1
    ///                [2, 5, 8, 1]
    ///                          ↑ vamos a insertar el 1
    ///                Desplazamos 8, 5, 2 a la derecha
    ///                Insertamos el 1 al inicio
    ///                Resultado: [1, 2, 5, 8]
    ///                            ↑----------↑ (¡todo ordenado!)
    /// </summary>
    public class InsertionSorter : ISorter
    {
        // Nombre del algoritmo
        public string Name => "Insertion Sort (Inserción)";

        // Método principal que ordena el arreglo
        public void Sort(int[] arr)
        {
            // Guardamos cuántos elementos tiene el arreglo
            var n = arr.Length;

            // Contadores para estadísticas
            int comparisons = 0;  // Cuántas veces comparamos números
            int shifts = 0;       // Cuántas veces desplazamos un número a la derecha

            // CICLO PRINCIPAL: Empezamos desde el segundo elemento (índice 1)
            // ¿Por qué desde el 1? Porque consideramos que el primer elemento (índice 0)
            // ya está "ordenado" por sí mismo (es solo un elemento)
            for (int i = 1; i < n; ++i)
            {
                // "key" es el elemento que vamos a insertar en su posición correcta
                // Es como la "carta nueva" que tomamos de la baraja
                var key = arr[i];

                // "j" es la posición donde buscamos el lugar correcto para insertar
                // Empezamos mirando el elemento justo antes del "key"
                int j = i - 1;

                // Mostramos qué elemento vamos a insertar (si está en modo visual)
                if (VisualizationHelper.ShowStepByStep)
                {
                    Console.WriteLine($"\n--- Insertando elemento {key} (posición {i}) ---");
                    VisualizationHelper.ShowStep(arr, "Estado actual", i, -1);
                }

                // CICLO DE INSERCIÓN: Buscamos dónde colocar el "key"
                // Condiciones del while:
                // 1. "j >= 0" → No nos salimos del arreglo por la izquierda
                // 2. "arr[j] > key" → El elemento en posición j es mayor que nuestro key
                //
                // Mientras se cumplan ambas condiciones, seguimos desplazando elementos a la derecha
                while (j >= 0 && arr[j] > key)
                {
                    comparisons++;  // Contamos que hicimos una comparación

                    // Explicamos qué estamos haciendo
                    if (VisualizationHelper.ShowStepByStep)
                    {
                        Console.WriteLine($"  → {arr[j]} > {key}, desplazando {arr[j]} a la derecha");
                    }

                    // DESPLAZAMIENTO: Movemos el elemento una posición a la derecha
                    // Ejemplo: si arr[j] = 5 y estamos en posición j = 1
                    // Entonces arr[2] = arr[1], o sea, copiamos el 5 una posición a la derecha
                    arr[j + 1] = arr[j];

                    shifts++;  // Contamos que hicimos un desplazamiento
                    j = j - 1; // Nos movemos una posición a la izquierda para seguir comparando
                }

                // Si llegamos aquí y j >= 0, significa que hicimos una comparación más
                // (la que hizo que el while se detuviera)
                if (j >= 0) comparisons++;

                // INSERCIÓN FINAL: Colocamos el "key" en su posición correcta
                // "j + 1" es la posición donde debe ir
                // ¿Por qué j + 1? Porque el while nos dejó en la posición anterior
                arr[j + 1] = key;

                // Mostramos el resultado de esta inserción
                if (VisualizationHelper.ShowStepByStep)
                {
                    Console.WriteLine($"  → Insertando {key} en posición {j + 1}");
                    VisualizationHelper.ShowStep(arr, "Resultado", j + 1, -1);
                }
            }

            // Mostramos las estadísticas finales
            if (!VisualizationHelper.ShowStepByStep)
            {
                Console.WriteLine($"\nEstadísticas: {comparisons} comparaciones, {shifts} desplazamientos");
            }
            else
            {
                Console.WriteLine($"\n✓ Completado: {comparisons} comparaciones, {shifts} desplazamientos");
            }
        }
    }
}
