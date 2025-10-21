namespace MetodosAlgoritmicosyBusqueda
{
    /// <summary>
    /// BINARY SEARCH (Búsqueda Binaria)
    /// 
    /// ¿Cómo funciona?
    /// Es como buscar una palabra en el diccionario. No empiezas desde la A,
    /// sino que abres el diccionario por la mitad:
    /// - Si la palabra que buscas está antes, buscas en la mitad izquierda
    /// - Si está después, buscas en la mitad derecha
    /// - Repites hasta encontrarla
    /// 
    /// IMPORTANTE: Solo funciona si el arreglo está ORDENADO
    /// 
    /// Ejemplo visual:
    /// Buscar el número 8 en: [1, 2, 5, 8, 9] (ya ordenado)
    /// 
    /// Paso 1: Revisar el elemento del medio
    ///         [1, 2, 5, 8, 9]
    ///               ↑ medio = 5
    ///         ¿8 es igual a 5? NO
    ///         ¿8 es mayor que 5? SÍ → Buscar en la mitad derecha
    /// 
    /// Paso 2: Ahora miramos [8, 9]
    ///                        [8, 9]
    ///                         ↑ medio = 8
    ///         ¿8 es igual a 8? SÍ → ¡Encontrado!
    /// 
    /// Ventajas:
    /// - MUY rápido en arreglos grandes
    /// - En cada paso, descartamos la mitad del arreglo
    /// 
    /// Desventajas:
    /// - REQUIERE que el arreglo esté ordenado
    /// - Un poco más complejo de entender
    /// </summary>
    public class BinarySearcher : ISearcher
    {
        // Nombre del algoritmo
        public string Name => "Binary Search (Búsqueda Binaria)";

        // Este algoritmo SÍ requiere que el arreglo esté ordenado
        // Si el arreglo no está ordenado, puede dar resultados incorrectos
        public bool RequiresSorted => true;

        // Método que realiza la búsqueda binaria
        // Parámetros:
        //   - arr: arreglo ORDENADO donde buscaremos
        //   - x: número que estamos buscando
        // Retorna:
        //   - El índice donde se encontró el número
        //   - -1 si no se encontró
        public int Search(int[] arr, int x)
        {
            // "l" (left) = límite izquierdo del segmento donde buscamos
            // "r" (right) = límite derecho del segmento donde buscamos
            // Al inicio, buscamos en todo el arreglo: desde 0 hasta el final
            int l = 0;
            int r = arr.Length - 1;

            // CICLO: Mientras haya elementos por revisar (l <= r)
            // Si l > r, significa que ya no quedan elementos y no encontramos nada
            while (l <= r)
            {
                // Calculamos el índice del elemento del MEDIO
                // Usamos "l + (r - l) / 2" en lugar de "(l + r) / 2"
                // para evitar desbordamiento en arreglos muy grandes
                // Ejemplo: si l = 2 y r = 6, entonces m = 2 + (6-2)/2 = 2 + 2 = 4
                var m = l + (r - l) / 2;

                // CASO 1: ¿El elemento del medio es exactamente lo que buscamos?
                if (arr[m] == x)
                {
                    // ¡Lo encontramos! Retornamos su posición
                    return m;
                }

                // CASO 2: ¿El elemento del medio es MENOR que lo que buscamos?
                // Ejemplo: buscamos 8, pero arr[m] = 5
                // Entonces, 8 debe estar en la mitad DERECHA
                if (arr[m] < x)
                {
                    // Movemos el límite izquierdo después del medio
                    // Descartamos toda la mitad izquierda
                    l = m + 1;
                }
                // CASO 3: El elemento del medio es MAYOR que lo que buscamos
                // Ejemplo: buscamos 3, pero arr[m] = 5
                // Entonces, 3 debe estar en la mitad IZQUIERDA
                else
                {
                    // Movemos el límite derecho antes del medio
                    // Descartamos toda la mitad derecha
                    r = m - 1;
                }

                // El ciclo continúa automáticamente con los nuevos límites
                // En cada iteración, el espacio de búsqueda se reduce a la mitad
            }

            // Si salimos del while, significa que l > r
            // No encontramos el elemento en todo el arreglo
            // Retornamos -1 para indicar "no encontrado"
            return -1;
        }
    }
}
