<template>
  <div class="col-sm-6 col-lg-7">
    <div class="block-item">
      <h4 class="transfer-block-title">Just fill in the form below:</h4>
      <div class="transfer-form-block">
        <b-form class="form-horizontal">
          <div class="row">
            <div class="col-sm-12">
              <div class="form-group">
                <label
                  for="paymentType"
                  class="col-sm-12 col-md-6 control-label label-for-disabled"
                >Predefined payment</label>
                <div class="col-sm-12 col-md-6">
                  <select id="paymentType" disabled="disabled" class="form-control">
                    <option value>New payment</option>
                  </select>
                </div>
              </div>
              <div class="form-group">
                <label
                  for="receiverName"
                  class="col-sm-12 col-md-6 control-label"
                >Beneficiary's name</label>
                <div class="col-sm-12 col-md-6">
                  <input id="receiverName" class="form-control">
                </div>
              </div>
              <div class="form-group">
                <label
                  for="receiverIban"
                  class="col-sm-12 col-md-6 control-label"
                >Beneficiary's IBAN</label>
                <div class="col-sm-12 col-md-6">
                  <input id="receiverIban" class="form-control">
                </div>
              </div>
              <div class="form-group">
                <label for="amount" class="col-sm-12 col-md-6 control-label">Amount $</label>
                <div class="col-sm-12 col-md-6">
                  <input id="amount" type="number" step="any" min="1" class="form-control">
                </div>
              </div>
              <div class="form-group">
                <label
                  for="description"
                  class="col-sm-12 col-md-6 control-label"
                >Payment description</label>
                <div class="col-sm-12 col-md-6">
                  <input id="description" class="form-control">
                </div>
              </div>
              <div class="form-group">
                <label class="col-sm-6 coin-type-label">Coin type</label>
                <div class="col-sm-6 coin-type-block">
                  <div class="coin-type">
                    <div class="coin-icon">
                      <img src="../img/Bitcoin.svg">
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
                      <img src="../img/Ethereum.svg">
                    </div>
                    <span>Ethereum</span>
                  </div>
                </div>
              </div>
              <div class="form-group">
                <div class="offset-md-6 col-sm-6 col-md-6">
                  <input type="checkbox" id="termsAgreement">
                  <label for="termsAgreement">Terms of Service</label>
                </div>
              </div>
              <div class="offset-md-6 col-md-6 col-sm-6">
                <div class="form-group">
                  <button class="btn btn-block btn-lg btn-primary" type="submit">TRANSFER</button>
                </div>
              </div>
            </div>
          </div>
        </b-form>
      </div>
    </div>
  </div>
</template>
<style scoped>
.transfer-form-block .form-control:focus {
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
.coin-type:nth-of-type(1) {
  margin-left: 0;
}
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

