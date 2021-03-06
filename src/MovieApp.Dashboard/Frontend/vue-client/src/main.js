import { createApp } from 'vue'
import Notifications from '@kyvg/vue3-notification'
import useVuelidate from '@vuelidate/core'
import App from './App.vue'
import router from './router'
import mitt from 'mitt'

import store from './store/index'
const emitter = mitt()
const app = createApp(App)

app.use(router)
app.use(Notifications)
app.use(useVuelidate)
app.use(store);

app.config.globalProperties.emitter = emitter
app.mount('#app')
