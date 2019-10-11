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
      <p class="details-item">
        Address to:
        <span
          class="amount"
        >{{ exchange.addressTo }}</span>
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

      <!-- PAYPAL METHOD -->
      <div
        class="details-item payments"
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

      <!-- BLOCKCHAIN METHOD -->
      <div
        class="details-item payments"
        v-if="exchange.givenCurrency !== 'USD' && exchange.givenCurrency !== 'EUR'"
      >
        <p>
          <input
            type="text"
            class="form-control"
            readonly
            :value="socket.wallets[exchange.givenCurrency]"
          />
        </p>
        <p>OR</p>
        <QRCode :value="socket.wallets[exchange.givenCurrency]" size="100" />

        <p>
          <small>*To submit exchange transaction, please, fill this address with a given amount and press CONFIRM button</small>
        </p>
        <b-form-group>
          <b-btn type="button" class="btn-primary btn-block">CONFIRM</b-btn>
        </b-form-group>
      </div>
    </div>
  </b-modal>
</template>
<script>
import PayPal from "vue-paypal-checkout";
import QRCode from "qrcode.vue";
import { mapGetters } from "vuex";
import store from "../../store";
import axios from "axios";

export default {
  store,
  computed: mapGetters({
    exchange: "getExchangeData",
    socket: "getSocketData",
    isOpened: "getExchangeConfirmationState"
  }),
  data() {
    return {
      transaction: Object,
      credentials: {
        sandbox:
          "AVQW1lwd5DMIAB-FU0ApGTbYdvIj_ifU4a_2g72I7yLYIiMD_xhWGQNpB7kRcVFRoSHZe5RFAULKu7ct"
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
    completePayPalTransaction() {
      let that = this;
      axios({
        method: "POST",
        url: "https://localhost:44357/api/transaction/paypal_confirm_exchange",
        data: JSON.stringify(this.transaction.ExternalServiceId),
        headers: {
          Authorization: "Bearer " + localStorage.getItem("access_token"),
          "Content-Type": "application/json; charset=utf-8"
        }
      })
        .then(response => {
          that.$store.dispatch("addAlert", response.data)
          that.$store.dispatch("socketSET", that.transaction)
        })
        .catch(response => {
          console.log(response);
        });
    },
    authorizePayPalTransaction(data) {
      this.transaction = {
        ExternalServiceId: data.paymentID,
        Stock:
          this.exchange.givenCurrency + "-" + this.exchange.receivedCurrency,
        GivenAmount: this.exchange.givenAmount,
        ReceivedAmount: this.exchange.receivedAmount,
        TotalAmount: this.exchange.payment.totalAmount,
        Commission: this.exchange.payment.commission,
        Rate:
          this.socket.rates[this.exchange.receivedCurrency] /
          this.socket.rates[this.exchange.givenCurrency],
        Description: this.exchange.payment.description,
        AddressTo: this.exchange.addressTo,
        BlockchainFee: "Regular"
      };
      console.log(data);
      axios({
        method: "POST",
        url: "https://localhost:44357/api/transaction/paypal_create_exchange",
        data: this.transaction,
        headers: {
          Authorization: "Bearer " + localStorage.getItem("access_token")
        }
      })
        .then(response => {
          console.log(response);
        })
        .catch(response => {
          console.log(response);
        });
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
    PayPal,
    QRCode
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
.payments {
  text-align: center;
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
