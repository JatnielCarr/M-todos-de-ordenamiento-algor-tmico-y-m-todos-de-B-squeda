// Estado de la aplicación
let state = {
    array: [],
    originalArray: [],
    size: 15,
    speed: 500,
    comparisons: 0,
    swaps: 0,
    isRunning: false,
    startTime: 0
};

// Referencias a elementos del DOM
const elements = {
    algorithmType: document.getElementById('algorithmType'),
    sortAlgorithm: document.getElementById('sortAlgorithm'),
    searchAlgorithm: document.getElementById('searchAlgorithm'),
    sortAlgorithms: document.getElementById('sortAlgorithms'),
    searchAlgorithms: document.getElementById('searchAlgorithms'),
    searchValue: document.getElementById('searchValue'),
    arraySize: document.getElementById('arraySize'),
    arraySizeValue: document.getElementById('arraySizeValue'),
    speed: document.getElementById('speed'),
    speedValue: document.getElementById('speedValue'),
    generateArray: document.getElementById('generateArray'),
    startVisualization: document.getElementById('startVisualization'),
    resetVisualization: document.getElementById('resetVisualization'),
    arrayVisualization: document.getElementById('arrayVisualization'),
    comparisons: document.getElementById('comparisons'),
    swaps: document.getElementById('swaps'),
    time: document.getElementById('time'),
    explanationText: document.getElementById('explanationText'),
    stepText: document.getElementById('stepText'),
    pseudocode: document.getElementById('pseudocode'),
    visualizationTitle: document.getElementById('visualizationTitle'),
    realLifeText: document.getElementById('realLifeText'),
    realLifeAnimation: document.getElementById('realLifeAnimation')
};

// Event Listeners
elements.algorithmType.addEventListener('change', handleAlgorithmTypeChange);
elements.arraySize.addEventListener('input', handleArraySizeChange);
elements.speed.addEventListener('input', handleSpeedChange);
elements.generateArray.addEventListener('click', generateArray);
elements.startVisualization.addEventListener('click', startVisualization);
elements.resetVisualization.addEventListener('click', resetVisualization);
elements.sortAlgorithm.addEventListener('change', updateExplanation);
elements.searchAlgorithm.addEventListener('change', updateExplanation);

// Inicialización
generateArray();
updateExplanation();

function handleAlgorithmTypeChange() {
    const isSort = elements.algorithmType.value === 'sort';
    elements.sortAlgorithms.classList.toggle('hidden', !isSort);
    elements.searchAlgorithms.classList.toggle('hidden', isSort);
    updateExplanation();
}

function handleArraySizeChange() {
    state.size = parseInt(elements.arraySize.value);
    elements.arraySizeValue.textContent = state.size;
}

function handleSpeedChange() {
    state.speed = parseInt(elements.speed.value);
    elements.speedValue.textContent = state.speed + 'ms';
}

function generateArray() {
    state.array = [];
    const isSearch = elements.algorithmType.value === 'search';
    
    for (let i = 0; i < state.size; i++) {
        state.array.push(Math.floor(Math.random() * 100) + 1);
    }
    
    // Para búsqueda, ordenar el array
    if (isSearch) {
        state.array.sort((a, b) => a - b);
        // Asegurar que el valor buscado esté en el array (50% probabilidad)
        if (Math.random() > 0.5) {
            const randomIndex = Math.floor(Math.random() * state.array.length);
            elements.searchValue.value = state.array[randomIndex];
        }
    }
    
    state.originalArray = [...state.array];
    renderArray();
    resetStats();
    elements.stepText.textContent = 'Array generado. Presiona Iniciar para comenzar.';
}

function renderArray(highlightIndices = {}) {
    const container = elements.arrayVisualization;
    container.innerHTML = '';
    container.style.display = 'flex';
    
    const maxValue = Math.max(...state.array);
    const containerHeight = 370;
    
    state.array.forEach((value, index) => {
        const bar = document.createElement('div');
        bar.className = 'array-bar';
        
        // Calcular altura proporcional
        const height = (value / maxValue) * containerHeight;
        bar.style.height = height + 'px';
        
        // Aplicar clases especiales con prioridad
        if (highlightIndices.found === index) {
            bar.classList.add('found');
        } else if (highlightIndices.pivot === index) {
            bar.classList.add('pivot');
        } else if (highlightIndices.swapping?.includes(index)) {
            bar.classList.add('swapping');
        } else if (highlightIndices.searching?.includes(index)) {
            bar.classList.add('searching');
        } else if (highlightIndices.comparing?.includes(index)) {
            bar.classList.add('comparing');
        } else if (highlightIndices.sorted?.includes(index)) {
            bar.classList.add('sorted');
        }
        
        // Valor
        const valueLabel = document.createElement('span');
        valueLabel.className = 'array-value';
        valueLabel.textContent = value;
        bar.appendChild(valueLabel);
        
        // Índice
        const indexLabel = document.createElement('span');
        indexLabel.className = 'array-index';
        indexLabel.textContent = `[${index}]`;
        bar.appendChild(indexLabel);
        
        container.appendChild(bar);
    });
    
    updateStats();
}

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

