<template>
  <b-modal size="sm" :hide-footer="true" id="loginModal" title="Log In">
    <h6>Log In using:</h6>
    <SocialAuth />
    <small>OR</small>
    <div class="auth-form-block">
      <b-form v-on:submit="logIn($event)">
        <div class="form-group left">
          <label for="Email">Email</label>
          <input v-model="login.Email" required class="form-control" type="email" />
        </div>
        <div class="form-group left">
          <label for="Password">Password</label>
          <input v-model="login.Password" required class="form-control" type="password" />
        </div>
        <p>
          <small>
            <a
              @click="$root.$emit('bv::show::modal', 'remindPassword')"
              href="#"
            >I don't remember my password</a>
          </small>
        </p>
        <div class="form-group centered">
          <b-btn
            :disabled="login.Email === '' || login.Password === '' || isLoading"
            :class="{loading: isLoading}"
            type="submit"
            class="btn-primary"
          >LOG IN
      <span class="loader" :class="{loading: isLoading}"></span>
          </b-btn>
        </div>
        <p>
          <small>
            <a
              @click="$root.$emit('bv::show::modal', 'signUpModal')"
              href="#"
            >I don't have an account</a>
          </small>
        </p>
      </b-form>
    </div>
  </b-modal>
</template>
<script>
import SocialAuth from "./SocialAuth";
import { mapGetters } from "vuex";
import store from "../../store";
import axios from "axios";

export default {
  store,
  data() {
    return {
      login: { Email: "", Password: "" },
      isFbReady: false,
      isGoogReady: false,
      isLoading: false
    };
  },
  mounted() {
    this.$root.$on("completeLogin", this.completeLogin);
  },
  beforeDestroy() {
    this.$root.$off("completeLogin", this.completeLogin);
  },
  components: {
    SocialAuth
  },
  computed: mapGetters({
    user: "getUser"
  }),
  methods: {
    logIn(e) {
      e.preventDefault();
      this.isLoading = true;
      let that = this;
      axios({
        method: "POST",
        url: "https://localhost:44357/api/account/login",
        data: this.login,
        headers: {
          "Content-Type": "application/json charset=UTF-8"
        }
      })
        .then(function(params) {
          that.completeLogin(params.data);
          that.isLoading = false;
        })
        .catch(function(params) {
          that.$store.dispatch('addAlert', params.response.data)
          console.log(params);
          that.isLoading = false;
        });
    },
    completeLogin(data) {
      this.$store.dispatch("setUser", data.data);
      this.$store.dispatch("setLoginState", true);
      localStorage.setItem("access_token", data.data.accessToken);
      this.$root.$emit("bv::hide::modal", "loginModal");
      this.$root.$emit("bv::hide::modal", "signUpModal");
      console.log(data);
      this.$store.dispatch('addAlert', data.message)
    }
  }
};
</script>
