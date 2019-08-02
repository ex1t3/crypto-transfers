<template>
  <div class="col-sm-6 col-lg-7">
    <div class="block-item">
      <h4 class="transfer-block-title">Just fill in the form below:</h4>
      <b-form class="form-horizontal">
        <div class="row">
          <div class="col-sm-12">
            <div class="form-group">
              <label class="col-sm-12 col-md-6 control-label">Transaction Type</label>
              <div class="col-sm-12 col-md-6">
                <select v-model="selectedTransactionType" class="form-control">
                  <option value="0">{{ transactionFormTypes[0] }}</option>
                  <option value="1">{{ transactionFormTypes[1] }}</option>
                </select>
              </div>
            </div>
          </div>
        </div>
      </b-form>
      <div class="transfer-form-block">
        <ExchangeForm v-if="selectedTransactionType === '0'" />
        <TransferForm v-if="selectedTransactionType === '1'" />
      </div>
    </div>
  </div>
</template>

<script>
import ExchangeForm from "../TransactionForms/ExchangeForm";
import TransferForm from "../TransactionForms/TransferForm";
export default {
  components: {
    ExchangeForm,
    TransferForm
  },
  data() {
    return {
      selectedTransactionType: '0',
      transactionFormTypes: ["Exchange Transaction", "Transfer Transaction"]
    };
  }
};
</script>

<style scoped>
 .form-control:focus {
  box-shadow: 0 0 0 0rem rgba(143, 136, 206, 0.17);
  border: transparent;
}
.transfer-form-block {
  background: none;
}
.coin-icon {
  background: #ffffffb0;
  padding: 25%;
  border-radius: 50%;
}
.coin-type-label {
  text-align: right;
}
.coin-type-block {
  display: flex;
}
.coin-type {
  width: 22%;
  cursor: pointer;
  margin: auto;
  text-align: center;
}
.coin-type:hover .coin-icon {
  background: #fff;
}
.coin-type:hover span {
  font-weight: 600;
}
.coin-type span {
  font-size: 12px;
  transition: font-weight 0.3s;
}
.coin-type img {
  vertical-align: middle;
  border-style: none;
  border-radius: 5px;
  width: 100%;
  transition: background 0.3s;
}
/* .coin-type:nth-of-type(1) {  // if currencies only 2
  margin-left: 0;
} */
.coin-type:nth-of-type(4) {
  margin-right: 0;
}
.transfer-block-title {
  text-align: right;
  padding-right: 15px;
  margin-bottom: 25px;
}
.transfer-form-block {
  background: none;
}
@media (max-width: 768px) {
  .transfer-block-title {
    text-align: center;
    padding-right: 0;
  }
  #termsAgreement {
    margin-top: 15px;
  }
  .transfer-form-block {
    padding: 10px;
    z-index: 2;
    border-radius: 15px;
    background: #4a3cc352;
  }
  .coin-type-label {
    display: none;
  }
  .coin-type {
    width: 20%;
    padding: 0;
  }
}
</style>

