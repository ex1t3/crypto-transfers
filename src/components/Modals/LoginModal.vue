<template>
  <b-modal size="sm" :hide-footer="true" id="loginModal" title="Log In">
    <h6>Log In using:</h6>
    <div class="social-auth-links">
      <a href="#" class="social-auth-link">
        <img src="../img/facebook.svg">
      </a>
      <a href="#" class="social-auth-link">
        <img src="../img/twitter.svg">
      </a>
      <a href="#" class="social-auth-link">
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
import { mapGetters } from 'vuex'
import store from '../../store'
import axios from 'axios'

export default {
  store,
  data() {
    return {
      login: {Email: '', Password: ''}
    }
  },
  computed: mapGetters({
    user: 'getUser'
  }),
  methods: {
    logIn (e) {
      e.preventDefault()
      axios({
        method: 'POST',
        url: 'https://localhost:44357/api/account/login',
        data: this.login,
        header: {
          'Content-Type': 'application/json'
        }
      }).then(function (params) {
        this.$store.commit('setUser', params.data)
      }).catch(function (params) {
        console.log(params)
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
