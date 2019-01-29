<template>
  <div class="islb-crypto-transfers--home">
    <CryptoTransfers/>
    <CurrencyRates/>
    <TransferStatus/>
    <FrequentlyAskedQuestions/>
    <Footer/>
  </div>
</template>

<script>
// @ is an alias to /src
import CryptoTransfers from "@/components/CryptoTransfersBlock/Main";
import CurrencyRates from "@/components/CurrencyRatesBlock/Main";
import TransferStatus from "@/components/TransferStatusBlock/Main";
import FrequentlyAskedQuestions from "@/components/FrequentlyAskedQuestionsBlock/Main";
import Footer from "@/components/FooterBlock/Main";

export default {
  name: "Home",
  components: {
    CryptoTransfers,
    CurrencyRates,
    TransferStatus,
    FrequentlyAskedQuestions,
    Footer
  }
};
</script>
<style>
.islb-crypto-transfers--home {
  position: relative;
}
</style>
