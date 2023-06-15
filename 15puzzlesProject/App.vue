<template>
  <div id="app">
    <router-view></router-view>
    <router-view name="game"></router-view>
  </div>
</template>

<script>
import { createRouter, createWebHashHistory } from 'vue-router';
import Login from './src/components/login.vue';
import Registration from './src/components/Registration.vue';
import Game from './src/components/Game.vue';

const routes = [
  { path: '/login', component: Login },
  { path: '/registration', component: Registration },
  { path: '/game', component: Game, name: 'game' }, 
];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

export default {
  name: 'App',
  components: {
    Login,
    Registration,
    Game,
  },
  router,
};
</script>

<style>

.router-view[name="game"] {
  display: none;
}
</style>