<template>
    <b-form
      v-on:submit="createExchange($event)"
      v-on:input="updateForm('setExchangeData', exchange)"
      v-on:change="updateForm('setExchangeData', exchange)"
      class="form-horizontal"
    >
    <ExchangeConfirm v-if="isConfirmationVisible" :payment="payment"/>
      <div class="row">
        <div class="col-sm-12">
          <div class="form-group" v-if="typeof socket.rates === 'object'">
            <div class="col-sm-12 col-md-12">
              <p class="rates">
                1
                <span class="selected-currency">{{ exchange.receivedCurrency }}</span>
                = {{ (socket.rates[exchange.receivedCurrency] / socket.rates[exchange.givenCurrency]) }}
                <span class="selected-currency">{{ exchange.givenCurrency }}</span>
              </p>
            </div>
          </div>
          <div class="form-group">
            <label
              class="col-sm-12 col-md-6 control-label"
              :class="{'label-for-disabled': !socket.sessionToken}"
            >Given Currency</label>
            <div class="col-sm-12 col-md-6">
              <select
                name="givenCurrency"
                required
                v-model="exchange.givenCurrency"
                :disabled="!socket.sessionToken"
                class="form-control"
              >
                <option
                  v-for="(item, index) in currencies"
                  :value="item.Value"
                  :key="index"
                >{{ item.Label }}</option>
              </select>
            </div>
          </div>
          <div class="form-group">
            <label
              class="col-sm-12 col-md-6 control-label"
              :class="{'label-for-disabled': !socket.sessionToken}"
            >Given Amount</label>
            <div class="col-sm-12 col-md-6">
              <input
                v-model="exchange.givenAmount"
                required
                :disabled="!socket.sessionToken"
                :placeholder="'Amount you pay to receive ' + exchange.receivedCurrency"
                class="form-control"
              />
            </div>
          </div>
          <div class="form-group">
            <label
              class="col-sm-12 col-md-6 control-label"
              :class="{'label-for-disabled': !socket.sessionToken}"
            >Received Currency</label>
            <div class="col-sm-12 col-md-6">
              <select
                name="receivedCurrency"
                v-model="exchange.receivedCurrency"
                :disabled="!socket.sessionToken"
                class="form-control"
              >
                <option
                  v-for="(item, index) in (Array.from(currencies)).splice(0,2)"
                  :value="item.Value"
                  :key="index"
                >{{ item.Label }}</option>
              </select>
            </div>
          </div>
          <div class="form-group">
            <label
              class="col-sm-12 col-md-6 control-label"
              :class="{'label-for-disabled': !socket.sessionToken}"
            >Received Amount</label>
            <div class="col-sm-12 col-md-6">
              <input
                :disabled="!socket.sessionToken"
                v-model="exchange.receivedAmount"
                readonly
                :placeholder="'Amount you can buy for ' + exchange.givenCurrency"
                name="receivedAmount"
                class="form-control"
              />
            </div>
          </div>
          <!-- <div class="form-group">
                <label
                  for="description"
                  class="col-sm-12 col-md-6 control-label"
                >Payment description</label>
                <div class="col-sm-12 col-md-6">
                  <input id="description" class="form-control" />
                </div>
              </div>
              <div class="form-group">
                <label class="col-sm-6 coin-type-label">Coin type</label>
                <div class="col-sm-6 coin-type-block">
                  <div class="coin-type">
                    <div class="coin-icon">
                      <img src="../img/Bitcoin.svg" />
                    </div>
                    <span>Bitcoin</span>
                  </div>
                  <div class="coin-type">
                    <div class="coin-icon">
                      <img src="../img/Litecoin.svg">
                    </div>
                    <span>Litecoin</span>
                  </div>
                  <div class="coin-type">
                    <div class="coin-icon">
                      <img src="../img/Dash.svg">
                    </div>
                    <span>Dash</span>
                  </div>
                  <div class="coin-type">
                    <div class="coin-icon">
                      <img src="../img/Ethereum.svg" />
                    </div>
                    <span>Ethereum</span>
                  </div>
                </div>
          </div>-->
          <div class="form-group">
            <div class="offset-md-6 col-sm-6 col-md-6">
              <input required type="checkbox" id="termsAgreement" />
              <label for="termsAgreement">Terms of Service</label>
            </div>
          </div>
          <div class="offset-md-6 col-md-6 col-sm-6">
            <div class="form-group">
              <b-btn
                class="btn-block btn-lg btn-primary"
                :disabled="!socket.sessionToken"
                type="submit"
              >
                EXCHANGE
                <span class="loader" :class="{loading: isLoading}"></span>
              </b-btn>
            </div>
          </div>
        </div>
      </div>
    </b-form>
</template>
        
<script>
import TransactionFormPattern from "./TransactionFormPattern";
export default {
  extends: TransactionFormPattern,
  data() {
    return {
      commissions: {
        currency: 0.03,
        default: 0.03
      },
      payment: {
        description: String,
        type: String,
        totalAmount: String,
        commissionAmount: Number
      },
      currencies: [
        {
          Label: "Ethereum (ETH)",
          Value: "ETH"
        },
        {
          Label: "Bitcoin (BTC)",
          Value: "BTC"
        },
        {
          Label: "Dollar (USD)",
          Value: "USD"
        },
        {
          Label: "Euro (EUR)",
          Value: "EUR"
        }
      ]
    };
  },
  methods: {
    createExchange(e) {
      e.preventDefault();
      this.payment.totalAmount = this.countTotalAmount();
      this.exchange.payment = this.payment;
      this.$store.dispatch('setExchangeConfirm');
    },
    countTotalAmount() {
      let amount = parseFloat(this.exchange.givenAmount);
      this.payment.commission = this.countCommission(
        amount + this.countCommission(amount)
      );
      this.payment.type = this.exchange.givenCurrency;
      return (this.payment.commission + amount).toString();
    },
    countCommission(value) {
      return Math.round((
        value * this.commissions.default +
        this.commissions.currency *
          this.socket.rates[this.exchange.givenCurrency]
      + Number.EPSILON)* 100) / 100;
    }
  }
};
</script>