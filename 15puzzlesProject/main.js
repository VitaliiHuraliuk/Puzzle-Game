import { createApp } from 'vue';
import App from './App.vue';
import router from './src/services/router.js';
import './src/assets/css/GameStyle.css';
import './src/assets/css/LoginStyle.css';
import './src/assets/css/RegistrationStyle.css';

const app = createApp(App);
app.use(router);

app.mount('#app');