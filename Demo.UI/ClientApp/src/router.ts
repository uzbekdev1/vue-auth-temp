import Vue from 'vue';
import Router from 'vue-router';
import Home from './views/Home.vue';

Vue.use(Router);

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
    },
    {
      path: '/counter',
      name: 'counter',
      component: () => import('./views/Counter.vue'),
    },
    {
      path: '/fetch-data',
      name: 'fetch-data',
      component: () => import('./views/FetchData.vue'),
    },
  ],
});
