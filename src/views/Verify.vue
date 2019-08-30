<template>
  <b-container class="verification-layer">
    <b-row>
      <div class="col-sm-6 col-md-6 offset-md-3">Verifying your code....</div>
    </b-row>
  </b-container>
</template>
<script>
import axios from "axios";
import store from "../store";
export default {
  store,
  mounted() {
    let location = window.location.href.replace("#/", "");
    let link = new URL(location);
    let code = link.searchParams.get("verification");
    if (code === null) return;
    let that = this;
    axios({
      method: "POST",
      url: "https://localhost:44357/api/email/confirm_email",
      data: JSON.stringify(code),
      headers: {
        Authorization: "Bearer " + localStorage.getItem("access_token"),
        "Content-Type": "application/json; charset=utf-8"
      }
    })
      .then(response => {
        that.$store.dispatch("addAlert", response.data);
        that.$router.push({ name: "home" });
      })
      .catch(error => {
        that.$router.push({ name: "home" });
        that.$store.dispatch("addAlert", error.response.data);
      });
  }
};
</script>
<style scoped>
.verification-layer {
  padding-top: 100px;
  min-height: 77vh;
}
</style>


