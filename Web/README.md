# 🎯 Visualizador de Algoritmos Web

Aplicación web interactiva para visualizar métodos algorítmicos de ordenamiento y métodos de búsqueda.

## 🌟 Características

### 🌍 Ejemplos de la Vida Cotidiana
Cada algoritmo incluye una **analogía de la vida real** para entender mejor su funcionamiento:

- **HeapSort → 🏆 Organizar medallas**: Como ordenar una colección de trofeos por importancia
- **MergeSort → 🃏 Ordenar un mazo de cartas**: Dividir y fusionar como cuando organizas cartas
- **QuickSort → 👥 Formar filas por altura**: Como cuando el profesor te formaba en la escuela
- **Interpolación → 📖 Buscar en el diccionario**: Estimar dónde está una palabra y saltar a esa página
- **Hash → 🗄️ Cajones de ropa**: Organizar por categorías para encontrar al instante

### Métodos Algorítmicos (Ordenamiento)
- **HeapSort**: Visualización de construcción de heap y extracción de elementos
- **MergeSort**: Animación de división recursiva y fusión de subarrays
- **QuickSort**: Visualización de selección de pivote y particionamiento

### Métodos de Búsqueda
- **Búsqueda por Interpolación**: Muestra el cálculo de posición estimada mediante interpolación lineal
- **Búsqueda Hash**: Visualiza la construcción de tabla hash y búsqueda O(1)

## 🚀 Uso

### Opción 1: Abrir directamente
1. Navega a la carpeta `Web/`
2. Abre `index.html` en tu navegador web favorito (Chrome, Firefox, Edge, etc.)

### Opción 2: Servidor local
```bash
cd Web
python -m http.server 8000
# O con Node.js
npx http-server
```
Luego abre http://localhost:8000 en tu navegador

## 🎮 Controles

### Configuración
- **Tipo de Algoritmo**: Selecciona entre métodos algorítmicos o búsqueda
- **Algoritmo Específico**: Elige el algoritmo a visualizar
- **Tamaño del Array**: Ajusta de 5 a 50 elementos (slider)
- **Velocidad**: Controla la velocidad de animación (50-2000ms)

### Botones
- **🔄 Generar Array Aleatorio**: Crea un nuevo conjunto de datos
- **▶️ Iniciar Visualización**: Comienza la animación del algoritmo
- **⏹️ Reiniciar**: Vuelve al estado inicial del array

### Estadísticas en Tiempo Real
- **Comparaciones**: Número de comparaciones realizadas
- **Intercambios**: Número de intercambios de elementos
- **Tiempo**: Tiempo transcurrido de la visualización

## 🎨 Código de Colores

### Ordenamiento
- **Azul/Morado**: Elementos normales
- **Amarillo**: Elementos siendo comparados
- **Rojo**: Elementos siendo intercambiados
- **Naranja**: Elemento pivote (QuickSort)
- **Verde**: Elementos ya ordenados

### Búsqueda
- **Azul**: Elemento siendo examinado
- **Verde con brillo**: Elemento encontrado
- **Gris**: Buckets de tabla hash vacíos
- **Verde claro**: Buckets de tabla hash ocupados

## 📚 Secciones Informativas

### 🌍 Ejemplo de la Vida Cotidiana
Muestra cómo usas estos algoritmos sin darte cuenta en tu día a día, con:
- 📝 Descripción detallada del escenario real
- 🎬 Animación visual con emojis representativos
- 💡 Múltiples ejemplos prácticos

### Explicación Técnica
Descripción del algoritmo seleccionado, su complejidad temporal y funcionamiento general.

### Paso Actual
Muestra en tiempo real qué está haciendo el algoritmo en cada paso de la visualización.

### Pseudocódigo
Presenta el pseudocódigo del algoritmo para entender su implementación.

## 🛠️ Tecnologías Utilizadas

- **HTML5**: Estructura de la aplicación
- **CSS3**: Estilos, animaciones y diseño responsive
- **JavaScript ES6+**: Lógica de algoritmos y visualización
- **CSS Grid/Flexbox**: Layout responsivo

## 📱 Responsive

La aplicación es completamente responsive y se adapta a:
- 💻 Escritorio (1024px+)
- 📱 Tablets (768px - 1024px)
- 📱 Móviles (< 768px)

## 🎓 Propósito Educativo

Esta aplicación fue diseñada con fines educativos para:
- Comprender visualmente cómo funcionan los algoritmos
- Comparar eficiencia entre diferentes métodos
- Aprender sobre complejidad algorítmica
- Experimentar con diferentes tamaños de datos

## 🔍 Detalles Técnicos

### Algoritmos Implementados

#### HeapSort
- Construcción de max-heap bottom-up
- Extracción repetida del máximo
- Complejidad: O(n log n)

#### MergeSort
- Dividir recursivamente hasta subarrays de tamaño 1
- Fusionar subarrays ordenados
- Complejidad: O(n log n)

#### QuickSort
- Selección de pivote (último elemento)
- Particionamiento de Lomuto
- Complejidad: O(n log n) promedio

#### Búsqueda por Interpolación
- Estimación de posición mediante interpolación lineal
- Óptimo para datos uniformemente distribuidos
- Complejidad: O(log log n) mejor caso

#### Búsqueda Hash
- Función hash: valor % 10
- Tabla hash con Map de JavaScript
- Complejidad: O(1) promedio

## 📄 Licencia

Proyecto educativo de código abierto.

## 👨‍💻 Autor

Desarrollado como parte del proyecto de Métodos Algorítmicos y Búsqueda.
