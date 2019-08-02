<template>
<div class="col-sm-12">
<!-- PROFILE -->
<PersonalInfo v-if="currentPage == 'personalInfo'"/>
<Verification v-if="currentPage == 'identityVerifiation'"/>

<!-- DASHBOARD -->
<Overview v-if="currentPage == 'overviewDashboard'"/>
<Transactions v-if="currentPage == 'transactions'"/>
</div>
</template>
<script>
import PersonalInfo from "../components/ProfilePages/PersonalInfo";
import Verification from "../components/ProfilePages/IdentityVerification";
import Overview from "../components/DashboardPages/Overview";
import Transactions from "../components/DashboardPages/Transactions";
import {mapGetters} from 'vuex';
export default {
  props: ['items'],
  components: {
    PersonalInfo,
    Verification,
    Overview,
    Transactions
  },
  computed: mapGetters({
      currentPage: 'getCurrentPage'
  })
};
</script>
<style scoped>
div {
    font-size: 12px;
}
.main-page-block {
    margin-top: 30px;
}
</style>
