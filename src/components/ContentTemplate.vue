<template>
  <div class="col-sm-12">
    <!-- PROFILE -->
    <div class="content-page">
      <PersonalInfo v-if="currentPage == 'personalInfo'" />
      <Verification v-if="currentPage == 'identityVerifiation'" />
      <Account v-if="currentPage == 'account'" />
      <WithdrawAddresses v-if="currentPage == 'withdrawAddresses'" />

      <!-- DASHBOARD -->
      <Overview v-if="currentPage == 'overviewDashboard'" />
      <Transactions v-if="currentPage == 'transactions'" />
    </div>
  </div>
</template>
<script>
import PersonalInfo from "../components/ProfilePages/PersonalInfo";
import Verification from "../components/ProfilePages/IdentityVerification";
import Account from "../components/ProfilePages/Account";
import WithdrawAddresses from "../components/ProfilePages/WithdrawAddresses";

import Overview from "../components/DashboardPages/Overview";
import Transactions from "../components/DashboardPages/Transactions";
import { mapGetters } from "vuex";
export default {
  props: ["items"],
  components: {
    PersonalInfo,
    Verification,
    Account,
    WithdrawAddresses,
    Overview,
    Transactions
  },
  computed: mapGetters({
    currentPage: "getCurrentPage"
  })
};
</script>
<style scoped>
div {
  font-size: 12px;
}
.content-page {
  width: 100%;
  min-height: 70vh;
  padding-top: 20px;
}
</style>
