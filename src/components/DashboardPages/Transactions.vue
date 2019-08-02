<template>
  <div class="transactions-block main-page-block">
    <Grid :headers="transactionHeaders" :data="transactionsData" />
  </div>
</template>
<script>
import Grid from "../GridTemplate/GridMain";
export default {
  components: {
    Grid
  },
  data() {
    return {
      transactionHeaders: [
        "Created",
        "Amount",
        "Rate",
        "Stock",
        "TxHash",
        "Status"
      ],
      transactionsData: [
        {
          Created: "08-07-2019",
          Amount: 34,
          Rate: 0.055,
          Stock: "ETH-USD",
          TxHash: "d0sHvir645Fdszc8Sxzh4dlstgzs",
          Status: "Completed"
        },
        {
          Created: "09-07-2019",
          Amount: 313,
          Rate: 0.053,
          Stock: "ETH-USD",
          TxHash: "z4sZvDrb34F3434dSljlSls34zBs",
          Status: "Completed"
        },
        {
          Created: "10-07-2019",
          Amount: 3334,
          Rate: 0.051,
          Stock: "ETH-USD",
          TxHash: "nSJdjfhs7233dhZHdddccdkgs3sb",
          Status: "Completed"
        },
        {
          Created: "11-07-2019",
          Amount: 234,
          Rate: 0.055,
          Stock: "ETH-USD",
          TxHash: "d0sHvir645Fdszc8Sxzh4dlstgzs",
          Status: "Completed"
        }
      ]
    };
  }
};
</script>
<style scoped>
.transactions-block {
  overflow-x: auto;
}
</style>