function resetStats() {
    state.comparisons = 0;
    state.swaps = 0;
    state.startTime = 0;
    updateStats();
}

function updateStats() {
    elements.comparisons.textContent = state.comparisons;
    elements.swaps.textContent = state.swaps;
    if (state.startTime > 0) {
        elements.time.textContent = (Date.now() - state.startTime) + 'ms';
    } else {
        elements.time.textContent = '0ms';
    }
}

async function startVisualization() {
    if (state.isRunning) return;
    
    state.isRunning = true;
    state.startTime = Date.now();
    elements.startVisualization.disabled = true;
    elements.generateArray.disabled = true;
    
    const algorithmType = elements.algorithmType.value;
    
    try {
        if (algorithmType === 'sort') {
            const algorithm = elements.sortAlgorithm.value;
            switch (algorithm) {
                case 'heap':
                    await heapSort();
                    break;
                case 'merge':
                    await mergeSort(0, state.array.length - 1);
                    break;
                case 'quick':
                    await quickSort(0, state.array.length - 1);
                    break;
            }
            // Marcar todo como ordenado
            await sleep(state.speed);
            renderArray({ sorted: [...Array(state.array.length).keys()] });
            elements.stepText.textContent = '✅ ¡Ordenamiento completado!';
        } else {
            const algorithm = elements.searchAlgorithm.value;
            const target = parseInt(elements.searchValue.value);
            
            switch (algorithm) {
                case 'interpolation':
                    await interpolationSearch(target);
                    break;
                case 'hash':
                    await hashSearch(target);
                    break;
            }
        }
    } catch (error) {
        console.error('Error durante la visualización:', error);
        elements.stepText.textContent = 'Error: ' + error.message;
    }
    
    updateStats();
    state.isRunning = false;
    elements.startVisualization.disabled = false;
    elements.generateArray.disabled = false;
}

function resetVisualization() {
    state.array = [...state.originalArray];
    state.isRunning = false;
    renderArray();
    resetStats();
    elements.stepText.textContent = 'Visualización reiniciada.';
    elements.startVisualization.disabled = false;
    elements.generateArray.disabled = false;
}

// ==================== HEAPSORT ====================
async function heapSort() {
    const n = state.array.length;
    
    elements.stepText.textContent = '🔨 Construyendo heap (montículo)...';
    
    // Construir heap
    for (let i = Math.floor(n / 2) - 1; i >= 0; i--) {
        await heapify(n, i);
    }
    
    elements.stepText.textContent = '📤 Extrayendo elementos del heap uno por uno...';
    
    // Extraer elementos
    for (let i = n - 1; i > 0; i--) {
        // Mover raíz al final
        await swap(0, i);
        renderArray({ sorted: [...Array(n - i).keys()].map(k => n - k - 1) });
        await sleep(state.speed);
        
        // Heapify en el heap reducido
        await heapify(i, 0);
    }
}

async function heapify(n, i) {
    let largest = i;
    const left = 2 * i + 1;
    const right = 2 * i + 2;
    
    if (left < n) {
        state.comparisons++;
        elements.stepText.textContent = `🔍 Comparando nodo ${i} (valor ${state.array[i]}) con hijo izquierdo ${left} (valor ${state.array[left]})`;
        renderArray({ comparing: [left, largest] });
        await sleep(state.speed);
        
        if (state.array[left] > state.array[largest]) {
            largest = left;
            elements.stepText.textContent = `✓ Hijo izquierdo ${state.array[left]} es mayor que ${state.array[i]}`;
            await sleep(state.speed / 2);
        }
    }
    
    if (right < n) {
        state.comparisons++;
        elements.stepText.textContent = `🔍 Comparando nodo actual ${largest} (valor ${state.array[largest]}) con hijo derecho ${right} (valor ${state.array[right]})`;
        renderArray({ comparing: [right, largest] });
        await sleep(state.speed);
        
        if (state.array[right] > state.array[largest]) {
            largest = right;
            elements.stepText.textContent = `✓ Hijo derecho ${state.array[right]} es el mayor`;
            await sleep(state.speed / 2);
        }
    }
    
    if (largest !== i) {
        elements.stepText.textContent = `🔄 Intercambiando ${state.array[i]} (posición ${i}) ↔️ ${state.array[largest]} (posición ${largest}) para mantener propiedad de heap`;
        renderArray({ swapping: [i, largest] });
        await sleep(state.speed);
        
        await swap(i, largest);
        renderArray({ swapping: [i, largest] });
        await sleep(state.speed);
        
        await heapify(n, largest);
    } else {
        elements.stepText.textContent = `✓ El nodo ${i} ya cumple la propiedad de heap`;
        await sleep(state.speed / 3);
    }
}

