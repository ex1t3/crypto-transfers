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
      <b-form class="from-horizontal">
        <div class="form-group left">
          <label for="Email">Email</label>
          <input class="form-control" type="email" name="Email" id="Email">
        </div>
        <div class="form-group left">
          <label for="Password">Password</label>
          <input class="form-control" type="password" name="Password" id="Password">
        </div>
        <p><small><a @click="$root.$emit('bv::show::modal', 'remindPassword')" href="#">I don't remember my password</a></small></p>
        <div class="form-group centered">
            <b-btn type="submit" class="btn-primary">LOG IN</b-btn>
        </div>       
        <p><small><a @click="$root.$emit('bv::show::modal', 'signUpModal')" href="#">I don't have an account</a></small></p>
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
</style>
