
// ========================================================================================================
// DIRECTIVAS DE USO (USING) - Son como "importar librerías" en otros lenguajes
// ========================================================================================================
// Estas líneas le dicen a C# qué funcionalidades queremos usar en nuestro programa.
// Es como cuando dices "voy a usar la calculadora" antes de hacer operaciones matemáticas.

using System; // Nos da acceso a funciones básicas como Console.WriteLine para imprimir en pantalla,
             // DateTime para trabajar con fechas/horas, Array para manipular arreglos, etc.

using System.Collections.Generic; // Nos permite usar colecciones modernas como List<T>.
                                  // Un List es como un arreglo que puede crecer o encogerse automáticamente.
                                  // "Generic" significa que puede almacenar cualquier tipo de dato (int, string, etc.)

// ========================================================================================================
// NAMESPACE (ESPACIO DE NOMBRES)
// ========================================================================================================
// Es como el "apellido" del proyecto. Agrupa todas las clases relacionadas para evitar confusiones.
// Si dos proyectos tienen una clase llamada "Program", el namespace ayuda a diferenciarlas:
//    - ProyectoA.Program
//    - ProyectoB.Program
namespace MetodosAlgoritmicosyBusqueda
{
    // ====================================================================================================
    // CLASE PROGRAM - El "Punto de Entrada" del Programa
    // ====================================================================================================
    // Esta es la clase principal que C# busca cuando ejecuta el programa.
    // Contiene el método Main() que es el primer método que se ejecuta.
    // 
    // Piensa en esto como la "recepción" de un edificio: es donde todos entran primero,
    // y desde ahí se les dirige a diferentes lugares (métodos).
    class Program
    {
        // ================================================================================================
        // CAMPOS ESTÁTICOS (STATIC FIELDS) - Variables Compartidas por Todo el Programa
        // ================================================================================================
        // "static" significa que estas variables pertenecen a la CLASE, no a objetos individuales.
        // Hay UNA SOLA COPIA de estas variables que todos los métodos comparten.
        //
        // Es como un pizarrón en un salón de clases: todos los estudiantes (métodos) pueden verlo
        // y modificarlo, y hay solo UN pizarrón para todos.
        
        // DATAMANAGER: Administrador de datos del arreglo
        // Este objeto guarda el arreglo de números que vamos a ordenar y buscar.
        // Lo creamos UNA VEZ al inicio y lo usamos en todos los menús.
        static DataManager dataManager = new DataManager();

        // SORTERS: Lista de métodos algorítmicos disponibles
        // 
        // List<ISorter> es una LISTA que contiene objetos que implementan la interfaz ISorter.
        // Es como tener una lista de empleados, donde cada uno sabe hacer su trabajo específico.
        //
        // ¿Por qué usar una lista?
        // - Fácil de recorrer con un ciclo for para mostrar opciones al usuario
        // - Fácil de expandir: si queremos agregar más algoritmos, solo los agregamos aquí
        // - El código del menú no cambia, solo esta lista
        //
        // La sintaxis { } se llama "inicializador de colección":
        // Es una forma corta de agregar elementos a la lista al crearla.
        static List<ISorter> Sorters = new List<ISorter>
        {
            new HeapSorter(),        // Algoritmo 1: Heapsort (ordenamiento por montículo)
            new MergeSorter(),       // Algoritmo 2: MergeSort (ordenamiento por mezcla - divide y conquista)
            new QuickSorter()        // Algoritmo 3: Quicksort (ordenamiento rápido - divide y conquista con pivote)
        };

        // SEARCHERS: Lista de algoritmos de búsqueda disponibles
        // 
        // Similar a Sorters, pero para algoritmos de búsqueda.
        // Cada algoritmo sabe buscar un número en un arreglo de manera diferente:
        // - InterpolationSearcher: estima la posición basándose en el valor (requiere orden)
        // - HashSearcher: usa tabla hash para acceso instantáneo (no requiere orden)
        static List<ISearcher> Searchers = new List<ISearcher>
        {
            new InterpolationSearcher(),  // Búsqueda por Interpolación: rápida con datos uniformes
            new HashSearcher()            // Búsqueda por Hash: ultra rápida con tabla hash
        };