// ==================== MERGESORT ====================
async function mergeSort(left, right) {
    if (left < right) {
        const mid = Math.floor((left + right) / 2);
        
        elements.stepText.textContent = `Dividiendo: [${left}...${mid}] y [${mid + 1}...${right}]`;
        renderArray({ comparing: [...Array(right - left + 1).keys()].map(k => left + k) });
        await sleep(state.speed);
        
        await mergeSort(left, mid);
        await mergeSort(mid + 1, right);
        await merge(left, mid, right);
    }
}

async function merge(left, mid, right) {
    const leftArr = state.array.slice(left, mid + 1);
    const rightArr = state.array.slice(mid + 1, right + 1);
    
    elements.stepText.textContent = `🔀 Fusionando subarrays:\n📗 Izquierdo [${left}..${mid}]: [${leftArr.join(', ')}]\n📘 Derecho [${mid + 1}..${right}]: [${rightArr.join(', ')}]`;
    renderArray({ comparing: [...Array(right - left + 1).keys()].map(k => left + k) });
    await sleep(state.speed);
    
    let i = 0, j = 0, k = left;
    
    while (i < leftArr.length && j < rightArr.length) {
        state.comparisons++;
        
        elements.stepText.textContent = `⚖️ Comparando: ${leftArr[i]} (izq) vs ${rightArr[j]} (der)\n${leftArr[i] <= rightArr[j] ? `✓ Tomando ${leftArr[i]} del subarray izquierdo` : `✓ Tomando ${rightArr[j]} del subarray derecho`}`;
        renderArray({ comparing: [k] });
        await sleep(state.speed);
        
        if (leftArr[i] <= rightArr[j]) {
            state.array[k] = leftArr[i];
            i++;
        } else {
            state.array[k] = rightArr[j];
            j++;
        }
        
        state.swaps++;
        renderArray({ swapping: [k] });
        await sleep(state.speed);
        k++;
    }
    
    while (i < leftArr.length) {
        elements.stepText.textContent = `📗 Copiando restantes del izquierdo: ${leftArr[i]}`;
        state.array[k] = leftArr[i];
        state.swaps++;
        renderArray({ swapping: [k] });
        await sleep(state.speed / 2);
        i++;
        k++;
    }
    
    while (j < rightArr.length) {
        elements.stepText.textContent = `📘 Copiando restantes del derecho: ${rightArr[j]}`;
        state.array[k] = rightArr[j];
        state.swaps++;
        renderArray({ swapping: [k] });
        await sleep(state.speed / 2);
        j++;
        k++;
    }
    
    elements.stepText.textContent = `✅ Fusión completada para rango [${left}..${right}]`;
    renderArray({ sorted: [...Array(right - left + 1).keys()].map(k => left + k) });
    await sleep(state.speed / 2);
}

// ==================== QUICKSORT ====================
async function quickSort(low, high) {
    if (low < high) {
        const pi = await partition(low, high);
        await quickSort(low, pi - 1);
        await quickSort(pi + 1, high);
    }
}

async function partition(low, high) {
    const pivot = state.array[high];
    elements.stepText.textContent = `🎯 Pivote seleccionado: ${pivot} (índice ${high})\n📌 Particionando rango [${low}..${high}]`;
    renderArray({ pivot: high });
    await sleep(state.speed * 1.5);
    
    let i = low - 1;
    
    for (let j = low; j < high; j++) {
        state.comparisons++;
        elements.stepText.textContent = `🔍 Comparando ${state.array[j]} (posición ${j}) con pivote ${pivot}\n${state.array[j] < pivot ? '✓ Es menor que pivote - mover a la izquierda' : '✗ Es mayor o igual - dejar a la derecha'}`;
        renderArray({ pivot: high, comparing: [j, i + 1] });
        await sleep(state.speed);
        
        if (state.array[j] < pivot) {
            i++;
            if (i !== j) {
                elements.stepText.textContent = `🔄 Intercambiando ${state.array[i]} (posición ${i}) ↔️ ${state.array[j]} (posición ${j})`;
                renderArray({ pivot: high, swapping: [i, j] });
                await sleep(state.speed);
                
                await swap(i, j);
                renderArray({ pivot: high, swapping: [i, j] });
                await sleep(state.speed);
            }
        }
    }
    
    elements.stepText.textContent = `🎯 Colocando pivote ${pivot} en su posición final (${i + 1})\nElementos menores a la izquierda, mayores a la derecha`;
    renderArray({ pivot: high, swapping: [i + 1] });
    await sleep(state.speed * 1.5);
    
    await swap(i + 1, high);
    renderArray({ swapping: [i + 1, high], sorted: [i + 1] });
    await sleep(state.speed);
    
    return i + 1;
}

