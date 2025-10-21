
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

        // SORTERS: Lista de algoritmos de ordenamiento disponibles
        // 
        // List<ISorter> es una LISTA que contiene objetos que implementan la interfaz ISorter.
        // Es como tener una lista de empleados, donde cada uno sabe hacer su trabajo específico.
        //
        // ¿Por qué usar una lista?
        // - Fácil de recorrer con un ciclo for para mostrar opciones al usuario
        // - Fácil de expandir: si queremos agregar MergeSorter, solo lo agregamos aquí
        // - El código del menú no cambia, solo esta lista
        //
        // La sintaxis { } se llama "inicializador de colección":
        // Es una forma corta de agregar elementos a la lista al crearla.
        static List<ISorter> Sorters = new List<ISorter>
        {
            new BubbleSorter(),      // Algoritmo 1: Burbuja (lento pero fácil de entender)
            new InsertionSorter(),   // Algoritmo 2: Inserción (bueno para listas casi ordenadas)
            new QuickSorter()        // Algoritmo 3: Quicksort (rápido para listas grandes)
        };

        // SEARCHERS: Lista de algoritmos de búsqueda disponibles
        // 
        // Similar a Sorters, pero para algoritmos de búsqueda.
        // Cada algoritmo sabe buscar un número en un arreglo de manera diferente:
        // - LinearSearcher: revisa elemento por elemento (no requiere orden)
        // - BinarySearcher: divide el arreglo a la mitad repetidamente (REQUIERE orden)
        static List<ISearcher> Searchers = new List<ISearcher>
        {
            new LinearSearcher(),    // Búsqueda Lineal: simple pero puede ser lenta
            new BinarySearcher()     // Búsqueda Binaria: rápida pero necesita datos ordenados
        };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=============================================");
                Console.WriteLine("   Herramienta Educativa de Algoritmos (OOP)");
                Console.WriteLine("=============================================");
                dataManager.ShowCurrentData();
                Console.WriteLine("\nMenú Principal:");
                Console.WriteLine("1. Métodos de Ordenamiento");
                Console.WriteLine("2. Métodos de Búsqueda");
                Console.WriteLine("3. Gestionar Datos (Personalizar arreglo)");
                Console.WriteLine("4. Salir");
                Console.Write("\nPor favor, elige una opción: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowSortingMenu();
                        break;
                    case "2":
                        ShowSearchMenu();
                        break;
                    case "3":
                        ShowDataManagementMenu();
                        break;
                    case "4":
                        Console.WriteLine("\n¡Hasta luego! Gracias por usar la herramienta educativa.");
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Presiona Enter para continuar.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void ShowSortingMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("          Métodos de Ordenamiento");
                Console.WriteLine("---------------------------------------------");
                dataManager.ShowCurrentData();
                Console.WriteLine();
                for (int i = 0; i < Sorters.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Sorters[i].Name}");
                }
                Console.WriteLine($"{Sorters.Count + 1}. Volver al menú principal");
                Console.Write("\nElige un algoritmo de ordenamiento: ");

                var choice = Console.ReadLine();
                if (!int.TryParse(choice, out int idx) || idx < 1 || idx > Sorters.Count + 1)
                {
                    Console.WriteLine("Opción no válida. Presiona Enter.");
                    Console.ReadLine();
                    continue;
                }
                if (idx == Sorters.Count + 1) return;

                var sorter = Sorters[idx - 1];
                var originalData = dataManager.GetOriginalData();
                var copy = dataManager.GetData();

                Console.Clear();
                Console.WriteLine($"========================================");
                Console.WriteLine($"   Ejecutando {sorter.Name}");
                Console.WriteLine($"========================================");
                Console.WriteLine("\nArreglo original:");
                ArrayPrinter.Print(originalData);

                // Preguntar si quiere modo paso a paso
                VisualizationHelper.AskForStepByStepMode();

                Console.WriteLine("\n--- Iniciando ordenamiento ---");
                var startTime = DateTime.Now;
                sorter.Sort(copy);
                var elapsed = DateTime.Now - startTime;

                Console.WriteLine("\n========================================");
                Console.WriteLine("Arreglo ordenado:");
                ArrayPrinter.Print(copy);
                Console.WriteLine($"Tiempo de ejecución: {elapsed.TotalMilliseconds:F2} ms");
                Console.WriteLine("========================================");

                Console.WriteLine("\n¿Deseas guardar este arreglo ordenado como datos actuales? (s/n): ");
                var save = Console.ReadLine()?.ToLower();
                if (save == "s" || save == "si" || save == "sí")
                {
                    Array.Copy(copy, originalData, copy.Length);
                    Console.WriteLine("¡Datos actualizados!");
                }

                Console.WriteLine("\nPresiona Enter para volver al menú de ordenamiento.");
                Console.ReadLine();
            }
        }

        static void ShowDataManagementMenu()
        {
            while (true)
            {
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

                switch (choice)
                {
                    case "1":
                        dataManager.ShowCurrentData();
                        Console.WriteLine("\nPresiona Enter para continuar.");
                        Console.ReadLine();
                        break;
                    case "2":
                        dataManager.GenerateRandomData();
                        Console.WriteLine("\nPresiona Enter para continuar.");
                        Console.ReadLine();
                        break;
                    case "3":
                        dataManager.EnterManualData();
                        Console.WriteLine("\nPresiona Enter para continuar.");
                        Console.ReadLine();
                        break;
                    case "4":
                        dataManager.UsePresetData();
                        Console.WriteLine("\nPresiona Enter para continuar.");
                        Console.ReadLine();
                        break;
                    case "5":
                        dataManager.ResetToDefault();
                        Console.WriteLine("\nPresiona Enter para continuar.");
                        Console.ReadLine();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Presiona Enter.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void ShowSearchMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("           Métodos de Búsqueda");
                Console.WriteLine("-----------------------------------------");
                dataManager.ShowCurrentData();
                Console.WriteLine();
                for (int i = 0; i < Searchers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Searchers[i].Name}");
                }
                Console.WriteLine($"{Searchers.Count + 1}. Volver al menú principal");
                Console.Write("\nElige un algoritmo de búsqueda: ");

                var choice = Console.ReadLine();
                if (!int.TryParse(choice, out int idx) || idx < 1 || idx > Searchers.Count + 1)
                {
                    Console.WriteLine("Opción no válida. Presiona Enter.");
                    Console.ReadLine();
                    continue;
                }
                if (idx == Searchers.Count + 1) return;

                Console.Write("\nPor favor, ingresa el número que deseas buscar: ");
                if (!int.TryParse(Console.ReadLine(), out int numberToSearch))
                {
                    Console.WriteLine("Entrada no válida. Debes ingresar un número.");
                    Console.ReadLine();
                    continue;
                }

                var searcher = Searchers[idx - 1];
                Console.Clear();
                Console.WriteLine($"========================================");
                Console.WriteLine($"   Ejecutando {searcher.Name}");
                Console.WriteLine($"========================================");
                Console.WriteLine($"\nBuscando el número: {numberToSearch}");

                var originalData = dataManager.GetOriginalData();
                int[] working = dataManager.GetData();
                
                if (searcher.RequiresSorted)
                {
                    Console.WriteLine("\n⚠ Este algoritmo requiere un arreglo ordenado.");
                    Console.Write("¿Deseas ordenar el arreglo primero? (s/n): ");
                    var sortChoice = Console.ReadLine()?.ToLower();
                    
                    if (sortChoice == "s" || sortChoice == "si" || sortChoice == "sí")
                    {
                        Array.Sort(working);
                        Console.WriteLine("\nArreglo ordenado para la búsqueda:");
                        ArrayPrinter.Print(working);
                    }
                    else
                    {
                        Console.WriteLine("\n⚠ Advertencia: El resultado puede no ser correcto en un arreglo desordenado.");
                        Console.WriteLine("Arreglo actual (sin ordenar):");
                        ArrayPrinter.Print(working);
                    }
                }
                else
                {
                    Console.WriteLine("\nBuscando en el arreglo actual:");
                    ArrayPrinter.Print(working);
                }

                Console.WriteLine("\n--- Iniciando búsqueda ---");
                var startTime = DateTime.Now;
                var foundIndex = searcher.Search(working, numberToSearch);
                var elapsed = DateTime.Now - startTime;

                Console.WriteLine("\n========================================");
                if (foundIndex != -1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"✓ ¡ENCONTRADO!");
                    Console.ResetColor();
                    Console.WriteLine($"El número {numberToSearch} está en el índice {foundIndex}");
                    Console.WriteLine($"Valor en esa posición: {working[foundIndex]}");
                    
                    if (searcher.RequiresSorted && !working.SequenceEqual(originalData))
                    {
                        var originalIndex = Array.IndexOf(originalData, numberToSearch);
                        Console.WriteLine($"Índice en el arreglo original (sin ordenar): {originalIndex}");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"✗ NO ENCONTRADO");
                    Console.ResetColor();
                    Console.WriteLine($"El número {numberToSearch} no existe en el arreglo.");
                }
                Console.WriteLine($"Tiempo de búsqueda: {elapsed.TotalMilliseconds:F4} ms");
                Console.WriteLine("========================================");

                Console.WriteLine("\nPresiona Enter para volver al menú de búsqueda.");
                Console.ReadLine();
            }
        }
    }
}
