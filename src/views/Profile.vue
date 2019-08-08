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
          Name: "personalInfo",
          Label: "Personal Info"
        },
        {
          Name: "identityVerifiation",
          Label: "Identity Verification"
        },
        {
          Name: "account",
          Label: "Account"
        },
        {
          Name: "withdrawAddresses",
          Label: "My Withdraw Adresses"
        }
      ]
    };
  }
};
</script>


