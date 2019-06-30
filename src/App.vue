<template>
  <div id="app">
    <Header/>
    <Modals/>
    <router-view/>
  </div>
</template>
<script>
import Vue from "vue";
import BootstrapVue from "bootstrap-vue";
Vue.use(BootstrapVue);
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";

import Header from "./components/FooterHeaderBlock/HeaderBlock";
import Modals from "./components/Modals/MainModals";
export default {
  components: {
    Header,
    Modals
  }
};
</script>

<style>
h1,
h2,
h3,
h4,
h5,
h6 {
  margin: 1.5rem 0;
  font-weight: 300;
}
body {
  background: #fafafa;
}
a {
  font-weight: 600;
}
.btn-primary {
  color: #ffffff;
  background-color: #4b41ab;
  border-color: #4b41ab;
}
.btn-primary:hover {
  background-color: #3d2798;
  border-color: #3d2798;
}
.btn-primary:not(:disabled):not(.disabled):active:focus {
  box-shadow: 0 0 0 0.2rem rgba(104, 93, 199, 0.27);
}
.btn-primary:not(:disabled):not(.disabled):focus {
  box-shadow: 0 0 0 0.2rem rgba(104, 93, 199, 0.27);
}
.btn-primary:not(:disabled):not(.disabled):active {
  background-color: #7369c8;
  border-color: #7369c8;
}
.form-control:focus {
  border-color: #08023e;
  box-shadow: none;
}
.form-control::placeholder {
  font-weight: 300;
  color: #ddd;
}
.input-lg {
  height: 48px;
  padding: 10px 15px;
  font-size: 18px;
}
.left {
  text-align: left;
}
.right {
  text-align: right;
}
.col-sm-2,
.col-sm-3,
.col-sm-4,
.col-sm-5,
.col-sm-6,
.col-sm-7,
.col-sm-8,
.col-sm-10 {
  float: left;
}
.centered {
  text-align: center;
}
@import url("https://fonts.googleapis.com/css?family=Poppins:300,400,600");
#app {
  font-family: "Poppins", Helvetica, Arial, sans-serif;
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
@media (max-width: 700px){
  h2 {
    font-size: 1.25rem;
    margin: 1rem;
  }
  h3 {
    font-size: 1.1rem;
    margin: 0.5rem;
  }
  h4 {
    font-size: 1rem;
    margin: 0.5rem;

  }
  h5 {
    font-size: 0.9rem;
    margin: 0.3rem;
  }
}
</style>
