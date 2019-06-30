<template>
  <div class="islb-crypto-transfers--deals-block">
    <b-container>
      <b-row>
        <TransferExplanationBlock/>
        <TransferFormBlock/>
      </b-row>
    </b-container>
    <TransferNotificationsBlock/>
    <div class="islb-bottom-wave">
      <img src="../img/islb-bottom-wave.png">
    </div>
  </div>
</template>

<script>
import TransferExplanationBlock from "./TransferExplanationBlock";
import TransferFormBlock from "./TransferFormBlock";
import TransferNotificationsBlock from "./TransferNotificationsBlock";
export default {
  name: "CryptoTransfers",
  components: {
    TransferExplanationBlock,
    TransferFormBlock,
    TransferNotificationsBlock
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
.islb-crypto-transfers--deals-block {
  width: 100%;
  margin-top: -5px;
  position: relative;
  padding-top: 100px;
  min-height: 900px;
  background: linear-gradient(#3f30bf, #ddd);
  overflow: hidden;
}
.islb-crypto-transfers--deals-block h1,
.islb-crypto-transfers--deals-block h2,
.islb-crypto-transfers--deals-block h3,
.islb-crypto-transfers--deals-block h4 {
  color: #fff;
}
.islb-bottom-wave {
  position: absolute;
  left: 0;
  right: 0;
  bottom: 0;
}
.islb-bottom-wave img {
  position: absolute;
  left: 0;
  bottom: -5px;
  width: 100%;
  height: auto;
  z-index: 0;
}
input[type="checkbox"] {
  margin-right: 10px;
}
.label-for-disabled {
  color: rgb(214, 214, 214);
}
.form-control[disabled="disabled"],
.btn[disabled="disabled"] {
  background-color: #b1abe3;
  border: none;
  cursor: not-allowed;
}
.form-horizontal .form-group {
  display: flex;
  align-items: center;
  margin-bottom: 1.3rem;
}
.form-horizontal .form-control {
  height: calc(2.5rem + 2px);
}
.form-horizontal label {
  text-align: right;
  margin-bottom: 0;
}
@media (min-width: 768px) {
  .islb-crypto-transfers--deals-block .container {
    min-width: 760px;
  }
}
@media (max-width: 768px) {
  .islb-bottom-wave img {
    width: auto;
  }
  .col-sm-6 {
    max-width: 100%;
    flex: 0 0 100%;
  }
  .form-horizontal .form-group {
    display: block;
    margin-bottom: 1rem;
  }
  .form-horizontal label {
    text-align: left;
    margin-bottom: 10px;
  }
}
.block-item {
  margin-top: 40px;
  z-index: 1;
  position: relative;
  color: #fff;
  font-family: "Poppins", sans-serif;
}
@keyframes slide-down {
  0% {
    height: 0;
    opacity: 1;
  }
  60% {
    height: 100%;
    opacity: 0;
  }
  80% {
    opacity: 0;
    height: 100%;
  }
  100% {
    opacity: 0;
    height: 100%;
  }
}
@keyframes slide-left {
  0% {
    width: 0;
  }
  40% {
    width: calc(100% - 34px);
  }
  60% {
    width: calc(100% - 34px);
    opacity: 0;
  }
  70% {
    width: calc(100% - 34px);
    opacity: 0;
  }
  100% {
    width: calc(100% - 34px);
    opacity: 0;
  }
}
@keyframes fade-in {
  0% {
    opacity: 0;
  }
  40% {
    opacity: 1;
  }
  60% {
    opacity: 1;
  }
  65% {
    opacity: 0;
  }
  100% {
    opacity: 0;
  }
}
@keyframes incoming-notification {
  from {
    opacity: 0;
    transform: translate(-100px);
  }
  to {
    opacity: 1;
    transform: translate(0);
  }
}
@keyframes fade-out-route-to-bank {
  0% {
    opacity: 1;
    top: -14px;
  }
  50% {
    opacity: 1;
    top: -14px;
  }
  55% {
    opacity: 0;
    top: -20px;
  }
  100% {
    opacity: 0;
    top: -20px;
  }
}
@keyframes slide-in {
  0% {
    transform: translate(100%, -10px);
    opacity: 0;
  }
  25% {
    transform: translate(100%, 40px);
    opacity: 1;
  }
  50% {
    transform: translate(100%, 100px);
    opacity: 0;
  }
  to {
    opacity: 0;
    transform: translate(100%, 100px);
  }
}
</style>
