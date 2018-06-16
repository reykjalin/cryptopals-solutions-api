import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
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
