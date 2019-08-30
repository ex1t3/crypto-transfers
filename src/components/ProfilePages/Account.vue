<template>
  <b-form class="col-sm-6 col-md-4 offset-md-4">
    <div class="form-group left">
      <label>Email</label>
      <input class="form-control" v-model="user.email" />
    </div>
    <div v-if="!user.isEmailVerified" class="form-group left">
      <small>*To get access to operations and transactions your email should be verified.</small>
    </div>
    <div class="form-group">
      <b-btn @click="verifyEmail" :disabled="isBtnLoading" v-if="!user.isEmailVerified" class="btn-primary btn-block">
        Verify
      <span class="loader" :class="{loading: isBtnLoading}"></span>
      </b-btn>
      <b-btn v-if="user.isEmailVerified" class="btn-primary btn-block">Update</b-btn>
    </div>
  </b-form>
</template>
<script>
import { mapGetters } from "vuex";
import axios from "axios";
import store from "../../store";
export default {
  store,
  data () {
    return {
      isBtnLoading: false
    }
  },
  computed: mapGetters({
    user: "getUser"
  }),
  methods: {
    verifyEmail() {
      this.isBtnLoading = true;
      let that = this;
      axios({
        method: "POST",
        url: "https://localhost:44357/api/email/verify_email",
        headers: {
          Authorization: "Bearer " + localStorage.getItem("access_token")
        }
      }).then((response) => {
        this.isBtnLoading = false
        that.$store.dispatch('addAlert', response.data)
      }).catch((error) => {
        this.isBtnLoading = false
        console.log(error);
      });
    }
  }
};
</script>

