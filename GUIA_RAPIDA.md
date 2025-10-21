# Guía Rápida de Uso - Herramienta Educativa de Algoritmos

## 🚀 Inicio Rápido

```pwsh
dotnet run
```

## 📋 Menú Principal

Al iniciar verás:
- Los **datos actuales** del arreglo
- **4 opciones principales**:
  1. Métodos de Ordenamiento
  2. Métodos de Búsqueda
  3. Gestionar Datos (¡NUEVA función!)
  4. Salir

## 🎨 Nuevas Funcionalidades Interactivas

### 1️⃣ Gestionar Datos (Opción 3)

#### Generar Datos Aleatorios
- Elige cuántos elementos (1-100)
- Define el rango mínimo y máximo
- Ideal para probar con diferentes tamaños de arreglos

**Ejemplo:**
```
¿Cuántos elementos? 15
Valor mínimo: 1
Valor máximo: 50
```

#### Ingresar Datos Manualmente
- Define el tamaño del arreglo (1-50)
- Ingresa cada elemento uno por uno
- Perfecto para casos específicos de prueba

**Ejemplo:**
```
¿Cuántos elementos? 5
Elemento #1: 64
Elemento #2: 34
Elemento #3: 25
...
```

#### Usar Conjuntos Predefinidos
1. **Pequeño** (5 elementos): `{64, 34, 25, 12, 22}`
2. **Mediano** (10 elementos): Original `{42, 23, 16, 8, 4, 15, 108, 55, 31}`
3. **Grande** (20 elementos): Para probar rendimiento
4. **Ya ordenado**: `{1, 5, 10, 15, 20, 25, 30, 35, 40, 45}`
5. **Orden inverso**: `{100, 90, 80, 70, 60, 50, 40, 30, 20, 10}`

### 2️⃣ Visualización Paso a Paso

Cuando ejecutas un algoritmo de ordenamiento, se te pregunta:

**"¿Deseas ver la ejecución paso a paso?"**
- **s/sí**: Activa el modo educativo
- **n/no**: Muestra solo resultado final

Si activas paso a paso, elige velocidad:
1. **Rápido** (300ms): Para arreglos grandes
2. **Normal** (800ms): Balance perfecto
3. **Lento** (1500ms): Ideal para explicar en clase

#### Qué verás en modo paso a paso:
- ✅ Cada comparación entre elementos
- 🔄 Intercambios resaltados en **amarillo**
- 📊 Mensajes indicando si se intercambia o no
- 🎯 Estado del arreglo después de cada pasada
- 📈 Estadísticas finales (comparaciones, intercambios, tiempo)

### 3️⃣ Guardar Resultados Ordenados

Después de ordenar, el sistema pregunta:
**"¿Deseas guardar este arreglo ordenado como datos actuales?"**
- **s**: El arreglo ordenado se convierte en tus datos actuales
- **n**: Mantiene el arreglo original sin ordenar

Útil para:
- Preparar datos para búsqueda binaria
- Comparar algoritmos con los mismos datos ordenados

### 4️⃣ Búsqueda Inteligente

Al usar **Binary Search**, el sistema detecta si el arreglo no está ordenado:
- ⚠️ Te advierte que necesita estar ordenado
- Te pregunta: **"¿Deseas ordenar el arreglo primero?"**
  - **s**: Ordena automáticamente y luego busca
  - **n**: Busca de todas formas (mostrará advertencia de resultado incorrecto)

Resultados de búsqueda incluyen:
- ✓ Si se encontró (en verde)
- ✗ Si no se encontró (en rojo)
- Índice donde se encontró
- Tiempo de búsqueda en milisegundos
- Diferencia entre índice en arreglo ordenado vs original

## 🎓 Escenarios de Uso en Clase

### Escenario 1: Demostrar Bubble Sort paso a paso
```
1. Ir a "Gestionar Datos" → "Conjunto predefinido" → "Pequeño (5 elementos)"
2. Ir a "Métodos de Ordenamiento" → "Bubble Sort"
3. Responder "s" a paso a paso
4. Elegir velocidad "3" (Lento)
5. Observar cada comparación e intercambio en pantalla
```

### Escenario 2: Comparar rendimiento de algoritmos
```
1. Generar datos aleatorios: 50 elementos, rango 1-100
2. Ejecutar Bubble Sort (sin paso a paso) → anotar tiempo
3. Volver al menú, NO guardar el ordenado
4. Ejecutar Insertion Sort → anotar tiempo
5. Volver al menú, NO guardar el ordenado
6. Ejecutar Quicksort → anotar tiempo y comparar
```

### Escenario 3: Mejor vs Peor caso
```
1. Usar preset "Ya ordenado"
2. Ejecutar Bubble Sort → Ver que casi no hace intercambios
3. Cambiar a preset "Orden inverso"
4. Ejecutar Bubble Sort → Ver máximos intercambios
5. Comparar estadísticas
```

### Escenario 4: Demostrar necesidad de orden en Binary Search
```
1. Usar datos predeterminados (desordenados)
2. Ir a "Métodos de Búsqueda" → "Linear Search" → Buscar: 23
3. Anotar que lo encuentra en índice 1
4. Ahora elegir "Binary Search" → Buscar: 23
5. Cuando pregunte si ordenar, decir "n" → Observar advertencia
6. Repetir pero ahora decir "s" → Ver diferencia
```

### Escenario 5: Datos personalizados
```
1. Ir a "Gestionar Datos" → "Ingresar manualmente"
2. Crear un caso específico: {5, 2, 8, 1, 9}
3. Probar con Insertion Sort en modo paso a paso
4. Observar cómo inserta cada elemento en su posición
```

## 💡 Tips para Profesores

1. **Arreglos pequeños (5-10)** + **Modo lento**: Mejor para explicaciones detalladas
2. **Arreglos grandes (50-100)**: Para demostrar diferencias de rendimiento (sin paso a paso)
3. **Preset "Orden inverso"**: Excelente para mostrar peor caso de Bubble Sort
4. **Preset "Ya ordenado"**: Demuestra mejor caso con optimización temprana
5. **Comparar tiempos**: Usa el mismo arreglo aleatorio para todos los algoritmos (no guardes ordenados entre ejecuciones)

## ⚡ Atajos y Consejos

- Los datos se muestran siempre en la parte superior de cada menú
- Puedes cambiar los datos en cualquier momento
- El tiempo de ejecución te ayuda a comparar eficiencia
- Las estadísticas (comparaciones/intercambios) son útiles para análisis de complejidad
- Guardar el arreglo ordenado es útil para pruebas subsecuentes de búsqueda

## 🐛 Solución de Problemas

**Problema**: No veo los colores en paso a paso
- **Solución**: Asegúrate de usar una terminal moderna (Windows Terminal, VS Code terminal)

**Problema**: El modo paso a paso es muy lento
- **Solución**: Al iniciar, elige velocidad "1" (Rápido)

**Problema**: Quiero usar los datos originales de nuevo
- **Solución**: Ir a "Gestionar Datos" → "Restaurar datos predeterminados"

---

¡Disfruta enseñando algoritmos de forma interactiva! 🎉
