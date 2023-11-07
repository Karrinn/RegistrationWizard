import { defineConfig } from 'vite';
import angular from '@analogjs/vite-plugin-angular';

// https://vitejs.dev/config/
export default defineConfig({
    resolve: {
        mainFields: ['module'],
    },

    plugins: [angular()],
});