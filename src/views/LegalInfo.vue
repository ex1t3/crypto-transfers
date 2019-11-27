<template>
  <div class="container">
    <div class="col-sm-12">
      <div class="legal-page">
        <Header />
        <Terms v-if="$route.name === 'terms' || $route.name === 'legal'" />
        <Privacy v-if="$route.name === 'privacy'" />
        <Cookies v-if="$route.name === 'cookies'" />
      </div>
    </div>
  </div>
</template>
<script>
import Header from "../components/LegalInfoPages/LegalTabsHeader";
import Terms from "../components/LegalInfoPages/TermsOfUse";
import Privacy from "../components/LegalInfoPages/Privacy";
import Cookies from "../components/LegalInfoPages/Cookies";

export default {
  components: {
    Header,
    Terms,
    Privacy,
    Cookies
  },
  data () {
    return {
      titleObj: {
        name: String,
        lastUpdate: String,
        downloadLink: String
      }
    }
  }
};
</script>
<style>
.legal-page {
  width: 100%;
  min-height: 70vh;
  padding-top: 100px;
  text-align: left;
  font-size: 16px;
}

.legal-page h1,
.legal-page h2,
.legal-page h3,
.legal-page h4,
.legal-page h5,
.legal-page h6 {
  font-weight: 500;
}

.legal-page p {
  text-align: justify;
}

.list-type {
  padding-left: 5px;
}

.list-type::before {
  content: '•';
  margin-right: 5px;
}
</style>