// ==================== INTERPOLATION SEARCH ====================
async function interpolationSearch(target) {
    let low = 0;
    let high = state.array.length - 1;
    
    elements.stepText.textContent = `🔍 Iniciando Búsqueda por Interpolación\n🎯 Buscando: ${target}\n📊 Array ordenado: [${state.array.join(', ')}]`;
    renderArray({ comparing: [low, high] });
    await sleep(state.speed * 2);
    
    while (low <= high && target >= state.array[low] && target <= state.array[high]) {
        if (low === high) {
            state.comparisons++;
            elements.stepText.textContent = `📍 Un solo elemento en el rango\n🔍 Verificando posición ${low}: ${state.array[low]}`;
            renderArray({ searching: [low] });
            await sleep(state.speed);
            
            if (state.array[low] === target) {
                elements.stepText.textContent = `✅ ¡ENCONTRADO! 🎉\n${target} está en la posición ${low}`;
                renderArray({ found: low });
                await sleep(state.speed * 2);
                return low;
            }
            break;
        }
        
        // Calcular posición usando interpolación
        const pos = low + Math.floor(
            ((target - state.array[low]) * (high - low)) / 
            (state.array[high] - state.array[low])
        );
        
        elements.stepText.textContent = 
            `📐 Calculando posición estimada:\n` +
            `━━━━━━━━━━━━━━━━━━━━━━\n` +
            `Rango: [${low}, ${high}]\n` +
            `Valores: [${state.array[low]}, ${state.array[high]}]\n\n` +
            `🧮 Fórmula de interpolación:\n` +
            `pos = ${low} + ((${target} - ${state.array[low]}) × (${high} - ${low})) / (${state.array[high]} - ${state.array[low]})\n` +
            `pos = ${pos}\n\n` +
            `🔍 Verificando posición ${pos}: valor = ${state.array[pos]}`;
        
        state.comparisons++;
        renderArray({ searching: [pos], comparing: [low, high] });
        await sleep(state.speed * 1.5);
        
        if (state.array[pos] === target) {
            elements.stepText.textContent = `✅ ¡ENCONTRADO! 🎉\n${target} está en la posición ${pos}`;
            renderArray({ found: pos });
            await sleep(state.speed * 2);
            return pos;
        }
        
        if (state.array[pos] < target) {
            elements.stepText.textContent = `➡️ ${state.array[pos]} < ${target}\nBuscar en la mitad DERECHA\nNuevo rango: [${pos + 1}, ${high}]`;
            renderArray({ comparing: [pos, high] });
            low = pos + 1;
        } else {
            elements.stepText.textContent = `⬅️ ${state.array[pos]} > ${target}\nBuscar en la mitad IZQUIERDA\nNuevo rango: [${low}, ${pos - 1}]`;
            renderArray({ comparing: [low, pos] });
            high = pos - 1;
        }
        
        await sleep(state.speed);
    }
    
    elements.stepText.textContent = `❌ NO ENCONTRADO 😞\n${target} no existe en el array`;
    renderArray();
    await sleep(state.speed);
    return -1;
}

