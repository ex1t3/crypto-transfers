<template>
    <div class="personal-info-block main-page-block">
        <b-form class="col-sm-6 offset-md-3">
        <div class="form-group left">
          <label for="FirstName">First Name</label>
          <input v-model="user.firstName" required class="form-control" type="text">
        </div>
        <div class="form-group left">
          <label for="LastName">Last Name</label>
          <input v-model="user.lastName" required class="form-control" type="text">
        </div>
        <div class="form-group left">
          <label for="Email">Email</label>
          <input v-model="user.email" required class="form-control" type="text">
        </div>
        <div class="form-group centered">
            <b-btn type="submit" class="btn-primary">Save</b-btn>
        </div> 
      </b-form>
    </div>
</template>
<script>
import { mapGetters } from 'vuex';
export default {
    computed: mapGetters({
        user: 'getUser'
    })
}
</script>

