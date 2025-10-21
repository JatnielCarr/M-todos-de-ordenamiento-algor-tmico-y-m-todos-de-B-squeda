using System;

namespace MetodosAlgoritmicosyBusqueda
{
    /// <summary>
    /// ARRAY PRINTER (Impresor de Arreglos)
    /// 
    /// Esta clase se encarga de mostrar bonito un arreglo en la consola.
    /// En lugar de mostrar cada número por separado, lo muestra así: [1, 2, 3, 4]
    /// 
    /// Es una clase "static" (estática), lo que significa que no necesitamos crear
    /// un objeto de ella para usarla. Podemos llamar directamente a sus métodos.
    /// 
    /// Ejemplo de uso:
    ///   int[] numeros = {5, 2, 8};
    ///   ArrayPrinter.Print(numeros);
    ///   // Resultado en consola: [5, 2, 8]
    /// </summary>
    public static class ArrayPrinter
    {
        /// <summary>
        /// Método que imprime un arreglo de números enteros en formato bonito
        /// </summary>
        /// <param name="arr">El arreglo de números que queremos imprimir</param>
        public static void Print(int[] arr)
        {
            // Console.WriteLine() imprime algo en la consola y luego hace un salto de línea
            
            // string.Join() es un método que une todos los elementos del arreglo
            // separándolos con lo que le digamos (en este caso, ", ")
            // 
            // Ejemplo:
            //   Si arr = {5, 2, 8}
            //   string.Join(", ", arr) produce: "5, 2, 8"
            //   Agregamos "[" al inicio y "]" al final
            //   Resultado final: "[5, 2, 8]"
            
            Console.WriteLine("[" + string.Join(", ", arr) + "]");
        }
    }
}
