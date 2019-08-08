<template>
  <b-modal size="md" :hide-footer="true" id="exchangeModal" title="Confirm Exchange">
    <div class="details-block">
      <p class="details-header">Transaction details:</p>
      <p class="details-item">
        Exchange type:
        <span class="amount">{{ exchange.givenCurrency }}</span>
        ->
        <span class="amount">{{ exchange.receivedCurrency }}</span>
      </p>
      <p class="details-item">
        Guaranteed rate time:
        <span class="amount">15 min</span>
      </p>
      <p class="details-item">
        You give:
        <span class="amount">{{ exchange.givenAmount + " " + exchange.givenCurrency }}</span>
      </p>
      <p class="details-item">
        You receive:
        <span
          class="amount"
        >{{ exchange.receivedAmount + " " + exchange.receivedCurrency }}</span>
      </p>
    </div>
    <div class="details-block">
      <p class="details-header">Payment details:</p>
      <p class="details-item">
        Subtotal Amount:
        <span
          class="amount"
        >{{ exchange.givenAmount + " " + exchange.payment.type }}</span>
      </p>
      <p class="details-item">
        Commission:
        <span
          class="amount"
        >{{ exchange.payment.commission + " " + exchange.payment.type }}</span>
      </p>
      <p class="details-item">
        Total Amount:
        <span
          class="amount"
        >{{ exchange.payment.totalAmount + " " + exchange.payment.type }}</span>
      </p>
    </div>
    <div class="details-block">
      <p class="details-header">Payment method:</p>
      <div
        class="details-item"
        v-if="exchange.givenCurrency === 'USD' || exchange.givenCurrency === 'EUR'"
      >
        <PayPal
          :amount="exchange.payment.totalAmount"
          :currency="exchange.givenCurrency"
          :desciption="'Buying of ' + exchange.receivedAmount + ' ' + exchange.receivedCurrency"
          env="sandbox"
          :button-style="style"
          :client="credentials"
          @payment-authorized="authorizePayPalTransaction"
          @payment-completed="completePayPalTransaction"
          @payment-cancelled="cancelPayPalTransaction"
        />
        <small>*The exchange transaction will be submitted once you complete a payment via PayPal</small>
      </div>
    </div>
    <!-- <b-btn class="btn-primary btn-block">CONFIRM EXCHANGE</b-btn> -->
  </b-modal>
</template>
<script>
import PayPal from "vue-paypal-checkout";
import { mapGetters } from "vuex";
import store from "../../store";
import axios from "axios";

export default {
  store,
  computed: mapGetters({
    exchange: "getExchangeData",
    isOpened: "getExchangeConfirmationState"
  }),
  data() {
    return {
      credentials: {
        sandbox:
          "AaC3uSJ6GDwBwl5azwFjRfk2Hy9xAnTWwEaUPah4uyIFVnLDz3U39OlhGrthMLyfxOs1IhRR-zhGVfRW"
      },
      style: {
        label: "paypal",
        shape: "rect",
        color: "blue",
        size: "responsive",
        fundingicons: true
      }
    };
  },
  beforeMount() {
    this.$root.$on("bv::modal::hide", (bvEvent, modalId) => {
      this.hideModal();
    });
  },
  beforeDestroy() {
    this.$root.$off("bv::modal::hide");
  },
  mounted() {
    this.$root.$emit("bv::show::modal", "exchangeModal");
  },
  methods: {
    hideModal() {
      this.$store.dispatch("setExchangeConfirm");
    },
    completePayPalTransaction(data) {
      this.$store.dispatch("addAlert", {
        duration: 7000,
        message:
          "Payment successfully confirmed. The exchange transaction has been submitted.",
        type: "0"
      });
    },
    authorizePayPalTransaction(data) {
      console.log(data);
    },
    cancelPayPalTransaction(data) {
      this.$store.dispatch("addAlert", {
        duration: 7000,
        message:
          "Payment was cancelled. The exchange transaction can't be submitted without successful payment.",
        type: "1"
      });
    }
  },
  components: {
    PayPal
  }
};
</script>
<style scoped>
.details-block {
  text-align: left;
  margin-bottom: 1.5rem;
}
.details-block:not(:last-of-type) {
  border-bottom: 1px solid #f5f5f5;
}
.details-header {
  font-size: 16px;
  display: inline-block;
  margin: 0 0 0.7rem 0.5rem;
}
.details-item {
  margin: 0 0 0.5rem 1rem;
}
.amount {
  font-weight: 600;
  border-bottom: 1px solid;
  margin: 0 10px;
}
@media (max-width: 700px) {
  .details-header {
    font-size: 14px;
  }
}
</style>
