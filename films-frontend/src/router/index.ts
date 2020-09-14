import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Home from '../views/Home.vue'
import Films from '../views/Films.vue'
import AddFilm from '../components/AddFilm.vue'
import VFilm from '../views/VFilm.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/films',
    name: 'Films',
    component: Films 
  },
  {
    path: '/add',
    name: 'AddFilm',
    component: AddFilm
  },
  {
    path: '/currentFilm/:id',
    name: 'VFilm',
    props: true,
    component: VFilm
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
