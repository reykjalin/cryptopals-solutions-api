<template>
  <div class="hello">
    <h1>Hex to base64 converter</h1>
    <div>
      <input type="text" v-model="data.hex" id="hex" v-on:keyup="convert" />
      <br/>
      <br/>
      <p>{{ base64 }}</p>
    </div>
  </div>
</template>

<script>
import { HTTP } from "@/main.js";

export default {
  name: "Base64component",
  props: {
    hex: String
  },
  computed: {
    base64() {
      return this.$store.state.base64;
    }
  },
  methods: {
    data: function() {
      return {
        hex: this.hex
      };
    },
    convert: function() {
      HTTP.post("base64/from/hex/", {
        hex: this.data.hex
      })
        .then(response => {
          this.$store.commit("update", response.data);
        })
        .catch(e => {
          if (typeof e.response !== "undefined") {
            this.$store.commit("update", e.response.data);
          } else {
            this.$store.commit("update", "no response, server error");
          }
        });
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
input {
  width: 60%;
}
</style>
