<template>
  <b-form class="col-sm-6 col-md-4 offset-md-4">
    <div class="form-group left">
      <label>BTC Address (Bitcoin)</label>
      <input class="form-control" v-model="user.wallets.btc" />
    </div>
    <div class="form-group left">
      <label>ETH Address (Ethereum)</label>
      <input class="form-control" v-model="user.wallets.eth" />
    </div>

    <div class="form-group left">
      <small>*Theese adresses will be stored and linked to your account. You can use them for your next transfers and withdrawals.</small>
    </div>
    <div class="form-group">
      <b-btn @click="saveWallets" type="button" class="btn-primary btn-block">SAVE</b-btn>
    </div>
  </b-form>
</template>
<script>
import { mapGetters } from "vuex";
import store from "../../store";
import axios from "axios";

export default {
  store,
  computed: mapGetters({
    user: "getUser"
  }),
  methods: {
    saveWallets() {
      let flag = this.user.wallets.btc === this.user.wallets.eth;
      switch (flag) {
        case false: {
          let that = this;
          axios({
            method: "POST",
            url: "https://localhost:44357/api/account/update_wallets",
            data: this.user.wallets,
            headers: {
              Authorization: "Bearer " + localStorage.getItem("access_token")
            }
          })
            .then(response => {
              this.$store.dispatch("addAlert", response.data);
            })
            .catch(response => {
              console.log(response);
            });
          break;
        }

        default:
          this.$store.dispatch("addAlert", {
            duration: 3000,
            message: "Fill correctly at least one address",
            type: "1"
          });
      }
    }
  }
};
</script>

