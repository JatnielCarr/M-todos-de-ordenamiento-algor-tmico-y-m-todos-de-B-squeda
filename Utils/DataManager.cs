using System;

namespace MetodosAlgoritmicosyBusqueda
{
    /// <summary>
    /// DATA MANAGER (Gestor de Datos)
    /// 
    /// ¿Qué hace esta clase?
    /// Es el "encargado" de manejar el arreglo de números que usamos en todo el programa.
    /// Permite:
    /// - Crear datos aleatorios
    /// - Ingresar datos manualmente
    /// - Usar conjuntos predefinidos
    /// - Ver y modificar los datos actuales
    /// 
    /// Es como el "almacén" donde guardamos y administramos nuestros datos.
    /// </summary>
    public class DataManager
    {
        // CAMPO PRIVADO: El arreglo de datos que gestiona esta clase
        // "private" significa que solo esta clase puede acceder directamente a _data
        // El guion bajo "_" al inicio es una convención para indicar que es privado
        private int[] _data;

        /// <summary>
        /// CONSTRUCTOR
        /// Un constructor es un método especial que se ejecuta automáticamente
        /// cuando creamos un nuevo objeto de esta clase.
        /// 
        /// Es como el "nacimiento" del objeto, donde lo configuramos por primera vez.
        /// </summary>
        public DataManager()
        {
            // Inicializamos el arreglo con datos predeterminados
            // Estos son los datos que se usan al comenzar el programa
            _data = new int[] { 42, 23, 16, 8, 4, 15, 108, 55, 31 };
        }

        /// <summary>
        /// Obtiene una COPIA de los datos actuales
        /// 
        /// ¿Por qué una copia?
        /// Si alguien modifica la copia, el original no se afecta.
        /// Es como darle una fotocopia a alguien en lugar del documento original.
        /// </summary>
        /// <returns>Una copia del arreglo de datos</returns>
        public int[] GetData() => (int[])_data.Clone();
        // "Clone()" crea una copia exacta del arreglo
        // "(int[])" es un "cast" que convierte el resultado a tipo int[]

        /// <summary>
        /// Obtiene el arreglo ORIGINAL de datos (no una copia)
        /// 
        /// ¡CUIDADO! Si modificas este arreglo, cambias los datos reales.
        /// Es como darle el documento original a alguien.
        /// </summary>
        /// <returns>El arreglo original de datos</returns>
        public int[] GetOriginalData() => _data;

        /// <summary>
        /// Muestra en la consola los datos actuales y cuántos elementos hay
        /// </summary>
        public void ShowCurrentData()
        {
            Console.WriteLine("\nDatos actuales:");
            
            // Usamos ArrayPrinter para mostrar el arreglo bonito
            ArrayPrinter.Print(_data);
            
            // Mostramos cuántos elementos tiene el arreglo
            // _data.Length nos da el tamaño del arreglo
            Console.WriteLine($"Cantidad de elementos: {_data.Length}");
        }

