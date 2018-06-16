import devtools from "@vue/devtools";
import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import "./registerServiceWorker";
import axios from "axios";

Vue.config.productionTip = false;

if (process.env.NODE_ENV === "development") {
  devtools.connect();
}

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
