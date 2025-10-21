// ========================================================================================================
// BÚSQUEDA POR HASH - Búsqueda Ultra Rápida Usando Tabla Hash
// ========================================================================================================
// La Búsqueda por Hash usa una "función hash" para calcular directamente dónde debería
// estar un elemento, permitiendo búsquedas en tiempo casi constante O(1).
//
// ANALOGÍA: Imagina una biblioteca donde cada libro tiene un código (ISBN).
// En lugar de buscar libro por libro, el código te dice EXACTAMENTE en qué estante está.
// Solo vas directo a ese estante y lo tomas. ¡Súper rápido!
//
// CÓMO FUNCIONA:
// 1. Creamos una "tabla hash" (diccionario) que mapea cada número a su posición
// 2. Para buscar, simplemente consultamos el diccionario: "¿Dónde está el número X?"
// 3. El diccionario responde instantáneamente con la posición (o dice "no existe")
//
// REQUISITO: NO requiere que el arreglo esté ordenado
//
// COMPLEJIDAD:
// - Mejor caso: O(1) - acceso directo
// - Caso promedio: O(1) - casi siempre es inmediato
// - Peor caso: O(n) - cuando hay muchas "colisiones" (muy raro con buenas funciones hash)
//
// VENTAJAS:
// - RAPIDÍSIMO para búsquedas (O(1) en promedio)
// - No requiere arreglo ordenado
// - Ideal cuando harás MUCHAS búsquedas en el mismo arreglo
// DESVENTAJAS:
// - Usa memoria extra O(n) para la tabla hash
// - Hay un costo inicial de construir la tabla hash
// - No mantiene el orden de los elementos
// - No es eficiente si solo vas a hacer UNA búsqueda

using System;
using System.Collections.Generic;

namespace MetodosAlgoritmicosyBusqueda
{
    // Esta clase implementa la interfaz ISearcher
    public class HashSearcher : ISearcher
    {
        // Propiedad Name - Devuelve el nombre del algoritmo para mostrarlo en el menú
        public string Name => "Búsqueda por Hash (Tabla Hash)";

        // Propiedad RequiresSorted - NO requiere que el arreglo esté ordenado
        // ¡Esta es una gran ventaja del hash!
        public bool RequiresSorted => false;

