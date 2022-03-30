import { fileURLToPath, URL } from 'url'

import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue()], 
  server: {
    // proxy: {
    //     '/socket.io': {
    //         target: 'ws://localhost:3000',
    //         ws: true
    //     }
    // },
    // https: true,
    hmr: {
      host: 'localhost',
      port: 3000,
      protocol: 'ws'
    }
  },
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url))
    }
  }
})