// ==================== HASH SEARCH ====================
async function hashSearch(target) {
    elements.stepText.textContent = `🏗️ Construyendo tabla hash...\n📊 Array original: [${state.array.join(', ')}]`;
    
    // Crear visualización de tabla hash
    const container = elements.arrayVisualization;
    container.innerHTML = '';
    container.style.display = 'grid';
    container.style.gridTemplateColumns = 'repeat(auto-fit, minmax(100px, 1fr))';
    container.classList.add('hash-table');
    
    const hashTable = new Map();
    const tableSize = 10;
    
    await sleep(state.speed);
    
    // Construir tabla hash
    for (let i = 0; i < state.array.length; i++) {
        const value = state.array[i];
        const hashKey = value % tableSize;
        
        elements.stepText.textContent = 
            `➕ Insertando elemento ${i + 1}/${state.array.length}\n` +
            `━━━━━━━━━━━━━━━━━━━━━━\n` +
            `Valor: ${value}\n` +
            `🧮 Función Hash: ${value} % ${tableSize} = ${hashKey}\n` +
            `📍 Bucket destino: ${hashKey}`;
        
        // Crear bucket visual
        const bucket = document.createElement('div');
        bucket.className = 'hash-bucket active';
        bucket.innerHTML = `
            <div class="hash-index">Bucket ${hashKey}</div>
            <div class="hash-value">${value}</div>
        `;
        container.appendChild(bucket);
        
        if (hashTable.has(hashKey)) {
            elements.stepText.textContent += `\n⚠️ COLISIÓN detectada en bucket ${hashKey}!\n(Simplificado: sobrescribiendo valor)`;
        }
        
        hashTable.set(hashKey, value);
        await sleep(state.speed);
        
        bucket.classList.remove('active');
        bucket.classList.add('filled');
    }
    
    elements.stepText.textContent = `✅ Tabla hash construida\n📊 Total de elementos: ${hashTable.size}\n🔍 Preparando búsqueda...`;
    await sleep(state.speed * 2);
    
    // Buscar valor
    const hashKey = target % tableSize;
    elements.stepText.textContent = 
        `🔍 Buscando ${target}...\n` +
        `━━━━━━━━━━━━━━━━━━━━━━\n` +
        `🧮 Calculando hash:\n` +
        `Hash(${target}) = ${target} % ${tableSize} = ${hashKey}\n\n` +
        `📍 Accediendo directamente al bucket ${hashKey}...`;
    
    // Destacar bucket buscado
    const buckets = container.querySelectorAll('.hash-bucket');
    buckets.forEach((bucket, index) => {
        const bucketHash = state.array[index] % tableSize;
        if (bucketHash === hashKey) {
            bucket.classList.add('active');
        }
    });
    
    await sleep(state.speed * 2);
    
    if (hashTable.has(hashKey) && hashTable.get(hashKey) === target) {
        elements.stepText.textContent = 
            `✅ ¡ENCONTRADO! 🎉\n` +
            `━━━━━━━━━━━━━━━━━━━━━━\n` +
            `${target} está en bucket ${hashKey}\n` +
            `⚡ Tiempo de acceso: O(1) - ¡Instantáneo!`;
        buckets.forEach((bucket, index) => {
            const bucketHash = state.array[index] % tableSize;
            if (bucketHash === hashKey && state.array[index] === target) {
                bucket.classList.remove('active');
                bucket.classList.add('found');
            }
        });
    } else {
        elements.stepText.textContent = 
            `❌ NO ENCONTRADO 😞\n` +
            `━━━━━━━━━━━━━━━━━━━━━━\n` +
            `${target} no existe en la tabla hash\n` +
            `Bucket ${hashKey} ${hashTable.has(hashKey) ? `contiene ${hashTable.get(hashKey)}` : 'está vacío'}`;
    }
    
    await sleep(state.speed * 2);
}

// ==================== UTILIDADES ====================
async function swap(i, j) {
    state.swaps++;
    [state.array[i], state.array[j]] = [state.array[j], state.array[i]];
    updateStats();
}