        // ================================================================================================
        // MÉTODO MAIN - El Punto de Inicio del Programa
        // ================================================================================================
        // Este es el método MÁS IMPORTANTE de cualquier programa en C#.
        // Cuando ejecutas el programa, C# busca este método Main y empieza a ejecutarlo.
        //
        // Piensa en Main como el "director de una orquesta":
        // - Coordina todo el programa
        // - Llama a otros métodos cuando los necesita
        // - Mantiene el programa corriendo hasta que el usuario decide salir
        //
        // "static" = pertenece a la clase Program, no a objetos individuales
        // "void" = no devuelve ningún valor (otros métodos pueden devolver int, string, etc.)
        // "Main" = nombre especial que C# reconoce como punto de entrada
        // "string[] args" = parámetro que recibe argumentos de línea de comandos (no lo usamos aquí)
        static void Main(string[] args)
        {
            // ============================================================================================
            // BUCLE INFINITO (WHILE TRUE) - El "Corazón" del Programa
            // ============================================================================================
            // while (true) significa "repite esto para siempre... hasta que usemos 'return' para salir"
            //
            // ¿Por qué un bucle infinito?
            // Porque queremos que el programa muestre el menú, el usuario elija una opción,
            // se ejecute esa opción, y luego VUELVA al menú automáticamente.
            //
            // El programa solo se detiene cuando el usuario elige "4. Salir" y ejecutamos "return".
            //
            // Es como un menú de restaurante:
            // 1. Muestras el menú al cliente
            // 2. El cliente ordena algo
            // 3. Le das lo que pidió
            // 4. Vuelves a mostrar el menú por si quiere ordenar algo más
            // 5. Solo te vas cuando el cliente dice "ya no quiero nada más"
            while (true)
            {
                // ========================================================================================
                // MOSTRAR EL MENÚ PRINCIPAL
                // ========================================================================================
                
                // Console.Clear() - Limpia la pantalla de la consola
                // Es como borrar un pizarrón antes de escribir algo nuevo.
                // Hace que la interfaz se vea más limpia y organizada.
                Console.Clear();
                
                // Console.WriteLine() - Imprime texto en la consola y salta a la siguiente línea
                // Es la forma de "hablar" con el usuario, mostrarle información en pantalla.
                Console.WriteLine("=============================================");
                Console.WriteLine("   Herramienta Educativa de Algoritmos (OOP)");
                Console.WriteLine("=============================================");
                
                // Mostrar los datos actuales del arreglo
                // Llamamos al método ShowCurrentData() del objeto dataManager.
                // El punto (.) significa "accede a este método/propiedad del objeto"
                dataManager.ShowCurrentData();
                
                // \n significa "nueva línea" (salto de línea)
                // Es como presionar Enter en un editor de texto.
                Console.WriteLine("\nMenú Principal:");
                Console.WriteLine("1. Métodos Algorítmicos");
                Console.WriteLine("2. Métodos de Búsqueda");
                Console.WriteLine("3. Gestionar Datos (Personalizar arreglo)");
                Console.WriteLine("4. Salir");
                
                // Console.Write() - Similar a WriteLine pero NO salta de línea
                // Útil cuando queremos que el usuario escriba en la misma línea
                Console.Write("\nPor favor, elige una opción: ");

                // ========================================================================================
                // LEER LA OPCIÓN DEL USUARIO
                // ========================================================================================
                
                // Console.ReadLine() - Lee una línea completa que el usuario escribe y presiona Enter
                // Devuelve un string (texto) con lo que el usuario escribió
                //
                // "var choice" - declaramos una variable llamada "choice" (elección)
                // "var" le dice a C# "tú decides el tipo de dato basándote en lo que le asigno"
                // En este caso, C# detecta que es un string porque ReadLine() devuelve string
                var choice = Console.ReadLine();

                // ========================================================================================
                // ESTRUCTURA SWITCH - "Interruptor de Opciones"
                // ========================================================================================
                // El switch es como un tablero de interruptores donde cada interruptor hace algo diferente.
                // Comparamos la variable "choice" con varios valores posibles (cases).
                // Cuando encuentra una coincidencia, ejecuta ese bloque de código.
                //
                // Es MÁS LIMPIO que escribir:
                //    if (choice == "1") { ... }
                //    else if (choice == "2") { ... }
                //    else if (choice == "3") { ... }
                //    ...
                //
                // El switch hace lo mismo pero es más fácil de leer cuando hay muchas opciones.
                switch (choice)
                {
                    case "1":  // Si el usuario escribió "1"
                        ShowSortingMenu();  // Llamamos al método que muestra el menú de métodos algorítmicos
                        break;  // "break" significa "sal del switch, ya terminamos este caso"
                                // Sin break, el código seguiría ejecutando los casos siguientes
                    
                    case "2":  // Si el usuario escribió "2"
                        ShowSearchMenu();   // Llamamos al método que muestra el menú de búsqueda
                        break;
                    
                    case "3":  // Si el usuario escribió "3"
                        ShowDataManagementMenu();  // Llamamos al método de gestión de datos
                        break;
                    
                    case "4":  // Si el usuario escribió "4" (quiere salir)
                        Console.WriteLine("\n¡Hasta luego! Gracias por usar la herramienta educativa.");
                        
                        // "return" - TERMINA la ejecución del método Main
                        // Como Main es el método principal, terminar Main = terminar el programa
                        // Es la única forma de salir del bucle "while (true)"
                        return;
                    
                    default:   // Si no coincide con ningún case anterior (opción inválida)
                        // "default" es como el "else" del switch: se ejecuta si ningún case coincidió
                        Console.WriteLine("Opción no válida. Presiona Enter para continuar.");
                        Console.ReadLine();  // Esperar a que el usuario presione Enter
                        break;  // Volver al inicio del bucle while y mostrar el menú de nuevo
                }
            }  // Fin del while (true) - vuelve al inicio del bucle para mostrar el menú otra vez
        }  // Fin del método Main

