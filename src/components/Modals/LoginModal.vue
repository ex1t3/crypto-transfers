<template>
  <b-modal size="sm" :hide-footer="true" id="loginModal" title="Log In">
    <h6>Log In using:</h6>
    <SocialAuth/>
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
import SocialAuth from './SocialAuth';
import { mapGetters } from 'vuex';
import store from '../../store';
import axios from 'axios';

export default {
  store,
  data() {
    return {
      login: {Email: '', Password: ''},
      isFbReady: false,
      isGoogReady: false,
    }
  },
  mounted () {
    this.$root.$on('completeLogin', this.completeLogin)
  },
  beforeDestroy () {
    this.$root.$off('completeLogin', this.completeLogin)
  },
  components: {
    SocialAuth,
  },
  computed: mapGetters({
    user: 'getUser'
  }),
  methods: {
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
        that.completeLogin(params.data);
      }).catch(function (params) {
        console.log(params);
      });
    },
    completeLogin (data) {
      this.$store.commit('setUser', data);
      this.$store.commit('setLoginState', true);
      sessionStorage.setItem('access_token', data.token);
      this.$root.$emit('bv::hide::modal', 'loginModal');
      this.$root.$emit('bv::hide::modal', 'signUpModal');
    }
  }
}
</script>
