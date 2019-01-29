<template>
  <div class="col-sm-6 col-lg-5">
    <div class="block-item">
      <h4>ISLB lets you transfer crypto into $</h4>
      <div class="crypto-animations--start-location">You</div>
      <div class="crypto-animations--crypto-icons-block">
        <div class="crypto-animations--coins-movement">
          <div class="animation-holder-block">
            <div class="animation-coin bitcoin">
              <div class="crypto-coin">
                <img src="../img/Bitcoin.svg">
              </div>
            </div>
            <div class="animation-coin litecoin">
              <div class="crypto-coin">
                <img src="../img/Litecoin.svg">
              </div>
            </div>
            <div class="animation-coin ethereum">
              <div class="crypto-coin">
                <img src="../img/Ethereum.svg">
              </div>
            </div>
            <div class="animation-coin dash">
              <div class="crypto-coin">
                <img src="../img/Dash.svg">
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="crypto-animations--route">
        <div class="crypto-animations--route-direction"></div>
      </div>
      <div class="crypto-animations--middle-point">I S L B</div>
      <div class="crypto-animations--route-to-bank-block">
        <div class="crypto-animations--receiver payment-card">Card</div>
        <div class="crypto-animations--route-to-bank payment-card">
          <div class="crypto-animations--route-to-bank-direction payment-card"></div>
          <div class="crypto-animations--money-to-bank payment-card">
            <img src="../img/dollar.svg">
          </div>
        </div>
      </div>
      <div class="crypto-animations--route-to-bank-block">
        <div class="crypto-animations--receiver bills">Bills</div>
        <div class="crypto-animations--route-to-bank bills">
          <div class="crypto-animations--route-to-bank-direction bills"></div>
          <div class="crypto-animations--money-to-bank bills">
            <img src="../img/dollar.svg">
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<style scoped>
.crypto-animations--receiver {
  display: inline-block;
  width: auto;
  position: absolute;
  top: -52px;
  opacity: 0;
  animation: fade-in;
  animation-delay: 3s;
  animation-duration: 6s;
  animation-iteration-count: infinite;
}
.crypto-animations--receiver.payment-card {
  left: 0;
}
.crypto-animations--receiver.bills {
  right: 0;
}
.crypto-animations--middle-point {
  margin-top: 15px;
  font-size: 25px;
}
.crypto-animations--route-to-bank-block {
  position: relative;
  width: 75%;
  margin: 0 auto;
}
.crypto-animations--route-to-bank {
  position: absolute;
  width: 35%;
  top: -14px;
  animation: fade-out-route-to-bank;
  animation-delay: 3s;
  animation-duration: 6s;
  animation-iteration-count: infinite;
}
.crypto-animations--route-to-bank.payment-card {
  left: 0;
}
.crypto-animations--route-to-bank.bills {
  right: 0;
}
.crypto-animations--route-to-bank-direction {
  width: 0px;
  height: 1px;
  animation: slide-left 6s none 3s infinite;
}
.crypto-animations--route-to-bank-direction.payment-card {
  float: right;
  background: linear-gradient(-90deg, transparent, #fff);
}
.crypto-animations--route-to-bank-direction.bills {
  float: left;
  background: linear-gradient(90deg, transparent, #fff);
}
.crypto-animations--money-to-bank {
  width: 32px;
  height: 32px;
  animation: fade-in 6s none 3s infinite;
  opacity: 0;
  margin-top: -15px;
  background: #fff;
  border-radius: 50%;
  padding-top: 3px;
}
.crypto-animations--money-to-bank.payment-card {
  float: right;
  margin-right: 2px;
}
.crypto-animations--money-to-bank.bills {
  float: left;
  margin-left: 2px;
}
.crypto-animations--money-to-bank img {
  width: 20px;
  height: 20px;
  vertical-align: middle;
}
.crypto-animations--start-point,
.crypto-animations--end-point {
  position: absolute;
  width: 7px;
  height: 7px;
  border-radius: 50%;
  left: -3px;
}
.crypto-animations--start-location {
  position: relative;
  margin-top: 40px;
}
.crypto-animations--crypto-icons-block {
  position: relative;
}
.crypto-animations--coins-movement {
  position: absolute;
  top: 0px;
  left: 0;
  width: 100%;
}
.crypto-animations--route-direction {
  position: relative;
  margin: 0 auto;
  height: 0;
  animation: slide-down;
  animation-delay: 3s;
  animation-duration: 6s;
  animation-iteration-count: infinite;
  width: 2px;
  border-bottom-left-radius: 5px;
  border-bottom-right-radius: 5px;
  background: linear-gradient(transparent, #fff);
}
.crypto-animations--route {
  display: block;
  position: relative;
  height: 100px;
  margin-top: 25px;
}
.animation-holder-block {
  width: 50%;
  position: relative;
  float: left;
}
.crypto-animations--transfer {
  height: 130px;
  position: relative;
}
.animation-coin {
  width: 100%;
  position: absolute;
  display: block;
  animation: slide-in;
  animation-duration: 6s;
  animation-iteration-count: infinite;
  opacity: 0;
}
.animation-coin.bitcoin {
  animation-delay: 0.5s;
}
.animation-coin.dash {
  animation-delay: 1s;
}
.animation-coin.litecoin {
  animation-delay: 1.5s;
}
.animation-coin.ethereum {
  animation-delay: 2s;
}
.crypto-animations--start {
  display: flex;
}
.crypto-coin {
  background: #fff;
  border-radius: 50%;
  width: 32px;
  height: 32px;
  padding-top: 3px;
  margin-left: -16px;
}
.crypto-coin img {
  width: 20px;
  height: 20px;
  vertical-align: middle;
}
</style>