        /// <summary>
        /// Genera un arreglo de números aleatorios
        /// 
        /// ¿Qué hace este método?
        /// Pregunta al usuario:
        /// 1. ¿Cuántos números quieres? (entre 1 y 100)
        /// 2. ¿Cuál es el valor mínimo?
        /// 3. ¿Cuál es el valor máximo?
        /// Luego genera números aleatorios dentro de ese rango.
        /// 
        /// Ejemplo: Si pides 5 números entre 1 y 10, podría generar: [3, 7, 1, 9, 5]
        /// </summary>
        public void GenerateRandomData()
        {
            // PASO 1: Preguntar cuántos elementos
            Console.Write("¿Cuántos elementos deseas generar? (1-100): ");
            
            // int.TryParse() intenta convertir texto a número
            // Si el usuario escribe algo que NO es un número, retorna false
            // "out int count" guarda el resultado en la variable "count"
            // También verificamos que esté entre 1 y 100
            if (!int.TryParse(Console.ReadLine(), out int count) || count < 1 || count > 100)
            {
                // Si la entrada es inválida, usamos 10 por defecto
                Console.WriteLine("Cantidad inválida. Se usará 10 elementos.");
                count = 10;
            }

            // PASO 2: Preguntar el valor mínimo
            Console.Write("Valor mínimo para los números: ");
            if (!int.TryParse(Console.ReadLine(), out int min))
            {
                // Si no es un número válido, usamos 1 por defecto
                min = 1;
            }

            // PASO 3: Preguntar el valor máximo
            Console.Write("Valor máximo para los números: ");
            if (!int.TryParse(Console.ReadLine(), out int max))
            {
                // Si no es un número válido, usamos 100 por defecto
                max = 100;
            }

            // VALIDACIÓN: El mínimo debe ser menor que el máximo
            // Si el usuario puso min = 50 y max = 10, eso no tiene sentido
            if (min >= max)
            {
                Console.WriteLine("El mínimo debe ser menor que el máximo. Usando rango predeterminado 1-100.");
                min = 1;
                max = 100;
            }

            // GENERACIÓN DE NÚMEROS ALEATORIOS
            // Random es una clase que genera números al azar
            var random = new Random();
            
            // Creamos un nuevo arreglo con el tamaño que pidió el usuario
            _data = new int[count];
            
            // Llenamos cada posición del arreglo con un número aleatorio
            for (int i = 0; i < count; i++)
            {
                // random.Next(min, max + 1) genera un número entre min y max (inclusive)
                // ¿Por qué max + 1? Porque Next() no incluye el límite superior
                // Ejemplo: Next(1, 11) genera números de 1 a 10
                _data[i] = random.Next(min, max + 1);
            }

            // Mostramos un mensaje de éxito y los datos generados
            Console.WriteLine("\n¡Datos aleatorios generados!");
            ShowCurrentData();
        }

        /// <summary>
        /// Permite al usuario ingresar datos manualmente, uno por uno
        /// 
        /// ¿Qué hace este método?
        /// Pregunta cuántos números quiere ingresar y luego
        /// pide cada número individualmente.
        /// 
        /// Es útil cuando quieres probar casos específicos.
        /// Ejemplo: Puedes crear [5, 2, 8, 1] para ver cómo funciona un algoritmo
        /// </summary>
        public void EnterManualData()
        {
            // Preguntamos cuántos elementos quiere ingresar
            Console.Write("¿Cuántos elementos deseas ingresar? (1-50): ");
            
            // Validamos la entrada
            if (!int.TryParse(Console.ReadLine(), out int count) || count < 1 || count > 50)
            {
                Console.WriteLine("Cantidad inválida. Operación cancelada.");
                // "return" termina el método aquí, no continúa ejecutando
                return;
            }

            // Creamos un arreglo del tamaño especificado
            _data = new int[count];
            
            // CICLO: Pedimos cada elemento uno por uno
            for (int i = 0; i < count; i++)
            {
                // "valid" indica si el valor ingresado es válido
                bool valid = false;
                
                // Repetimos hasta que el usuario ingrese un número válido
                while (!valid)
                {
                    // Mostramos qué número estamos pidiendo
                    // "i + 1" porque para el usuario es más natural contar desde 1
                    // (aunque internamente los arreglos empiezan en 0)
                    Console.Write($"Ingresa el elemento #{i + 1}: ");
                    
                    // Intentamos convertir la entrada a número
                    if (int.TryParse(Console.ReadLine(), out int value))
                    {
                        // ¡Éxito! Guardamos el valor en el arreglo
                        _data[i] = value;
                        valid = true;  // Marcamos como válido para salir del while
                    }
                    else
                    {
                        // El usuario ingresó algo que no es un número
                        Console.WriteLine("Valor inválido. Intenta de nuevo.");
                        // El while continuará, pidiendo el número otra vez
                    }
                }
            }

            // Cuando terminamos de pedir todos los números, mostramos el resultado
            Console.WriteLine("\n¡Datos ingresados manualmente!");
            ShowCurrentData();
        }

