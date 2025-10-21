namespace MetodosAlgoritmicosyBusqueda
{
    /// <summary>
    /// INTERFAZ ISearcher (Buscador)
    /// 
    /// ¿Qué es una interfaz?
    /// Es un "contrato" que define qué debe poder hacer un algoritmo de búsqueda.
    /// Todos los algoritmos de búsqueda deben cumplir con estas características.
    /// 
    /// Esta interfaz obliga a que todos los algoritmos de búsqueda tengan:
    /// 1. Un nombre (Name)
    /// 2. Información sobre si necesitan el arreglo ordenado (RequiresSorted)
    /// 3. Un método para buscar un elemento (Search)
    /// </summary>
    public interface ISearcher
    {
        // Propiedad "Name" (Nombre)
        // Cada algoritmo de búsqueda debe decir cómo se llama
        // Ejemplo: "Linear Search", "Binary Search"
        string Name { get; }

        // Propiedad "RequiresSorted" (Requiere Ordenado)
        // Indica si el algoritmo necesita que el arreglo esté ordenado para funcionar
        // "bool" es un tipo de dato que solo puede ser "true" (verdadero) o "false" (falso)
        // - Linear Search: false (puede buscar en arreglos desordenados)
        // - Binary Search: true (NECESITA que el arreglo esté ordenado)
        bool RequiresSorted { get; }

        // Método "Search" (Buscar)
        // Busca un número específico dentro del arreglo
        // Parámetros:
        //   - arr: el arreglo de números donde vamos a buscar
        //   - x: el número que estamos buscando
        // Retorna:
        //   - Un número entero (int) que representa el índice donde se encontró
        //   - Si retorna -1, significa que NO se encontró el elemento
        //   - Si retorna 0, 1, 2, etc., significa que se encontró en esa posición
        int Search(int[] arr, int x);
    }
}
