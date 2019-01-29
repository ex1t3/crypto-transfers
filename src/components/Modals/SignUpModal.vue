<template>
  <b-modal size="sm" :hide-footer="true" id="signUpModal" title="Sign Up">
    <h6>Sign Up using:</h6>
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
      <b-form class="from-horizontal">
        <div class="form-group left">
          <label for="SignUp_Email">Email</label>
          <input class="form-control" type="email" name="Email" id="SignUp_Email">
        </div>
        <div class="form-group left">
          <label for="SignUp_Password">Password</label>
          <input class="form-control" type="password" name="Password" id="SignUp_Password">
        </div>
        <p>
          <input id="accept_terms" required type="checkbox">
          <label for="accept_terms">I accept
            <a href="#">Terms of Use</a>
          </label>
        </p>
        <div class="form-group centered">
          <b-btn type="submit" class="btn-primary">SIGN UP</b-btn>
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
p label[for="accept_terms"] {
  font-size: 14px;
}
</style>
