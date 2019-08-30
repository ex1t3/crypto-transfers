<template>
  <b-form class="col-sm-6 col-md-4 offset-md-4">
    <div class="form-group left">
      <label>BTC Address (Bitcoin)</label>
      <input class="form-control" v-model="user.wallets.BTC" />
    </div>
    <div class="form-group left">
      <label>ETH Address (Ethereum)</label>
      <input class="form-control" v-model="user.wallets.ETH" />
    </div>

    <div class="form-group left">
      <small>*Theese adresses will be stored and linked to your account. You can use them for your next transfers and withdrawals.</small>
    </div>
    <div class="form-group">
      <b-btn class="btn-primary btn-block">SAVE</b-btn>
    </div>
  </b-form>
</template>
<script>
import { mapGetters } from "vuex";
export default {
  computed: mapGetters({
    user: "getUser"
  })
};
</script>

