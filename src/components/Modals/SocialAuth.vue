<template>
  <div class="social-auth-links">
    <a @click="externalLogin(0)" href="#" class="social-auth-link">
      <img src="../img/facebook.svg" />
      <span class="loader" :class="{loading: isLoading}"></span>
    </a>
    <!-- <a @click="externalLogin(2)" href="#" class="social-auth-link">
        <img src="../img/twitter.svg">
    </a>-->
    <a @click="externalLogin(1)" href="#" class="social-auth-link">
      <img src="../img/google-plus.svg" />
      <span class="loader" :class="{loading: isLoading}"></span>
    </a>
  </div>
</template>
<script>
import Vue from "vue";
import axios from "axios";
require("../../oauth/facebook/fb_sdk");
require("../../oauth/google/google_sdk");
export default {
  data() {
    return {
      isLoading: false
    };
  },
  mounted() {
    this.isFbReady = Vue.FB != undefined;
    window.addEventListener("FB_SDK_READY", this.onFbReady);
    window.addEventListener("GOOG_SDK_READY", this.onGoogReady);
  },
  beforeDestroy() {
    window.removeEventListener("FB_SDK_READY");
    window.removeEventListener("GOOG_SDK_READY");
  },
  methods: {
    onFbReady() {
      this.isFbReady = true;
    },
    onGoogReady() {
      this.isGoogReady = true;
    },
    externalLogin(provider) {
      switch (provider) {
        // FACEBOOK
        case 0:
          Vue.FB.login(response => {
            if (response.status == "connected") {
              this.socialLogIn(response.authResponse.accessToken, "facebook");
            }
          });
          break;

        // GOOGLE
        case 1:
          Vue.gapi.signIn().then(response => {
            this.socialLogIn(response.Zi.id_token, "google");
          });
          break;

        default:
          break;
      }
    },
    socialLogIn(token, network) {
      this.isLoading = true;
      let that = this;
      axios({
        method: "POST",
        url: "https://localhost:44357/api/account/oauth",
        data: JSON.stringify({ Token: token, Provider: network }),
        headers: {
          "Content-Type": "application/json charset=UTF-8"
        }
      })
        .then(function(params) {
          that.$root.$emit("completeLogin", params.data);
          that.isLoading = false;
        })
        .catch(function(params) {
          console.log(params);
          that.isLoading = false;
        });
    }
  }
};
</script>
<style scoped>
.social-auth-links {
  display: flex;
  margin: 20px 0;
}
.social-auth-link {
  width: 22%;
  margin: 0 auto;
  position: relative;
}
.social-auth-link img {
  width: 100%;
}
</style>