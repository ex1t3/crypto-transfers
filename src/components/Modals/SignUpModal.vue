<template>
  <b-modal size="sm" :hide-footer="true" id="signUpModal" title="Sign Up">
    <h6>Sign Up using:</h6>
    <SocialAuth/>
    <small>OR</small>
    <div class="auth-form-block">
      <b-form v-on:submit="logIn($event)" class="from-horizontal">
        <div class="form-group left">
          <label for="SignUp_Email">Email</label>
          <input required v-model="login.Email" class="form-control" type="email">
        </div>
        <div class="form-group left">
          <label for="SignUp_Password">Password</label>
          <input required v-model="login.Password" class="form-control" type="password">
        </div>
        <p>
          <input v-model="login.Agreement" id="accept_terms" required type="checkbox">
          <label for="accept_terms">I accept
            <a href="#">Terms of Use</a>
          </label>
        </p>
        <div class="form-group centered">
          <b-btn :disabled="login.Email === '' || login.Password === '' || !login.Agreement" type="submit" class="btn-primary">SIGN UP</b-btn>
        </div>
        <p>
          <small>
            <a @click="$root.$emit('bv::show::modal', 'loginModal')" href="#">I have an account</a>
          </small>
        </p>
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
      login: {Email: '', Password: '', Agreement: false}
    }
  },
  components: {
    SocialAuth
  },
  computed: mapGetters({
    user: 'getUser'
  }),
  methods: {
    logIn (e) {
      e.preventDefault()
      axios({
        method: 'POST',
        url: 'https://localhost:44357/api/account/register',
        data: this.login,
        header: {
          'Content-Type': 'application/json'
        }
      }).then(function (params) {
        that.$root.$emit('completeLogin', params.data);
      }).catch(function (params) {
        console.log(params);
      });
    }
  }
}
</script>