function updateExplanation() {
    const algorithmType = elements.algorithmType.value;
    
    if (algorithmType === 'sort') {
        const algorithm = elements.sortAlgorithm.value;
        
        switch (algorithm) {
            case 'heap':
                elements.visualizationTitle.textContent = '🏔️ HeapSort';
                
                // Ejemplo de vida real
                elements.realLifeText.innerHTML = `
                    <strong>🏆 Como organizar medallas por importancia</strong><br><br>
                    Imagina que tienes un montón de medallas deportivas (🥇🥈🥉) desordenadas en una caja. 
                    HeapSort funciona como cuando:<br><br>
                    1️⃣ <strong>Construyes una pirámide</strong> donde la medalla más valiosa siempre está arriba<br>
                    2️⃣ <strong>Tomas la de arriba</strong> (la mejor) y la colocas en tu vitrina<br>
                    3️⃣ <strong>Reorganizas</strong> las restantes para que la siguiente mejor quede arriba<br>
                    4️⃣ <strong>Repites</strong> hasta que todas estén ordenadas en tu vitrina<br><br>
                    <em>Ejemplo real:</em> Organizar tu colección de videojuegos por calificación, poniendo los mejores primero.
                `;
                showRealLifeAnimation('heap');
                
                elements.explanationText.innerHTML = `
                    <strong>HeapSort</strong> utiliza una estructura de datos llamada heap (montículo binario).
                    <br><br>
                    <strong>Complejidad:</strong> O(n log n) en todos los casos.
                    <br><br>
                    <strong>Funcionamiento:</strong>
                    <br>1. Construye un max-heap del array
                    <br>2. Extrae el máximo repetidamente y reconstruye el heap
                `;
                elements.pseudocode.textContent = `
HeapSort(array):
    n = length(array)
    
    // Construir heap
    for i = n/2 - 1 down to 0:
        heapify(array, n, i)
    
    // Extraer elementos
    for i = n-1 down to 1:
        swap(array[0], array[i])
        heapify(array, i, 0)

heapify(array, n, i):
    largest = i
    left = 2*i + 1
    right = 2*i + 2
    
    if left < n and array[left] > array[largest]:
        largest = left
    if right < n and array[right] > array[largest]:
        largest = right
    
    if largest != i:
        swap(array[i], array[largest])
        heapify(array, n, largest)
                `;
                break;
                
            case 'merge':
                elements.visualizationTitle.textContent = '🔀 MergeSort';
                
                // Ejemplo de vida real
                elements.realLifeText.innerHTML = `
                    <strong>🃏 Como ordenar un mazo de cartas gigante</strong><br><br>
                    ¿Alguna vez has tenido que organizar muchas cartas o papeles? MergeSort es como:<br><br>
                    1️⃣ <strong>Dividir el montón</strong> en dos pilas más pequeñas<br>
                    2️⃣ <strong>Dividir cada pila</strong> en pilas aún más pequeñas (hasta tener cartas individuales)<br>
                    3️⃣ <strong>Juntar de a pares</strong> ordenándolas: comparas dos cartas y pones la menor primero<br>
                    4️⃣ <strong>Fusionar pilas ordenadas</strong> hasta reconstruir el mazo completo ordenado<br><br>
                    <em>Ejemplo real:</em> Cuando organizas tus apuntes de diferentes materias fusionándolos por fecha,
                    o cuando combinas dos listas de compras ordenadas alfabéticamente.
                `;
                showRealLifeAnimation('merge');
                
                elements.explanationText.innerHTML = `
                    <strong>MergeSort</strong> usa el paradigma divide y conquista.
                    <br><br>
                    <strong>Complejidad:</strong> O(n log n) en todos los casos.
                    <br><br>
                    <strong>Funcionamiento:</strong>
                    <br>1. Divide el array por la mitad recursivamente
                    <br>2. Ordena cada mitad
                    <br>3. Fusiona las mitades ordenadas
                `;
                elements.pseudocode.textContent = `
MergeSort(array, left, right):
    if left < right:
        mid = (left + right) / 2
        MergeSort(array, left, mid)
        MergeSort(array, mid+1, right)
        Merge(array, left, mid, right)

Merge(array, left, mid, right):
    leftArray = array[left...mid]
    rightArray = array[mid+1...right]
    
    i = 0, j = 0, k = left
    
    while i < length(leftArray) and j < length(rightArray):
        if leftArray[i] <= rightArray[j]:
            array[k] = leftArray[i]
            i++
        else:
            array[k] = rightArray[j]
            j++
        k++
    
    // Copiar elementos restantes
    while i < length(leftArray):
        array[k] = leftArray[i]
        i++, k++
    
    while j < length(rightArray):
        array[k] = rightArray[j]
        j++, k++
                `;
                break;
                
            case 'quick':
                elements.visualizationTitle.textContent = '⚡ QuickSort';
                
                // Ejemplo de vida real
                elements.realLifeText.innerHTML = `
                    <strong>👥 Como formar filas por altura en la escuela</strong><br><br>
                    Recuerda cuando el profesor te hacía formar fila por altura? QuickSort funciona así:<br><br>
                    1️⃣ <strong>Elige una persona de referencia</strong> (el pivote) - digamos tú<br>
                    2️⃣ <strong>Divide a todos:</strong> los más bajos que tú a la izquierda, los más altos a la derecha<br>
                    3️⃣ <strong>Repite en cada grupo:</strong> cada grupo elige su propia referencia y se subdivide<br>
                    4️⃣ <strong>Cuando todos estén en su lugar:</strong> ¡la fila está ordenada!<br><br>
                    <em>Ejemplo real:</em> Organizar libros en un estante - tomas uno al azar y colocas los más delgados
                    a la izquierda y los más gruesos a la derecha, luego repites en cada lado.
                `;
                showRealLifeAnimation('quick');
                
                elements.explanationText.innerHTML = `
                    <strong>QuickSort</strong> usa un pivote para particionar el array.
                    <br><br>
                    <strong>Complejidad:</strong> O(n log n) promedio, O(n²) peor caso.
                    <br><br>
                    <strong>Funcionamiento:</strong>
                    <br>1. Selecciona un pivote
                    <br>2. Particiona: elementos menores a la izquierda, mayores a la derecha
                    <br>3. Ordena recursivamente cada partición
                `;
                elements.pseudocode.textContent = `
QuickSort(array, low, high):
    if low < high:
        pi = Partition(array, low, high)
        QuickSort(array, low, pi - 1)
        QuickSort(array, pi + 1, high)

Partition(array, low, high):
    pivot = array[high]
    i = low - 1
    
    for j = low to high-1:
        if array[j] < pivot:
            i++
            swap(array[i], array[j])
    
    swap(array[i+1], array[high])
    return i + 1
                `;
                break;
        }
    } else {
        const algorithm = elements.searchAlgorithm.value;
        
        switch (algorithm) {
            case 'interpolation':
                elements.visualizationTitle.textContent = '📊 Búsqueda por Interpolación';
                
                // Ejemplo de vida real
                elements.realLifeText.innerHTML = `
                    <strong>📖 Como buscar una palabra en el diccionario</strong><br><br>
                    Cuando buscas una palabra en el diccionario, ¡usas interpolación sin saberlo!<br><br>
                    1️⃣ <strong>Estimas dónde está:</strong> Si buscas "Tigre", sabes que está hacia el final (letra T)<br>
                    2️⃣ <strong>Abres cerca de ahí:</strong> No empiezas desde la A ni revisas página por página<br>
                    3️⃣ <strong>Ajustas según lo que ves:</strong> Si caíste en "S", avanzas un poco; si en "U", retrocedes<br>
                    4️⃣ <strong>Repites hasta encontrarla:</strong> Cada vez te acercas más a la página correcta<br><br>
                    <em>Ejemplo real:</em> Buscar un contacto en tu teléfono deslizando hasta la letra aproximada,
                    o buscar una canción en una lista larga saltando según la letra inicial.
                `;
                showRealLifeAnimation('interpolation');
                
                elements.explanationText.innerHTML = `
                    <strong>Búsqueda por Interpolación</strong> estima la posición del valor buscado.
                    <br><br>
                    <strong>Complejidad:</strong> O(log log n) mejor caso, O(n) peor caso.
                    <br><br>
                    <strong>Funcionamiento:</strong>
                    <br>1. Estima la posición usando interpolación lineal
                    <br>2. Ajusta el rango de búsqueda según el valor encontrado
                    <br>3. Eficiente para datos uniformemente distribuidos
                `;
                elements.pseudocode.textContent = `
InterpolationSearch(array, target):
    low = 0
    high = length(array) - 1
    
    while low <= high and target >= array[low] and target <= array[high]:
        if low == high:
            if array[low] == target:
                return low
            return -1
        
        // Calcular posición estimada
        pos = low + ((target - array[low]) * (high - low)) / 
              (array[high] - array[low])
        
        if array[pos] == target:
            return pos
        
        if array[pos] < target:
            low = pos + 1
        else:
            high = pos - 1
    
    return -1
                `;
                break;
                
            case 'hash':
                elements.visualizationTitle.textContent = '# Búsqueda Hash';
                
                // Ejemplo de vida real
                elements.realLifeText.innerHTML = `
                    <strong>🗄️ Como organizar ropa en cajones etiquetados</strong><br><br>
                    La búsqueda hash es como cuando organizas tu ropa en cajones específicos:<br><br>
                    1️⃣ <strong>Creas categorías:</strong> Cajón 1 = Calcetines, Cajón 2 = Camisetas, Cajón 3 = Pantalones<br>
                    2️⃣ <strong>Guardas cada cosa en su cajón:</strong> Cuando lavas ropa, pones cada prenda donde corresponde<br>
                    3️⃣ <strong>Búsqueda instantánea:</strong> ¿Buscas calcetines? Vas directo al Cajón 1, ¡no revisas todo!<br>
                    4️⃣ <strong>Acceso directo:</strong> No necesitas revisar los otros cajones, sabes exactamente dónde está<br><br>
                    <em>Ejemplo real:</em> Tu lista de contactos del celular - escribes "M" y solo ves los que empiezan con M.
                    Los archivadores de oficina con letras A-Z. Los casilleros escolares numerados.
                `;
                showRealLifeAnimation('hash');
                
                elements.explanationText.innerHTML = `
                    <strong>Búsqueda Hash</strong> usa una función hash para acceso directo.
                    <br><br>
                    <strong>Complejidad:</strong> O(1) promedio, O(n) peor caso.
                    <br><br>
                    <strong>Funcionamiento:</strong>
                    <br>1. Construye una tabla hash del array
                    <br>2. Calcula el hash del valor buscado
                    <br>3. Accede directamente a la posición hash
                `;
                elements.pseudocode.textContent = `
HashSearch(array, target):
    // Construir tabla hash
    hashTable = new HashMap()
    
    for each value in array:
        hashKey = Hash(value)
        hashTable[hashKey] = value
    
    // Buscar
    searchKey = Hash(target)
    
    if hashTable.contains(searchKey):
        if hashTable[searchKey] == target:
            return searchKey
    
    return -1

Hash(value):
    return value % tableSize
                `;
                break;
        }
    }
}

