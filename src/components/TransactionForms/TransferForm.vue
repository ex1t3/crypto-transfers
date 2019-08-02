<template>
  <b-form v-on:input="updateForm('setTransferData', transfer)" class="form-horizontal">
    <div class="row">
      <div class="col-sm-12">
        <div class="form-group">
          <label
            class="col-sm-12 col-md-6 control-label"
            :class="{'label-for-disabled': !socket.sessionToken}"
          >Currency</label>
          <div class="col-sm-12 col-md-6">
            <select
              name="currency"
              v-model="transfer.currency"
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
          >Amount</label>
          <div class="col-sm-12 col-md-6">
            <input :disabled="!socket.sessionToken" id="receiverName" class="form-control" />
          </div>
        </div>
        <div class="form-group">
          <label
            class="col-sm-12 col-md-6 control-label"
            :class="{'label-for-disabled': !socket.sessionToken}"
          >{{ transfer.currency }} Address</label>
          <div class="col-sm-12 col-md-6">
            <input :disabled="!socket.sessionToken" id="receiverName" class="form-control" />
          </div>
        </div>
        <div class="form-group">
          <label
            class="col-sm-12 col-md-6 control-label"
            :class="{'label-for-disabled': !socket.sessionToken}"
          >Blockchain Fee</label>
          <div class="col-sm-12 col-md-6">
            <select
              name="blockchainFee"
              v-model="transfer.blockchainFee"
              :disabled="!socket.sessionToken"
              class="form-control"
            >
              <option
                v-for="(item, index) in fees"
                :value="item"
                :key="index"
              >{{ item }}</option>
            </select>
          </div>
        </div>
        <div class="form-group">
          <div class="offset-md-6 col-sm-6 col-md-6">
            <input type="checkbox" id="termsAgreement" />
            <label for="termsAgreement">Terms of Service</label>
          </div>
        </div>
        <div class="offset-md-6 col-md-6 col-sm-6">
          <div class="form-group">
            <b-btn class="btn-block btn-lg btn-primary" :disabled="!socket.sessionToken" type="submit">
              TRANSFER
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
      isLoading: false,
      fees: ['Regular', 'Economy', 'Priority'],
      currencies: [
        {
          Label: "Ethereum (ETH)",
          Value: "ETH"
        },
        {
          Label: "Bitcoin (BTC)",
          Value: "BTC"
        }
      ]
    };
  }
};
</script>
