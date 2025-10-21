namespace MetodosAlgoritmicosyBusqueda
{
    /// <summary>
    /// INTERFAZ ISorter
    /// 
    /// ¿Qué es una interfaz?
    /// Una interfaz es como un "contrato" o "plantilla" que define qué métodos debe tener una clase.
    /// Es como decir: "Todos los algoritmos de ordenamiento DEBEN tener estas características".
    /// 
    /// Esta interfaz obliga a que todos los algoritmos de ordenamiento:
    /// 1. Tengan un nombre (Name)
    /// 2. Tengan un método para ordenar (Sort)
    /// 
    /// Ventaja: Podemos tratar a todos los algoritmos de la misma manera, aunque funcionen diferente por dentro.
    /// </summary>
    public interface ISorter
    {
        // Propiedad "Name" (Nombre)
        // Cada algoritmo debe decir cómo se llama (por ejemplo: "Bubble Sort", "Quicksort")
        // "string" significa que es texto
        // "{ get; }" significa que podemos leer este valor
        string Name { get; }

        // Método "Sort" (Ordenar)
        // Cada algoritmo debe tener una función que ordene un arreglo de números enteros
        // "void" significa que no devuelve ningún valor, solo hace la acción de ordenar
        // "int[] arr" es el arreglo de números que vamos a ordenar
        void Sort(int[] arr);
    }
}
