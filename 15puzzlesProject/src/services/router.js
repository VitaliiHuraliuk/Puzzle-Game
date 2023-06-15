import { createRouter, createWebHashHistory } from 'vue-router';
import Login from '../components/login.vue';
import Registration from '../components/Registration.vue';
import Game from '../components/Game.vue';

const routes = [
  { path: '/login', component: Login },
  { path: '/registration', component: Registration },
  { path: '/game', component: Game },
  { path: '/', redirect: '/login' }
];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

export default router;