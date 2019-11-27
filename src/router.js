import Vue from "vue";
import Router from "vue-router";
import Home from "./views/Home.vue";
import Profile from "./views/Profile.vue";
import Dashboard from "./views/Dashboard.vue";
import Verify from "./views/Verify.vue";

const Legal = resolve => {
  require.ensure(['./views/LegalInfo.vue'], () => {
    resolve(require('./views/LegalInfo.vue'))
  });
}

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
      component: Profile
    },
    {
      path: "/dashboard",
      name: "dashboard",
      component: Dashboard
    },
    {
      path: "/legal",
      name: "terms",
      component: Legal,
      children: [
        {
          path: "terms",
          name: "terms"
        },
        {
          path: "privacy",
          name: "privacy"
        },
        {
          path: "cookies",
          name: "cookies"
        },
      ]
    }
  ]
});
