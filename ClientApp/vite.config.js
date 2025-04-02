import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';

export default defineConfig({
    plugins: [react()],
    esbuild: {
        jsxInject: `import React from 'react'`  // Para asegurar que React est� disponible en JSX
    }
});
