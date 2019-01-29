<template>
  <b-container class="islb-crypto-transfers--currency-rates">
    <b-row>
      <div class="col-sm-12 rates-block">
        <div class="rates-title">Current transfer rates:</div>
        <div class="rates-value">
          <img src="../img/Bitcoin.svg"> 3,400 $
        </div>
        <div class="rates-value">
          <img src="../img/Litecoin.svg"> 400 $
        </div>
        <div class="rates-value">
          <img src="../img/Dash.svg"> 1,400 $
        </div>
        <div class="rates-value">
          <img src="../img/Ethereum.svg"> 1,930 $
        </div>
      </div>
    </b-row>
  </b-container>
</template>
<style scoped>
.islb-crypto-transfers--currency-rates {
  margin: 30px auto;
  padding-top: 20px;
  padding-bottom: 20px;
}
.rates-block {
  padding-left: 50px;
  font-size: 14px;
}
.rates-value img {
  width: 20px;
  margin-right: 2px;
}
.rates-value {
  font-weight: 300;
}
.rates-title {
  font-weight: 600;
}
.rates-value,
.rates-title {
  margin-right: 50px;
  display: inline-block;
  margin-top: 15px;
}
</style>