        /// <summary>
        /// Permite elegir entre varios conjuntos de datos predefinidos
        /// 
        /// ¿Qué hace este método?
        /// Ofrece 5 opciones de conjuntos de datos ya preparados:
        /// 1. Pequeño - Ideal para demostraciones detalladas
        /// 2. Mediano - El conjunto original del programa
        /// 3. Grande - Para probar rendimiento
        /// 4. Ya ordenado - Para mostrar el mejor caso de algoritmos
        /// 5. Orden inverso - Para mostrar el peor caso de algoritmos
        /// 
        /// Es útil para hacer comparaciones y demostraciones en clase.
        /// </summary>
        public void UsePresetData()
        {
            // Mostramos el menú de opciones
            Console.WriteLine("\nElige un conjunto de datos predefinido:");
            Console.WriteLine("1. Pequeño (5 elementos)");
            Console.WriteLine("2. Mediano (10 elementos) - Original");
            Console.WriteLine("3. Grande (20 elementos)");
            Console.WriteLine("4. Ya ordenado (para probar búsqueda)");
            Console.WriteLine("5. Orden inverso (peor caso para algunos algoritmos)");
            Console.Write("Elige una opción: ");

            // Leemos la opción del usuario
            var choice = Console.ReadLine();
            
            // SWITCH: Dependiendo de la opción, cargamos diferentes datos
            // Es como un "menú de restaurante", eliges un plato y te lo preparan
            switch (choice)
            {
                case "1":
                    // Conjunto pequeño: Solo 5 elementos
                    // Perfecto para ver paso a paso sin que sea muy largo
                    _data = new int[] { 64, 34, 25, 12, 22 };
                    break;  // "break" sale del switch
                    
                case "2":
                    // Conjunto mediano: El original del programa (9 elementos)
                    // Buenos para demostraciones generales
                    _data = new int[] { 42, 23, 16, 8, 4, 15, 108, 55, 31 };
                    break;
                    
                case "3":
                    // Conjunto grande: 20 elementos
                    // Útil para ver diferencias de rendimiento entre algoritmos
                    _data = new int[] { 89, 12, 45, 67, 23, 90, 34, 78, 56, 11, 99, 3, 88, 44, 22, 66, 77, 33, 55, 1 };
                    break;
                    
                case "4":
                    // Ya ordenado de menor a mayor
                    // Útil para:
                    // - Probar búsqueda binaria directamente
                    // - Ver el "mejor caso" de algoritmos de ordenamiento
                    _data = new int[] { 1, 5, 10, 15, 20, 25, 30, 35, 40, 45 };
                    break;
                    
                case "5":
                    // Orden inverso (de mayor a menor)
                    // Este es el "peor caso" para algoritmos como Bubble Sort
                    // porque tiene que hacer muchos intercambios
                    _data = new int[] { 100, 90, 80, 70, 60, 50, 40, 30, 20, 10 };
                    break;
                    
                default:
                    // Si el usuario ingresó algo diferente a 1-5
                    Console.WriteLine("Opción no válida. Manteniendo datos actuales.");
                    return;  // Salimos sin cambiar los datos
            }

            // Si llegamos aquí, es porque se cargó un conjunto exitosamente
            Console.WriteLine("\n¡Datos predefinidos cargados!");
            ShowCurrentData();
        }

        /// <summary>
        /// Restaura los datos al conjunto predeterminado original
        /// 
        /// ¿Qué hace este método?
        /// Vuelve a cargar el arreglo original que trae el programa por defecto.
        /// Es como un botón de "reiniciar" o "restaurar valores de fábrica".
        /// 
        /// Útil cuando:
        /// - Has hecho muchos cambios y quieres volver al inicio
        /// - Quieres usar los datos conocidos y probados
        /// </summary>
        public void ResetToDefault()
        {
            // Restauramos el arreglo original
            _data = new int[] { 42, 23, 16, 8, 4, 15, 108, 55, 31 };
            
            // Informamos al usuario que se restauró
            Console.WriteLine("\n¡Datos restaurados al conjunto predeterminado!");
            
            // Mostramos los datos restaurados
            ShowCurrentData();
        }
    }
}
