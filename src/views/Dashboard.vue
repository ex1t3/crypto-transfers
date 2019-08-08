<template>
  <b-container>
    <b-row>
      <Sidebar :items="{sidebarItems}" />
    </b-row>
    <b-row>
      <Content :items="{sidebarItems}" />
    </b-row>
  </b-container>
</template>
<script>
import LoggedIn from "../components/LoggedInTemplate";
import Sidebar from "../components/SidebarTemplate";
import Content from "../components/ContentTemplate";
export default {
  extends: LoggedIn,
  components: {
    Sidebar,
    Content
  },
  data() {
    return {
      sidebarItems: [
        {
          Name: "overviewDashboard",
          Label: "Overview"
        },
        {
          Name: "balances",
          Label: "Balances"
        },
        {
          Name: "transactions",
          Label: "Transactions"
        },
        {
          Name: "newTransfer",
          Label: "New Transfer"
        }
      ]
    };
  }
};
</script>


