<template>
  <b-modal size="sm" :hide-footer="true" id="remindPassword" title="Remind Password">
    <div class="auth-form-block">
      <b-form class="from-horizontal">
        <div class="form-group left">
          <label for="Remind_Email">Email</label>
          <input class="form-control" type="email" name="Email" id="Remind_Email">
        </div>
        <div class="form-group centered">
            <b-btn type="submit" class="btn-primary">REMIND</b-btn>
        </div> 
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