        // ================================================================================================
        // MÉTODO SHOWSORTINGMENU - Menú de Métodos Algorítmicos
        // ================================================================================================
        // Este método se encarga de mostrar las opciones de métodos algorítmicos al usuario,
        // permitirle elegir un algoritmo, y ejecutarlo.
        //
        // "static" = puede ser llamado sin crear un objeto de la clase Program
        // "void" = no devuelve ningún valor (solo hace acciones y muestra resultados)
        static void ShowSortingMenu()
        {
            // Otro bucle infinito, igual que en Main
            // Se repite hasta que el usuario elija "Volver al menú principal"
            while (true)
            {
                // ========================================================================================
                // MOSTRAR MENÚ DE MÉTODOS ALGORÍTMICOS
                // ========================================================================================
                Console.Clear();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("          Métodos Algorítmicos");
                Console.WriteLine("---------------------------------------------");
                dataManager.ShowCurrentData();
                Console.WriteLine();
                
                // ========================================================================================
                // CICLO FOR - Mostrar Todos los Algoritmos Disponibles
                // ========================================================================================
                // Este ciclo recorre la lista "Sorters" y muestra cada algoritmo numerado.
                //
                // "for" es un ciclo que se repite un número específico de veces.
                // Componentes:
                //   - int i = 0           → Inicialización: empezamos en 0 (primer índice de la lista)
                //   - i < Sorters.Count   → Condición: seguir mientras i sea menor que la cantidad de algoritmos
                //   - i++                 → Incremento: después de cada vuelta, aumentar i en 1
                //
                // Sorters.Count es una PROPIEDAD que nos dice cuántos elementos tiene la lista.
                // Si tenemos 3 algoritmos, el ciclo se ejecutará con i=0, i=1, i=2
                for (int i = 0; i < Sorters.Count; i++)
                {
                    // INTERPOLACIÓN DE STRINGS con $"..."
                    // El símbolo $ antes de las comillas permite insertar variables dentro del texto usando { }
                    // 
                    // {i + 1} - mostramos el número de opción (empezando en 1, no en 0)
                    //           i=0 muestra "1", i=1 muestra "2", etc.
                    //           Sumamos 1 porque para los usuarios es más natural empezar en 1
                    //
                    // {Sorters[i].Name} - accedemos al elemento i de la lista Sorters
                    //                     y mostramos su propiedad Name
                    //                     Sorters[0] es BubbleSorter, Sorters[1] es InsertionSorter, etc.
                    Console.WriteLine($"{i + 1}. {Sorters[i].Name}");
                }
                
                // Mostrar opción para volver al menú principal
                // Sorters.Count + 1 = si hay 2 algoritmos, esta será la opción 3
                Console.WriteLine($"{Sorters.Count + 1}. Volver al menú principal");
                Console.Write("\nElige un método algorítmico: ");

                // ========================================================================================
                // VALIDAR LA ENTRADA DEL USUARIO
                // ========================================================================================
                var choice = Console.ReadLine();
                
                // int.TryParse() - Intenta convertir el texto a un número entero (int)
                // 
                // ¿Por qué TryParse y no Parse?
                // - Parse lanza un ERROR si el texto no es un número (ej: si el usuario escribe "abc")
                // - TryParse es más seguro: devuelve true si logró convertir, false si no pudo
                //
                // "out int idx" - palabra clave "out" significa que TryParse va a crear/modificar
                //                 la variable idx y guardar ahí el número convertido
                //
                // Operador || significa OR (O lógico):
                // La condición completa es verdadera si CUALQUIERA de estas es verdadera:
                //   1. !int.TryParse(...) → el signo ! invierte: true si NO se pudo convertir a número
                //   2. idx < 1 → el número es menor que 1 (opción inválida)
                //   3. idx > Sorters.Count + 1 → el número es mayor que la última opción
                if (!int.TryParse(choice, out int idx) || idx < 1 || idx > Sorters.Count + 1)
                {
                    Console.WriteLine("Opción no válida. Presiona Enter.");
                    Console.ReadLine();
                    
                    // "continue" - salta al inicio del bucle while inmediatamente
                    // Es como decir "ignora todo lo que viene después y vuelve a empezar el ciclo"
                    // En este caso, vuelve a mostrar el menú de métodos algorítmicos
                    continue;
                }
                
                // Si el usuario eligió la opción "Volver al menú principal"
                // "return" sale del método ShowSortingMenu y vuelve a Main
                if (idx == Sorters.Count + 1) return;

                // ========================================================================================
                // PREPARAR LA EJECUCIÓN DEL ALGORITMO
                // ========================================================================================
                
                // Obtener el algoritmo seleccionado de la lista
                // idx - 1 porque el usuario ve opciones 1, 2, 3... pero la lista usa índices 0, 1, 2...
                // Si el usuario eligió "1", queremos Sorters[0]
                // Si eligió "2", queremos Sorters[1], etc.
                var sorter = Sorters[idx - 1];
                
                // Obtener una copia del arreglo original (sin modificar)
                // Esto es útil para comparar el "antes" y "después" del ordenamiento
                var originalData = dataManager.GetOriginalData();
                
                // Obtener una copia del arreglo para ordenar
                // ¿Por qué una copia? Porque al ordenar modificamos el arreglo.
                // Si trabajáramos directamente con el original, no podríamos ver cómo estaba antes.
                var copy = dataManager.GetData();

                // ========================================================================================
                // MOSTRAR INFORMACIÓN Y PREPARAR VISUALIZACIÓN
                // ========================================================================================
                Console.Clear();
                Console.WriteLine($"========================================");
                Console.WriteLine($"   Ejecutando {sorter.Name}");
                Console.WriteLine($"========================================");
                Console.WriteLine("\nArreglo original:");
                
                // Llamar a un método estático de la clase ArrayPrinter
                // No necesitamos crear un objeto ArrayPrinter, solo usamos la clase directamente
                // porque el método Print() es static
                ArrayPrinter.Print(originalData);

                // Preguntar al usuario si quiere ver el ordenamiento paso a paso
                // Esto configura una variable global en VisualizationHelper
                VisualizationHelper.AskForStepByStepMode();

                // ========================================================================================
                // EJECUTAR EL ALGORITMO Y MEDIR EL TIEMPO
                // ========================================================================================
                Console.WriteLine("\n--- Iniciando ordenamiento ---");
                
                // DateTime.Now obtiene la fecha y hora actual del sistema
                // Lo guardamos ANTES de ordenar para calcular cuánto tiempo tarda
                var startTime = DateTime.Now;
                
                // ¡AQUÍ OCURRE LA MAGIA!
                // Llamamos al método Sort() del algoritmo seleccionado.
                // Gracias al POLIMORFISMO, no importa si es BubbleSorter, InsertionSorter o QuickSorter,
                // todos tienen el método Sort() porque implementan la interfaz ISorter.
                // El algoritmo ordena el arreglo "copy" (lo modifica directamente).
                sorter.Sort(copy);
                
                // Obtener la hora actual DESPUÉS de ordenar
                // Restar startTime nos da cuánto tiempo pasó (un objeto TimeSpan)
                var elapsed = DateTime.Now - startTime;

                // ========================================================================================
                // MOSTRAR RESULTADOS
                // ========================================================================================
                Console.WriteLine("\n========================================");
                Console.WriteLine("Arreglo ordenado:");
                ArrayPrinter.Print(copy);  // Mostrar el arreglo ya ordenado
                
                // {elapsed.TotalMilliseconds:F2} - Formato especial para números
                // TotalMilliseconds = convierte el tiempo a milisegundos (1 segundo = 1000 ms)
                // :F2 = muestra el número con 2 decimales (ej: 45.67 ms)
                Console.WriteLine($"Tiempo de ejecución: {elapsed.TotalMilliseconds:F2} ms");
                Console.WriteLine("========================================");

                // ========================================================================================
                // PREGUNTAR SI QUIERE GUARDAR LOS CAMBIOS
                // ========================================================================================
                // A veces el usuario solo quiere VER cómo funciona el algoritmo, no cambiar los datos.
                // Por eso preguntamos si quiere guardar el arreglo ordenado.
                Console.WriteLine("\n¿Deseas guardar este arreglo ordenado como datos actuales? (s/n): ");
                
                // Operador ?. (null-conditional operator) - "Operador condicional nulo"
                // Si ReadLine() devuelve null (no debería, pero por seguridad), ?. evita un error
                // ToLower() convierte el texto a minúsculas para que "S", "s", "SI", etc. funcionen igual
                var save = Console.ReadLine()?.ToLower();
                
                // Operador || (OR) - Si CUALQUIERA de estas condiciones es verdadera, ejecuta el if
                // Aceptamos "s", "si", "sí" como respuestas afirmativas
                if (save == "s" || save == "si" || save == "sí")
                {
                    // Array.Copy() - Método estático que copia elementos de un arreglo a otro
                    // Parámetros:
                    //   - copy: arreglo fuente (de dónde copiar)
                    //   - originalData: arreglo destino (a dónde copiar)
                    //   - copy.Length: cuántos elementos copiar (todos en este caso)
                    //
                    // Esto REEMPLAZA el arreglo original con el ordenado
                    Array.Copy(copy, originalData, copy.Length);
                    Console.WriteLine("¡Datos actualizados!");
                }

                Console.WriteLine("\nPresiona Enter para volver al menú de métodos algorítmicos.");
                Console.ReadLine();
            }  // Fin del while(true) - vuelve a mostrar el menú de métodos algorítmicos
        }  // Fin del método ShowSortingMenu

