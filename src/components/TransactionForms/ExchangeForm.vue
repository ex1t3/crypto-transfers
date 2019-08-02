<template>
  <b-form v-on:input="updateForm('setExchangeData', exchange)" class="form-horizontal">
    <div class="row">
      <div class="col-sm-12">
        <div class="form-group">
          <label
            class="col-sm-12 col-md-6 control-label"
            :class="{'label-for-disabled': !socket.sessionToken}"
          >Given Currency</label>
          <div class="col-sm-12 col-md-6">
            <select
              name="givenCurrency"
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
            <input type="number" min="1" v-model="exchange.givenAmount" :disabled="!socket.sessionToken" class="form-control" />
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
          >Received Amount</label>
          <div class="col-sm-12 col-md-6">
            <input
              :disabled="!socket.sessionToken"
              min="1"
              v-model="exchange.receivedAmount"
              type="number"
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
            <input type="checkbox" id="termsAgreement" />
            <label>Terms of Service</label>
          </div>
        </div>
        <div class="offset-md-6 col-md-6 col-sm-6">
          <div class="form-group">
            <b-btn class="btn-block btn-lg btn-primary" :disabled="!socket.sessionToken" type="submit">
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
};
</script>