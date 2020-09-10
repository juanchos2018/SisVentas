import '@babel/polyfill'
import Vue from 'vue'
import './plugins/vuetify'
import App from './App.vue'
import router from './router'
import store from './store'
import axios from 'axios'
//https://localhost:44388/

//http://localhost:63038
Vue.config.productionTip = false
axios.defaults.baseURL='http://localhost:52591/'
new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
