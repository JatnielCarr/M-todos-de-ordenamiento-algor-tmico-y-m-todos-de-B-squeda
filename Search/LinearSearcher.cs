namespace MetodosAlgoritmicosyBusqueda
{
    /// <summary>
    /// LINEAR SEARCH (Búsqueda Lineal o Secuencial)
    /// 
    /// ¿Cómo funciona?
    /// Es el método más simple de búsqueda. Imagina que estás buscando un libro en una pila:
    /// revisas el primer libro, luego el segundo, luego el tercero... hasta encontrarlo.
    /// 
    /// Ejemplo visual:
    /// Buscar el número 8 en: [5, 2, 8, 1, 9]
    /// 
    /// Paso 1: ¿5 es igual a 8? NO → Siguiente
    /// Paso 2: ¿2 es igual a 8? NO → Siguiente
    /// Paso 3: ¿8 es igual a 8? SÍ → ¡Encontrado en posición 2!
    /// 
    /// Ventajas:
    /// - Muy simple de entender
    /// - Funciona con arreglos ordenados y desordenados
    /// - No necesita preparación del arreglo
    /// 
    /// Desventajas:
    /// - Puede ser lento en arreglos grandes
    /// - Si el elemento está al final, revisará todo el arreglo
    /// </summary>
    public class LinearSearcher : ISearcher
    {
        // Nombre del algoritmo
        public string Name => "Linear Search (Búsqueda Lineal)";

        // Este algoritmo NO requiere que el arreglo esté ordenado
        // Puede buscar en cualquier arreglo, ordenado o desordenado
        public bool RequiresSorted => false;

        // Método que realiza la búsqueda
        // Parámetros:
        //   - arr: arreglo donde buscaremos
        //   - x: número que estamos buscando
        // Retorna:
        //   - El índice (posición) donde se encontró el número
        //   - -1 si no se encontró
        public int Search(int[] arr, int x)
        {
            // CICLO: Recorremos el arreglo desde el inicio hasta el final
            // "i" es la posición actual que estamos revisando
            // Empezamos en 0 (primera posición) y vamos hasta arr.Length - 1 (última posición)
            for (int i = 0; i < arr.Length; i++)
            {
                // COMPARACIÓN: ¿El elemento en la posición "i" es igual a lo que buscamos?
                if (arr[i] == x)
                {
                    // ¡Lo encontramos! Retornamos la posición donde está
                    return i;
                }
                // Si no es igual, el ciclo continúa automáticamente a la siguiente posición
            }

            // Si llegamos aquí, significa que recorrimos todo el arreglo
            // y NO encontramos el elemento
            // Retornamos -1 para indicar "no encontrado"
            return -1;
        }
    }
}
