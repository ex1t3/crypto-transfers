<template>
  <b-navbar
    class="islb-crypto-transfers--header fixed-top"
    toggleable="md"
    type="dark"
    variant="info"
  >
    <b-container>
      <b-navbar-brand href="#" @click="$router.push({name: 'home'})">ISLB</b-navbar-brand>
      <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>

      <b-collapse is-nav id="nav_collapse">
        <b-navbar-nav>
          <b-nav-item href="#">Contacts</b-nav-item>
          <b-nav-item href="#">FAQ</b-nav-item>
          <b-nav-item href="#">About</b-nav-item>
        </b-navbar-nav>

        <!-- Right aligned nav items -->
        <b-navbar-nav class="ml-auto">
          <b-nav-item-dropdown v-if="!isLoggedIn" text="Lang" right>
            <b-dropdown-item href="#">EN</b-dropdown-item>
            <b-dropdown-item href="#">ES</b-dropdown-item>
            <b-dropdown-item href="#">RU</b-dropdown-item>
            <b-dropdown-item href="#">FA</b-dropdown-item>
          </b-nav-item-dropdown>
          <b-nav-item
            :class="{'current-route': currentRoute === 'dashboard'}"
            v-if="isLoggedIn"
            @click="$router.push({name: 'dashboard'})"
            href="#"
          >Dashboard</b-nav-item>
          <b-nav-item
            v-if="!isLoggedIn"
            @click="$root.$emit('bv::show::modal', 'loginModal')"
            href="#"
          >Log In</b-nav-item>
          <b-nav-item-dropdown v-if="isLoggedIn" :text="user.email" middle>
            <b-dropdown-item href="/#/profile">Profile</b-dropdown-item>
            <b-dropdown-item href="/#/dashboard">Dashboard</b-dropdown-item>
            <b-dropdown-divider></b-dropdown-divider>
            <b-dropdown-item @click="logOut" href="#">Logout</b-dropdown-item>
          </b-nav-item-dropdown>
        </b-navbar-nav>
      </b-collapse>
    </b-container>
  </b-navbar>
</template>
<script>
import { mapGetters } from "vuex";
import store from "../store";
import axios from "axios";

import SocketHandler from "../mixins/socket-handler";

export default {
  store,
  mixins: [SocketHandler],
  computed: mapGetters({
    isLoggedIn: "getLoginState",
    user: "getUser"
  }),
  data () {
    return {
      currentRoute: this.$route.name,
    }
  },
  watch: {
    $route: function(to, from) {
      this.currentRoute = to.name;
    }
  },
  beforeMount() {
    let token = localStorage.getItem("access_token");
    let that = this;
    if (token != null) {
      axios({
        method: "GET",
        url: "https://localhost:44357/api/account/check",
        headers: {
          Authorization: "Bearer " + token
        }
      })
        .then(params => {
          that.$store.dispatch("loadPage");
          that.$store.dispatch("setUser", params.data);
          that.$store.dispatch("setLoginState", true);
        })
        .catch(error => {
          console.log(error);
          that.$store.dispatch("loadPage");
        });
    }
  },
  methods: {
    logOut() {
      this.$router.push({ name: "home" });
      this.$store.dispatch("setLoginState", false);
      axios({
        method: "POST",
        url: "https://localhost:44357/api/account/logout",
        headers: {
          Authorization: "Bearer " + localStorage.getItem("access_token")
        }
      })
        .then(function(params) {
          localStorage.removeItem("access_token");
        })
        .catch(function(params) {
          console.log(params);
        });
    }
  }
};
</script>
<style>
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
.nav-item {
  text-align: left;
}
.navbar-toggler {
  border: none;
}
.navbar {
  width: 100%;
  padding: 1rem 1rem;
  box-shadow: 0 5px 20px rgba(0, 0, 0, 0.2901960784313726);
}
.islb-crypto-transfers--header {
  background: linear-gradient(225deg, #3d2ebf, #6559cc);
}
.navbar .nav-item {
  padding: 0 10px;
}
.navbar-brand {
  display: inline-block;
  padding-top: 0.3125rem;
  padding-bottom: 0.3125rem;
  margin-right: 1rem;
  font-size: 1.25rem;
  line-height: inherit;
  white-space: nowrap;
  font-size: 1.7rem;
  letter-spacing: 10px;
  border: 1px solid;
  padding: 5px 10px;
  font-weight: 300;
  padding-left: 20px;
}
@media (max-width: 768px) {
  .navbar-collapse {
    margin-top: 0.5rem;
  }
  .navbar-collapse::before {
    content: "";
    position: absolute;
    width: 100%;
    height: 1px;
    left: 0;
    background: #5f53ca;
  }
  .navbar-nav {
    padding-top: 15px;
  }
  .navbar .container {
    max-width: 740px;
  }
}
.current-route {
  background-color: #fafafa;
  transition: 0.5s;
}
.current-route a.nav-link,
.current-route a.nav-link:focus,
.current-route a.nav-link:active,
.current-route a.nav-link:hover {
  color: #342f67 !important;
}
.dropdown-item {
  font-size: 14px;
}
.loader::after {
  content: "";
  position: relative;
  display: block;
  width: 100%;
  height: 100%;
  border-radius: 50%;
  transform: scale(0);
  background: #1c0058;
  animation: blink 0.5s ease-in infinite;
}
.loader {
  transform: translate3d(-50%, -50%, 0);
  visibility: hidden;
  position: absolute;
  left: 50%;
  top: 50%;
  width: 20px;
  height: 20px;
}
.loading.loader {
  visibility: visible;
}
.btn-primary {
  color: #ffffff;
  background-color: #4b41ab;
  border-color: #4b41ab;
  position: relative;
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
.btn-bordered {
  background: #fafafa;
  color: #4b41ab;
}

.form-control[disabled="disabled"],
.btn[disabled="disabled"] {
  background-color: #b1abe3;
  border: none;
  cursor: not-allowed;
}
@keyframes blink {
  to {
    transform: scale(1.5);
    opacity: 0;
  }
}
</style>

