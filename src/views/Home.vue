<template>
  <div class="islb-crypto-transfers--home">
    <CryptoTransfers/>
    <CurrencyRates/>
    <TransferStatus/>
    <TransactionSpeeds/>
    <Video/>
    <FrequentlyAskedQuestions/>
  </div>
</template>

<script>
// @ is an alias to /src
import CryptoTransfers from "@/components/Home/MainCryptoTransfersBlock";
import CurrencyRates from "@/components/Home/CurrencyRatesBlock";
import TransferStatus from "@/components/Home/TransferStatusBlock";
import TransactionSpeeds from "@/components/Home/TransactionSpeedsBlock";
import Video from "@/components/Home/VideoBlock";
import FrequentlyAskedQuestions from "@/components/Home/FrequentlyAskedQuestionsBlock";

export default {
  name: "Home",
  components: {
    CryptoTransfers,
    CurrencyRates,
    TransferStatus,
    TransactionSpeeds,
    Video,
    FrequentlyAskedQuestions
  }
};
</script>
<style>
.islb-crypto-transfers--home {
  position: relative;
}
</style>
