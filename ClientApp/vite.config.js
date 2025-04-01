import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';

export default defineConfig({
    plugins: [react()],
    server: {
        port: 5173,
        proxy: {
            "/api": {
                target: "http://localhost:5170",
                changeOrigin: true,
                secure: false,
            },
        },
    },
    esbuild: {
        loader: "jsx",
        include: /src\/.*\.js$/, // Aplica a archivos .js dentro de /src
    },
});
