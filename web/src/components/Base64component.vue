<style>
.box {
  width: 90%;
  margin: 40px auto;
}
</style>

<template>
  <div class="base64">
    <h1 class="title">Hex to base64 converter</h1>
    <div>
      <input class="input" type="text" v-model="data.hex" id="hex" v-on:keyup="convert" />
      <div class="box">
        <div class="content">
          <p>{{ base64 }}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Base64component",
  computed: {
    base64() {
      return this.$store.getters.getBase64;
    }
  },
  methods: {
    data() {
      return {
        hex: String
      };
    },
    convert: function() {
      this.$store.dispatch("hexToBase64", this.data.hex);
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
