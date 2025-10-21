# Herramienta Educativa de Algoritmos (C# - Consola)

Proyecto de consola orientado a objetos que demuestra métodos de ordenamiento y búsqueda para uso en clases, con funcionalidades interactivas y personalizables.

## Cómo ejecutar

1. Asegúrate de tener instalado .NET 8 (o superior).
2. Abre una terminal en la carpeta del proyecto.
3. Ejecuta:

```pwsh
dotnet run
```

## Características Principales

### 🎮 Totalmente Interactivo
- **Gestión de Datos Personalizable**: 
  - Genera arreglos aleatorios con tamaño y rango personalizados
  - Ingresa datos manualmente elemento por elemento
  - Elige entre conjuntos predefinidos (pequeño, mediano, grande, ordenado, inverso)
  - Restaura datos predeterminados en cualquier momento

### 📊 Visualización Paso a Paso
- **Modo educativo**: Observa cada comparación, intercambio y desplazamiento
- **Velocidad ajustable**: Rápido (300ms), Normal (800ms), o Lento (1500ms)
- **Estadísticas detalladas**: Cuenta comparaciones, intercambios y tiempo de ejecución
- **Resaltado visual**: Elementos en proceso se muestran en color

### 🔢 Algoritmos de Ordenamiento
- **Bubble Sort**: Con optimización de detección temprana
- **Insertion Sort**: Visualiza desplazamientos e inserciones
- **Quicksort**: Muestra particiones y colocación de pivotes

### 🔍 Algoritmos de Búsqueda
- **Linear Search**: Búsqueda secuencial en arreglos desordenados
- **Binary Search**: Búsqueda eficiente con opción de ordenar primero
- **Advertencias inteligentes**: Te avisa si intentas búsqueda binaria sin ordenar

### 📈 Métricas de Rendimiento
- Tiempo de ejecución en milisegundos
- Conteo de comparaciones e intercambios/desplazamientos
- Comparación entre arreglo original y procesado

## Estructura del Proyecto (OOP)

```
├── Program.cs              # Punto de entrada y menús
├── Sort/
│   ├── ISorter.cs         # Interfaz para algoritmos de ordenamiento
│   ├── BubbleSorter.cs    # Implementación Bubble Sort
│   ├── InsertionSorter.cs # Implementación Insertion Sort
│   └── QuickSorter.cs     # Implementación Quicksort
├── Search/
│   ├── ISearcher.cs       # Interfaz para algoritmos de búsqueda
│   ├── LinearSearcher.cs  # Implementación búsqueda lineal
│   └── BinarySearcher.cs  # Implementación búsqueda binaria
└── Utils/
    ├── ArrayPrinter.cs         # Utilidad para imprimir arreglos
    ├── DataManager.cs          # Gestión del conjunto de datos
    └── VisualizationHelper.cs  # Visualización paso a paso
```

## Notas para la Enseñanza

- Los algoritmos están encapsulados detrás de interfaces (`ISorter`, `ISearcher`) para enseñar principios SOLID
- Fácil extensión: agrega nuevos algoritmos implementando las interfaces
- El modo paso a paso es ideal para explicar el funcionamiento interno de cada algoritmo
- Las estadísticas ayudan a comparar eficiencia entre algoritmos
- Los datos personalizables permiten probar casos especiales (mejor/peor caso)

## Ejemplo de Uso en Clase

1. **Demostrar Bubble Sort**: Usa un arreglo pequeño (5 elementos) en modo paso a paso lento
2. **Comparar eficiencia**: Genera un arreglo aleatorio grande (50 elementos) y compara tiempos entre algoritmos
3. **Mejor vs Peor caso**: Usa el preset "Ya ordenado" vs "Orden inverso" y observa diferencias
4. **Búsqueda**: Demuestra por qué Binary Search requiere orden usando los mismos datos en Linear Search