        // ================================================================================================
        // MÉTODO SEARCH - Busca un elemento usando una Tabla Hash
        // ================================================================================================
        // Parámetros:
        // - arr: el arreglo donde buscar (NO necesita estar ordenado)
        // - target: el número que queremos encontrar
        //
        // Retorna:
        // - El índice donde se encuentra el elemento (0, 1, 2, ...)
        // - -1 si el elemento no existe en el arreglo
        public int Search(int[] arr, int target)
        {
            Console.WriteLine("\n🔍 Búsqueda por Hash");
            Console.WriteLine("Este algoritmo crea una tabla hash para acceso instantáneo.");

            // Validación: verificar que el arreglo no esté vacío
            if (arr.Length == 0)
            {
                Console.WriteLine("❌ El arreglo está vacío.");
                return -1;
            }

            // ========================================================================================
            // FASE 1: CONSTRUIR LA TABLA HASH
            // ========================================================================================
            // Dictionary<int, int> es una "tabla hash" o "diccionario" en C#.
            // Es una estructura de datos que mapea "claves" a "valores":
            //   - Clave (key): el número del arreglo
            //   - Valor (value): la posición (índice) donde se encuentra
            //
            // Ejemplo: Si arr = [50, 20, 30]
            // La tabla hash será:
            //   50 → 0  (50 está en el índice 0)
            //   20 → 1  (20 está en el índice 1)
            //   30 → 2  (30 está en el índice 2)
            //
            // Dictionary usa internamente una función hash para almacenar y recuperar
            // los datos de forma ultra rápida (O(1)).

            Console.WriteLine("\n--- FASE 1: Construyendo tabla hash ---");
            
            var hashTable = new Dictionary<int, int>();
            
            // Recorrer el arreglo y agregar cada elemento a la tabla hash
            for (int i = 0; i < arr.Length; i++)
            {
                // ¿QUÉ PASA SI HAY DUPLICADOS?
                // Si el mismo número aparece varias veces, guardamos el índice de la PRIMERA aparición.
                // ContainsKey() verifica si la clave ya existe en el diccionario.
                if (!hashTable.ContainsKey(arr[i]))
                {
                    // Agregar: clave = arr[i], valor = i
                    hashTable[arr[i]] = i;
                    
                    if (VisualizationHelper.ShowStepByStep)
                    {
                        Console.WriteLine($"   Agregando a tabla: {arr[i]} → índice {i}");
                    }
                }
                else
                {
                    // Si ya existe, no lo agregamos de nuevo
                    if (VisualizationHelper.ShowStepByStep)
                    {
                        Console.WriteLine($"   {arr[i]} ya existe en la tabla (índice {hashTable[arr[i]]}), ignorando duplicado");
                    }
                }
            }

            Console.WriteLine($"\n✓ Tabla hash construida con {hashTable.Count} entradas únicas.");
            
            if (VisualizationHelper.ShowStepByStep)
            {
                Console.WriteLine("\nContenido de la tabla hash:");
                foreach (var kvp in hashTable)
                {
                    Console.WriteLine($"   {kvp.Key} → índice {kvp.Value}");
                }
                VisualizationHelper.WaitForUser();
            }

            // ========================================================================================
            // FASE 2: BUSCAR EN LA TABLA HASH
            // ========================================================================================
            Console.WriteLine($"\n--- FASE 2: Buscando {target} en la tabla hash ---");

            // ContainsKey() verifica si la clave (target) existe en el diccionario
            // Esta operación es O(1) - ¡instantánea!
            if (hashTable.ContainsKey(target))
            {
                // ¡ENCONTRADO!
                // Recuperar el índice asociado al target
                int index = hashTable[target];
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✓ ¡ENCONTRADO INSTANTÁNEAMENTE!");
                Console.ResetColor();
                Console.WriteLine($"   Número: {target}");
                Console.WriteLine($"   Índice: {index}");
                Console.WriteLine($"   Valor en arr[{index}]: {arr[index]}");
                
                Console.WriteLine("\n📊 Estadísticas:");
                Console.WriteLine($"   Accesos a la tabla hash: 1 (búsqueda directa)");
                Console.WriteLine($"   Complejidad: O(1) - ¡tiempo constante!");
                
                return index;
            }
            else
            {
                // NO ENCONTRADO
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"✗ NO ENCONTRADO");
                Console.ResetColor();
                Console.WriteLine($"   El número {target} no existe en el arreglo.");
                
                Console.WriteLine("\n📊 Estadísticas:");
                Console.WriteLine($"   Accesos a la tabla hash: 1 (búsqueda directa)");
                Console.WriteLine($"   Complejidad: O(1) - ¡tiempo constante!");
                
                return -1;
            }
        }
    }
}

// ========================================================================================================
// NOTAS ADICIONALES SOBRE HASH
// ========================================================================================================
//
// ¿QUÉ ES UNA FUNCIÓN HASH?
// Una función hash convierte un dato (como un número o texto) en un índice de la tabla.
// Por ejemplo: hash(50) = 3, hash(20) = 7, etc.
// C# hace esto automáticamente en Dictionary<>.
//
// ¿QUÉ SON LAS COLISIONES?
// Una colisión ocurre cuando dos números diferentes producen el mismo hash.
// Por ejemplo: si hash(50) = 3 y hash(80) = 3, hay colisión.
// Dictionary<> de C# maneja esto automáticamente usando técnicas como "chaining".
//
// CUÁNDO USAR BÚSQUEDA POR HASH:
// ✓ Cuando harás MUCHAS búsquedas en el mismo arreglo
// ✓ Cuando la velocidad es crítica
// ✓ Cuando tienes memoria suficiente para la tabla hash
//
// CUÁNDO NO USARLA:
// ✗ Si solo harás UNA búsqueda (el costo de construir la tabla no vale la pena)
// ✗ Si la memoria es limitada
// ✗ Si necesitas mantener el orden de los elementos
//
// ========================================================================================================
