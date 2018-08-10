import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import "./registerServiceWorker";
import axios from "axios";

import "bulma/css/bulma.css";

Vue.config.productionTip = false;

export const HTTP = axios.create({
  baseURL: "http://localhost:5000/api/",
  headers: {
    Accept: "application/json"
  }
});

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
