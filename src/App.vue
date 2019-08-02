<template>
  <div id="app">
    <Header/>
    <Alert/>
    <Modals/>
    <router-view/>
    <Footer/>
  </div>
</template>
<script>
import Vue from "vue";

import BootstrapVue from "bootstrap-vue";
Vue.use(BootstrapVue);
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";

import Header from "./components/Header";
import Modals from "./components/Modals/MainModals";
import Footer from "./components/Footer";
import Alert from "./components/Alert";
export default {
  components: {
    Header,
    Modals,
    Footer,
    Alert
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
  font-size: 14px;
}
a {
  font-weight: 600;
}
.form-control {
  font-size: 14px;
}
.form-control:focus {
  border-color: #08023e;
  box-shadow: none;
}
.form-control::placeholder {
  font-weight: 300;
  color: #777;
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
  margin-bottom: 10px;
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
