<template>
  <b-modal size="sm" :hide-footer="true" id="loginModal" title="Log In">
    <h6>Log In using:</h6>
    <div class="social-auth-links">
      <a @click="externalLogin(0)" href="#" class="social-auth-link">
        <img src="../img/facebook.svg">
      </a>
      <a @click="externalLogin(2)" href="#" class="social-auth-link">
        <img src="../img/twitter.svg">
      </a>
      <a @click="externalLogin(1)" href="#" class="social-auth-link">
        <img src="../img/google-plus.svg">
      </a>
    </div>
    <small>OR</small>
    <div class="auth-form-block">
      <b-form v-on:submit="logIn($event)" class="from-horizontal">
        <div class="form-group left">
          <label for="Email">Email</label>
          <input v-model="login.Email" required class="form-control" type="email">
        </div>
        <div class="form-group left">
          <label for="Password">Password</label>
          <input v-model="login.Password" required class="form-control" type="password">
        </div>
        <p><small><a @click="$root.$emit('bv::show::modal', 'remindPassword')" href="#">I don't remember my password</a></small></p>
        <div class="form-group centered">
            <b-btn :disabled="login.Email === '' || login.Password === ''" type="submit" class="btn-primary">LOG IN</b-btn>
        </div>       
        <p><small><a @click="$root.$emit('bv::show::modal', 'signUpModal')" href="#">I don't have an account</a></small></p>
      </b-form>
    </div>
  </b-modal>
</template>
<script>
import Vue from 'vue'
import { mapGetters } from 'vuex'
import store from '../../store'
import axios from 'axios'
require('../../oauth/facebook/fb_sdk')
require('../../oauth/google/google_sdk')

export default {
  store,
  data() {
    return {
      login: {Email: '', Password: ''},
      isFbReady: false,
      isGoogReady: false,
    }
  },
  computed: mapGetters({
    user: 'getUser'
  }),
  mounted () {
    this.isFbReady = Vue.FB != undefined;
    window.addEventListener('FB_SDK_READY', this.onFbReady);
    window.addEventListener('GOOG_SDK_READY', this.onGoogReady);
  },
  beforeDestroy () {
    window.removeEventListener('FB_SDK_READY');
    window.removeEventListener('GOOG_SDK_READY');
  },
  methods: {
    onFbReady () {
      this.isFbReady = true;
    },
    onGoogReady () {
      this.isGoogReady = true;
    },
    externalLogin(provider) {
      switch (provider) {

        // FACEBOOK
        case 0:
          Vue.FB.login((response) => {
            if (response.status == 'connected') {
              this.logInFB(response.authResponse.accessToken);
            }
          });
          break;

        // GOOGLE
        case 1:
          console.log(Vue.gapi);
          Vue.gapi.signIn().then((response) => {
            console.log(response.Zi.id_token);
          });
          break;

        default:
          break;
      }
    },
    logInFB (token) {
      let that = this;
      axios({
        method: 'POST',
        url: 'https://localhost:44357/api/account/facebook',
        data: JSON.stringify(token),
        headers: {
          'Content-Type': 'application/json charset=UTF-8',
        }
      }).then(function (params) {
        that.$store.commit('setUser', params.data);
        sessionStorage.setItem('access_token', params.data.token);
      }).catch(function (params) {
        console.log(params);
      });
    },
    logIn (e) {
      e.preventDefault()
      let that = this;
      axios({
        method: 'POST',
        url: 'https://localhost:44357/api/account/login',
        data: this.login,
        headers: {
          'Content-Type': 'application/json'
        }
      }).then(function (params) {
        that.$store.commit('setUser', params.data);
        sessionStorage.setItem('access_token', params.data.token);
        that.check()
      }).catch(function (params) {
        console.log(params);
      });
    },
    check () {
      axios({
        method: 'GET',
        url: 'https://localhost:44357/api/values',
        headers: {
           Authorization: 'Bearer ' + sessionStorage.getItem('access_token')
        }
      }).then(function (params) {
        
      }).catch(function (params) {
        console.log(params);
      });
    }
  }
}
</script>

<style scoped>
.social-auth-links {
  display: flex;
  margin: 20px 0;
}
.social-auth-link {
  width: 22%;
  margin: 0 auto;
}
.social-auth-link img {
  width: 100%;
}
</style>