// Animaciones de ejemplos de vida real
function showRealLifeAnimation(algorithm) {
    const container = elements.realLifeAnimation;
    container.innerHTML = '';
    
    switch (algorithm) {
        case 'heap':
            // Medallas organizándose en pirámide
            container.innerHTML = `
                <div class="real-life-item">🥇</div>
                <div class="real-life-item">🥈</div>
                <div class="real-life-item">🥉</div>
                <div class="real-life-item">🏅</div>
                <div class="real-life-item">🎖️</div>
            `;
            animateHeapExample();
            break;
            
        case 'merge':
            // Mazo de cartas dividiéndose
            container.innerHTML = `
                <div class="real-life-item">🃏 A</div>
                <div class="real-life-item">🂠 K</div>
                <div class="real-life-item">🂡 3</div>
                <div class="real-life-item">🃁 7</div>
                <div class="real-life-item">🂱 Q</div>
                <div class="real-life-item">🂢 5</div>
            `;
            animateMergeExample();
            break;
            
        case 'quick':
            // Personas de diferentes alturas
            container.innerHTML = `
                <div class="real-life-item">👶 1.2m</div>
                <div class="real-life-item">🧒 1.5m</div>
                <div class="real-life-item">🧑 1.7m</div>
                <div class="real-life-item">👨 1.8m</div>
                <div class="real-life-item">🧔 1.6m</div>
            `;
            animateQuickExample();
            break;
            
        case 'interpolation':
            // Diccionario con letras
            container.innerHTML = `
                <div class="real-life-item">📕 A-C</div>
                <div class="real-life-item">📗 D-G</div>
                <div class="real-life-item">📘 H-M</div>
                <div class="real-life-item">📙 N-S</div>
                <div class="real-life-item">📔 T-Z</div>
            `;
            animateInterpolationExample();
            break;
            
        case 'hash':
            // Cajones organizadores
            container.innerHTML = `
                <div class="real-life-item">🗄️ Cajón 1: 🧦</div>
                <div class="real-life-item">🗄️ Cajón 2: 👕</div>
                <div class="real-life-item">🗄️ Cajón 3: 👖</div>
                <div class="real-life-item">🗄️ Cajón 4: 🧥</div>
            `;
            animateHashExample();
            break;
    }
}

