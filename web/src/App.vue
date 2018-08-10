<template>
  <div id="app">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <nav id="nav" class="navbar" role="navigation" aria-label="main-navigation">
      <div class="navbar-brand">
        <router-link class="navbar-item" to="/">
          <img src="./assets/logo.png" alt="Cryptopals" width="40" height="100">
        </router-link>

        <a role="button" class="navbar-burger" aria-label="menu" aria-expanded="false">
          <router-link aria-hidden="true" to="/">Home</router-link>
          <router-link aria-hidden="true" to="/about">About</router-link> 
          <router-link aria-hidden="true" to="/base64">base64</router-link>
        </a>
      </div>

      <div class="navbar-menu">
        <!-- navbar start, navbar end -->
        <router-link class="navbar-item" to="/">Home</router-link>
        <router-link class="navbar-item" to="/about">About</router-link> 
        <router-link class="navbar-item" to="/base64">base64</router-link>
      </div>
    </nav>

    <router-view/>
  </div>
</template>


<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}
</style>
