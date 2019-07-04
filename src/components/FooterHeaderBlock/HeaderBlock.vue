<template>
  <b-navbar
    class="islb-crypto-transfers--header fixed-top"
    toggleable="md"
    type="dark"
    variant="info"
  >
    <b-container>
      <b-navbar-brand href="#">ISLB</b-navbar-brand>
      <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>

      <b-collapse is-nav id="nav_collapse">
        <b-navbar-nav>
          <b-nav-item href="#">Contacts</b-nav-item>
          <b-nav-item href="#">FAQ</b-nav-item>
          <b-nav-item href="#">About</b-nav-item>
        </b-navbar-nav>

        <!-- Right aligned nav items -->
        <b-navbar-nav class="ml-auto">
          <b-nav-item-dropdown text="Lang" right>
            <b-dropdown-item href="#">EN</b-dropdown-item>
            <b-dropdown-item href="#">ES</b-dropdown-item>
            <b-dropdown-item href="#">RU</b-dropdown-item>
            <b-dropdown-item href="#">FA</b-dropdown-item>
          </b-nav-item-dropdown>
          <b-nav-item v-if="!isLoggedIn" @click="$root.$emit('bv::show::modal', 'loginModal')" href="#">Log In</b-nav-item>
          <b-nav-item v-if="isLoggedIn" href="#">Profile</b-nav-item>
        </b-navbar-nav>
      </b-collapse>
    </b-container>
  </b-navbar>
</template>
<script>
import { mapGetters } from "vuex";
export default {
  computed: mapGetters({
    isLoggedIn: 'getLoginState'
  })
};
</script>
<style>
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
</style>