        // ================================================================================================
        // MÉTODO SHOWDATAMANAGEMENTMENU - Menú de Gestión de Datos
        // ================================================================================================
        // Este método permite al usuario personalizar el arreglo de números que se usará
        // para demostrar los algoritmos de ordenamiento y búsqueda.
        //
        // El usuario puede:
        // - Ver los datos actuales
        // - Generar números aleatorios
        // - Escribir sus propios números
        // - Usar conjuntos de datos de ejemplo (pequeño, grande, ordenado, al revés, etc.)
        // - Restaurar los datos originales del programa
        static void ShowDataManagementMenu()
        {
            // Bucle infinito hasta que el usuario elija "Volver al menú principal"
            while (true)
            {
                // ========================================================================================
                // MOSTRAR MENÚ DE GESTIÓN DE DATOS
                // ========================================================================================
                Console.Clear();
                Console.WriteLine("=============================================");
                Console.WriteLine("       Gestión de Datos del Arreglo");
                Console.WriteLine("=============================================");
                dataManager.ShowCurrentData();
                Console.WriteLine("\nOpciones:");
                Console.WriteLine("1. Ver datos actuales");
                Console.WriteLine("2. Generar datos aleatorios");
                Console.WriteLine("3. Ingresar datos manualmente");
                Console.WriteLine("4. Usar conjunto de datos predefinido");
                Console.WriteLine("5. Restaurar datos predeterminados");
                Console.WriteLine("6. Volver al menú principal");
                Console.Write("\nElige una opción: ");

                var choice = Console.ReadLine();

                // ========================================================================================
                // SWITCH - Ejecutar la Acción Elegida por el Usuario
                // ========================================================================================
                // Cada case llama a un método diferente de dataManager para gestionar los datos.
                // Después de cada acción, esperamos a que el usuario presione Enter antes de
                // volver a mostrar el menú.
                switch (choice)
                {
                    case "1":  // Ver datos actuales
                        // Simplemente muestra el arreglo actual en la pantalla
                        dataManager.ShowCurrentData();
                        Console.WriteLine("\nPresiona Enter para continuar.");
                        Console.ReadLine();  // Pausa para que el usuario vea los datos antes de volver al menú
                        break;
                    
                    case "2":  // Generar datos aleatorios
                        // Le pide al usuario cuántos números quiere y en qué rango (min-max)
                        // Luego genera números aleatorios y reemplaza el arreglo actual
                        dataManager.GenerateRandomData();
                        Console.WriteLine("\nPresiona Enter para continuar.");
                        Console.ReadLine();
                        break;
                    
                    case "3":  // Ingresar datos manualmente
                        // Le pide al usuario que escriba cada número uno por uno
                        // Útil cuando quieres probar el algoritmo con números específicos
                        dataManager.EnterManualData();
                        Console.WriteLine("\nPresiona Enter para continuar.");
                        Console.ReadLine();
                        break;
                    
                    case "4":  // Usar conjunto de datos predefinido
                        // Muestra opciones de conjuntos de ejemplo:
                        // - Pequeño (10 números) para demostraciones rápidas
                        // - Mediano (20) para ver más detalles
                        // - Grande (50) para ver diferencias de rendimiento
                        // - Ordenado (para probar caso óptimo)
                        // - Invertido (para probar caso peor)
                        dataManager.UsePresetData();
                        Console.WriteLine("\nPresiona Enter para continuar.");
                        Console.ReadLine();
                        break;
                    
                    case "5":  // Restaurar datos predeterminados
                        // Vuelve al arreglo original con el que empezó el programa
                        dataManager.ResetToDefault();
                        Console.WriteLine("\nPresiona Enter para continuar.");
                        Console.ReadLine();
                        break;
                    
                    case "6":  // Volver al menú principal
                        // return sale del método ShowDataManagementMenu y regresa a Main
                        return;
                    
                    default:  // Opción inválida
                        Console.WriteLine("Opción no válida. Presiona Enter.");
                        Console.ReadLine();
                        break;
                }
            }  // Fin del while(true) - vuelve a mostrar el menú de gestión de datos
        }  // Fin del método ShowDataManagementMenu

