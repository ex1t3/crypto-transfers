<template>
  <div class="transactions-block main-page-block">
            <Grid :headers="transactionHeaders" :data="transactionsData" :styles="styles"/>
    <!-- <div role="tablist">
      <b-card no-body class="mb-1">
        <b-card-header class="toggle-header" header-tag="header" role="tab">
          <div v-b-toggle.exchanges>Exchanges</div>
        </b-card-header>
        <b-collapse id="exchanges" visible accordion="my-accordion" role="tabpanel">
          <b-card-body>
            <Grid :headers="transactionHeaders" :data="transactionsData" />
          </b-card-body>
        </b-collapse>
      </b-card>
      <b-card no-body class="mb-1">
        <b-card-header class="toggle-header" header-tag="header" role="tab">
          <div v-b-toggle.transfers>Transfers</div>
        </b-card-header>
        <b-collapse id="transfers" accordion="my-accordion" role="tabpanel">
          <b-card-body>
            <Grid :headers="transactionHeaders" :data="transactionsData" />
          </b-card-body>
        </b-collapse>
      </b-card>
    </div> -->
  </div>
</template>
<script>
import Grid from "../GridTemplate/GridMain";
import axios from "axios";
export default {
  components: {
    Grid
  },
  data() {
    return {
      transactionHeaders: [
        { Label: "ID", Name: "uniqueId" },
        { Label: "Date", Name: "created" },
        { Label: "Stock", Name: "stock" },
        { Label: "You gave", Name: "givenAmount" },
        { Label: "You receive", Name: "receivedAmount" },
        { Label: "You paid", Name: "totalAmount" },
        { Label: "Rate", Name: "rate" },
        { Label: "Address To", Name: "addressTo" },
        { Label: "Status", Name: "status" }
      ],
      transactionsData: [],
      styles: {
        key: "status",
        values: {
          COMPLETED: "background: linear-gradient(90deg, #f8f8f8 85%, #a9dfb6);",
          "AUTHORIZED BY PAYPAL": "background: linear-gradient(90deg, #f8f8f8 85%, #fce5a1);",
          FAILED: "background: linear-gradient(90deg, #f8f8f8 85%, #f0b7bd);",
          CONFIRMED: "background: linear-gradient(90deg, #f8f8f8 85%, #c0dcfa);"
        }
      }
    };
  },
  beforeMount() {
    let that = this;
    axios({
      method: "POST",
      url: "https://localhost:44357/api/transaction/get_exchanges",
      headers: {
        Authorization: "Bearer " + localStorage.getItem("access_token")
      }
    })
      .then(response => {
        console.log(response);
        that.transactionsData = response.data;
      })
      .catch(response => {
        console.log(response);
      });
  }
};
</script>
<style scoped>
.transactions-block {
  overflow-x: auto;
}
</style>
