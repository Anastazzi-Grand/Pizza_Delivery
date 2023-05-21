import { createApp } from 'vue'
import App from './App.vue'
import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap"
import router from '@/router/router';
import VueAxios from 'vue-axios';
import axios from 'axios';

const app = createApp(App);
app.use(router);
app.use(VueAxios, axios);
app.mount('#app');