        // ================================================================================================
        // MÉTODO SHOWSEARCHMENU - Menú de Algoritmos de Búsqueda
        // ================================================================================================
        // Este método permite al usuario elegir un algoritmo de búsqueda (Lineal o Binaria),
        // buscar un número específico en el arreglo, y ver si se encuentra o no.
        //
        // Diferencia importante con el ordenamiento:
        // - Ordenamiento MODIFICA el arreglo (lo ordena)
        // - Búsqueda NO modifica el arreglo (solo busca un elemento)
        static void ShowSearchMenu()
        {
            // Bucle infinito hasta que el usuario elija "Volver al menú principal"
            while (true)
            {
                // ========================================================================================
                // MOSTRAR MENÚ DE BÚSQUEDA
                // ========================================================================================
                Console.Clear();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("           Métodos de Búsqueda");
                Console.WriteLine("-----------------------------------------");
                dataManager.ShowCurrentData();
                Console.WriteLine();
                
                // Ciclo for para mostrar todos los algoritmos de búsqueda disponibles
                // Similar al menú de ordenamiento
                for (int i = 0; i < Searchers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Searchers[i].Name}");
                }
                Console.WriteLine($"{Searchers.Count + 1}. Volver al menú principal");
                Console.Write("\nElige un algoritmo de búsqueda: ");

                // ========================================================================================
                // VALIDAR ELECCIÓN DEL ALGORITMO
                // ========================================================================================
                var choice = Console.ReadLine();
                if (!int.TryParse(choice, out int idx) || idx < 1 || idx > Searchers.Count + 1)
                {
                    Console.WriteLine("Opción no válida. Presiona Enter.");
                    Console.ReadLine();
                    continue;
                }
                if (idx == Searchers.Count + 1) return;  // Volver al menú principal

                // ========================================================================================
                // PEDIR EL NÚMERO A BUSCAR
                // ========================================================================================
                // En búsqueda, necesitamos saber QUÉ queremos buscar (a diferencia del ordenamiento
                // que simplemente ordena todos los elementos)
                Console.Write("\nPor favor, ingresa el número que deseas buscar: ");
                
                // TryParse valida que el usuario haya escrito un número válido
                // Si escribe texto o deja vacío, numberToSearch no se crea y mostramos error
                if (!int.TryParse(Console.ReadLine(), out int numberToSearch))
                {
                    Console.WriteLine("Entrada no válida. Debes ingresar un número.");
                    Console.ReadLine();
                    continue;  // Volver a mostrar el menú de búsqueda
                }

                // ========================================================================================
                // PREPARAR LA BÚSQUEDA
                // ========================================================================================
                
                // Obtener el algoritmo de búsqueda seleccionado
                // idx - 1 para convertir de "opción del usuario" a "índice de lista"
                var searcher = Searchers[idx - 1];
                
                Console.Clear();
                Console.WriteLine($"========================================");
                Console.WriteLine($"   Ejecutando {searcher.Name}");
                Console.WriteLine($"========================================");
                Console.WriteLine($"\nBuscando el número: {numberToSearch}");

                // Obtener referencias al arreglo
                var originalData = dataManager.GetOriginalData();
                int[] working = dataManager.GetData();
                
                // ========================================================================================
                // VERIFICAR SI EL ALGORITMO REQUIERE DATOS ORDENADOS
                // ========================================================================================
                // Algunos algoritmos de búsqueda (como Búsqueda Binaria) SOLO funcionan correctamente
                // si el arreglo está ordenado. Otros (como Búsqueda Lineal) funcionan sin importar el orden.
                //
                // RequiresSorted es una propiedad de la interfaz ISearcher que nos dice esto.
                if (searcher.RequiresSorted)
                {
                    // Este algoritmo necesita el arreglo ordenado
                    Console.WriteLine("\n⚠ Este algoritmo requiere un arreglo ordenado.");
                    Console.Write("¿Deseas ordenar el arreglo primero? (s/n): ");
                    var sortChoice = Console.ReadLine()?.ToLower();
                    
                    if (sortChoice == "s" || sortChoice == "si" || sortChoice == "sí")
                    {
                        // Array.Sort() es un método estático de la clase Array
                        // Ordena el arreglo "working" automáticamente (modifica el arreglo original)
                        // Usa un algoritmo de ordenamiento eficiente (generalmente QuickSort o IntroSort)
                        Array.Sort(working);
                        Console.WriteLine("\nArreglo ordenado para la búsqueda:");
                        ArrayPrinter.Print(working);
                    }
                    else
                    {
                        // El usuario decidió NO ordenar
                        // Advertimos que el resultado puede ser incorrecto
                        // (Búsqueda Binaria puede no encontrar un elemento que SÍ existe si no está ordenado)
                        Console.WriteLine("\n⚠ Advertencia: El resultado puede no ser correcto en un arreglo desordenado.");
                        Console.WriteLine("Arreglo actual (sin ordenar):");
                        ArrayPrinter.Print(working);
                    }
                }
                else
                {
                    // Este algoritmo NO requiere orden (ej: Búsqueda Lineal)
                    // Simplemente mostramos el arreglo actual
                    Console.WriteLine("\nBuscando en el arreglo actual:");
                    ArrayPrinter.Print(working);
                }

                // ========================================================================================
                // EJECUTAR LA BÚSQUEDA Y MEDIR EL TIEMPO
                // ========================================================================================
                Console.WriteLine("\n--- Iniciando búsqueda ---");
                
                // Capturar el tiempo antes de buscar
                var startTime = DateTime.Now;
                
                // ¡AQUÍ OCURRE LA BÚSQUEDA!
                // Llamamos al método Search() del algoritmo seleccionado.
                // Parámetros:
                //   - working: el arreglo donde buscar
                //   - numberToSearch: el número que queremos encontrar
                //
                // Valor de retorno:
                //   - Si encuentra el número: devuelve el ÍNDICE donde está (0, 1, 2, ...)
                //   - Si NO lo encuentra: devuelve -1
                //
                // Ejemplo: Si el arreglo es [10, 20, 30] y buscamos 20, devuelve 1
                //          Si buscamos 99, devuelve -1 (no existe)
                var foundIndex = searcher.Search(working, numberToSearch);
                
                // Capturar el tiempo después de buscar y calcular la diferencia
                var elapsed = DateTime.Now - startTime;

                // ========================================================================================
                // MOSTRAR RESULTADOS DE LA BÚSQUEDA
                // ========================================================================================
                Console.WriteLine("\n========================================");
                
                // Verificar si se encontró el número
                // -1 significa "no encontrado" (convención estándar en programación)
                if (foundIndex != -1)
                {
                    // ¡SÍ SE ENCONTRÓ!
                    
                    // Console.ForegroundColor - Cambia el color del texto en la consola
                    // ConsoleColor.Green = texto verde (color de "éxito" o "correcto")
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"✓ ¡ENCONTRADO!");
                    
                    // Console.ResetColor() - Vuelve al color por defecto de la consola
                    // IMPORTANTE: siempre resetear el color después de cambiarlo,
                    // sino TODO el texto siguiente saldrá en ese color
                    Console.ResetColor();
                    
                    Console.WriteLine($"El número {numberToSearch} está en el índice {foundIndex}");
                    
                    // Mostrar el valor en esa posición (debería ser igual a numberToSearch)
                    // Es una verificación adicional de que encontramos lo correcto
                    Console.WriteLine($"Valor en esa posición: {working[foundIndex]}");
                    
                    // Si ordenamos el arreglo para la búsqueda, el índice que encontramos
                    // es diferente al índice original (antes de ordenar)
                    // Mostramos ambos índices para que el usuario entienda la diferencia
                    //
                    // SequenceEqual() - Compara dos arreglos elemento por elemento
                    // Devuelve true solo si son exactamente iguales (mismo orden, mismos valores)
                    if (searcher.RequiresSorted && !working.SequenceEqual(originalData))
                    {
                        // Array.IndexOf() - Busca un elemento en un arreglo y devuelve su índice
                        // Similar a Search(), pero más simple (no usa algoritmos sofisticados)
                        var originalIndex = Array.IndexOf(originalData, numberToSearch);
                        Console.WriteLine($"Índice en el arreglo original (sin ordenar): {originalIndex}");
                    }
                }
                else
                {
                    // NO SE ENCONTRÓ
                    
                    // ConsoleColor.Red = texto rojo (color de "error" o "no encontrado")
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"✗ NO ENCONTRADO");
                    Console.ResetColor();
                    
