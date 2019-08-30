import Vue from "vue";
import Router from "vue-router";
import Home from "./views/Home.vue";
import Profile from "./views/Profile.vue";
import Dashboard from "./views/Dashboard.vue";
import Verify from "./views/Verify.vue";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "home",
      component: Home
    },
    {
      path: "/verify",
      name: "verify",
      component: Verify
    },
    {
      path: "/profile",
      name: "profile",
      component: Profile,
    },
    {
      path: "/dashboard",
      name: "dashboard",
      component: Dashboard
    }
  ]
});
