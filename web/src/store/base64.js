import { HTTP } from "@/main.js";

export default {
  state: {
    base64: ""
  },
  actions: {
    hexToBase64({ commit }, hex) {
      HTTP.post("base64/from/hex/", {
        hex: hex
      })
        .then(response => {
          commit("setBase64", response.data);
        })
        .catch(e => {
          if (typeof e.response !== "undefined") {
            let error = e.response.data !== "empty request" ? e.response.data : ""
            commit("setBase64", error);
          } else {
            commit("setBase64", "no response, server error");
          }
        });
    }
  },
  mutations: {
    setBase64(state, base64) {
      state.base64 = base64;
    }
  },
  getters: {
    getBase64(state) {
      return state.base64;
    }
  }
};