                    Console.WriteLine($"El número {numberToSearch} no existe en el arreglo.");
                }
                
                // Mostrar el tiempo que tardó la búsqueda
                // :F4 = muestra 4 decimales (ej: 0.0012 ms)
                // Las búsquedas suelen ser muy rápidas, por eso mostramos más decimales
                Console.WriteLine($"Tiempo de búsqueda: {elapsed.TotalMilliseconds:F4} ms");
                Console.WriteLine("========================================");

                Console.WriteLine("\nPresiona Enter para volver al menú de búsqueda.");
                Console.ReadLine();
            }  // Fin del while(true) - vuelve a mostrar el menú de búsqueda
        }  // Fin del método ShowSearchMenu
    }  // Fin de la clase Program
}  // Fin del namespace MetodosAlgoritmicosyBusqueda

// ========================================================================================================
// FIN DEL PROGRAMA
// ========================================================================================================
// ¡Felicidades por llegar hasta aquí!
// 
// Este programa demuestra conceptos importantes de Programación Orientada a Objetos:
// - INTERFACES: ISorter, ISearcher (contratos que definen qué métodos deben tener las clases)
// - POLIMORFISMO: podemos usar diferentes algoritmos de forma intercambiable
// - ENCAPSULACIÓN: cada clase maneja sus propios datos y métodos
// - SEPARACIÓN DE RESPONSABILIDADES: cada clase tiene un propósito específico
//
// Estructura del proyecto:
// - Program.cs: Punto de entrada, menús, coordinación general
// - Sort/: Clases de algoritmos de ordenamiento
// - Search/: Clases de algoritmos de búsqueda  
// - Utils/: Clases auxiliares (imprimir, visualizar, gestionar datos)
//
// ¡Ahora eres capaz de entender y modificar este programa completo!
