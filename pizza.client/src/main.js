import { createApp } from 'vue'
import App from './App.vue'
import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap"
import {config} from './config.js';
import { MockDataService } from './services/mock.data.service';
import { DataService } from './services/data.service';

const app = createApp(App);
app.mount('#app');
console.log(config)
app.provide('dataService', config.demo ? new MockDataService() : new DataService())

