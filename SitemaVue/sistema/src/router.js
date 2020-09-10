import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import Categoria from './components/Categoria.vue'
import Loginvista from './components/Loginvista.vue'
import Rol from './components/Rol.vue'
import Usuario from './components/Usuario.vue'

Vue.use(Router)

var router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      meta :{
        administrador :true,
        almacenero: true,
        vendedor: true
      }
    },
    {
      path: '/categorias',
      name: 'categorias',
      component: Categoria
     
    }

    ,
    {
      path: '/usuarios',
      name: 'usuarios',
      component: Usuario
     
    }
  
,    {
      path: '/roles',
      name: 'roles',
      component: Rol,
      
    }

    ,
    {
      path: '/login',
      name: 'login',
      component: Loginvista
     
    }
  ]
})



export default router
