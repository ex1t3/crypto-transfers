<script>
import store from "../store";
import axios from "axios";
import { mapGetters } from "vuex";
export default {
  store,
  computed: mapGetters({
    isLoggedIn: "getLoginState",
    isPageLoaded: "isPageLoaded"
  }),
  beforeMount () {
    this.checkLoginState()
  },
  methods: {
    checkLoginState() {
      if (this.isPageLoaded) if (!this.isLoggedIn) return this.redirectToLogin();
        setTimeout(() => { this.checkLoginState()}, 100);
    },
    redirectToLogin() {
      if (this.$router.currentRoute.name === 'home') return;
      this.$store.dispatch("addAlert", {
        message: "Please, log in first",
        type: "1",
        duration: 4000
      });
      this.$router.push({ name: "home" });
      this.$root.$emit("bv::show::modal", "loginModal");
    }
  }
};
</script>
<style>
.single-line-group {
  display: flex;
}

.cell-1 {
  width: 8.1%;
}
.cell-2 {
  width: 16.2%;
}
.cell-3 {
  width: 24.3%;
}
.cell-4 {
  width: 32.4%;
}
.cell-5 {
  width: 40.5%;
}
.cell-6 {
  width: 48.6%;
}
.cell-7 {
  width: 56.7%;
}
.cell-8 {
  width: 64.8%;
}
.cell-9 {
  width: 72.9%;
}
.cell-10 {
  width: 81%;
}
.cell-11 {
  width: 89.1%;
}
.cell-12 {
  width: 97.2%;
}

.single-line-group * {
  margin: 0 auto;
}
</style>