async function animateHeapExample() {
    const items = elements.realLifeAnimation.querySelectorAll('.real-life-item');
    await sleep(500);
    
    // Destacar la mejor medalla
    items[0].classList.add('highlight');
    await sleep(1000);
    items[0].classList.remove('highlight');
    
    // Siguiente mejor
    items[1].classList.add('highlight');
    await sleep(1000);
    items[1].classList.remove('highlight');
}

async function animateMergeExample() {
    const items = elements.realLifeAnimation.querySelectorAll('.real-life-item');
    await sleep(500);
    
    // Destacar grupos que se fusionan
    for (let i = 0; i < items.length; i++) {
        items[i].classList.add('highlight');
        await sleep(600);
        items[i].classList.remove('highlight');
    }
}

async function animateQuickExample() {
    const items = elements.realLifeAnimation.querySelectorAll('.real-life-item');
    await sleep(500);
    
    // Destacar el pivote (persona de referencia)
    items[2].classList.add('highlight');
    await sleep(1500);
    items[2].classList.remove('highlight');
}

async function animateInterpolationExample() {
    const items = elements.realLifeAnimation.querySelectorAll('.real-life-item');
    await sleep(500);
    
    // Simular búsqueda saltando a secciones
    items[4].classList.add('highlight'); // T-Z
    await sleep(800);
    items[4].classList.remove('highlight');
    
    items[3].classList.add('highlight'); // N-S
    await sleep(800);
    items[3].classList.remove('highlight');
}

async function animateHashExample() {
    const items = elements.realLifeAnimation.querySelectorAll('.real-life-item');
    await sleep(500);
    
    // Acceso directo a un cajón
    items[1].classList.add('highlight'); // Cajón 2
    await sleep(1500);
    items[1].classList.remove('highlight');
}
