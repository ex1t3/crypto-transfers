<template>
  <div class="islb-crypto-transfers--home">
    <CryptoTransfers/>
    <CurrencyRates/>
    <TransferStatus/>
    <TransactionSpeeds/>
    <Video/>
    <FrequentlyAskedQuestions/>
    <Footer/>
  </div>
</template>

<script>
// @ is an alias to /src
import CryptoTransfers from "@/components/CryptoTransfersBlock/MainCryptoTransfersBlock";
import CurrencyRates from "@/components/ContentBlock/CurrencyRatesBlock";
import TransferStatus from "@/components/ContentBlock/TransferStatusBlock";
import TransactionSpeeds from "@/components/ContentBlock/TransactionSpeedsBlock";
import Video from "@/components/ContentBlock/VideoBlock";
import FrequentlyAskedQuestions from "@/components/ContentBlock/FrequentlyAskedQuestionsBlock";
import Footer from "@/components/FooterHeaderBlock/FooterBlock";

export default {
  name: "Home",
  components: {
    CryptoTransfers,
    CurrencyRates,
    TransferStatus,
    TransactionSpeeds,
    Video,
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
