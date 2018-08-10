import Vue from "vue";
import Vuex from "vuex";

import base64 from "./store/base64";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    base64
  },
  state: {
    base64: ""
  },
  mutations: {
    update(state, value) {
      state.base64 = value;
    }
  },
  actions: {}
});
