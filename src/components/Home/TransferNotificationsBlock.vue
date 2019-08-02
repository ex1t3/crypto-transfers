<template>
  <b-container class="transfer-transactions-block">
    <b-row>
      <div class="col-sm-6 col-lg-5">
        <div class="block-item">
          <div class="transactions-block">
            <transition-group v-on:leave="onLeave" name="transfer-transactions" tag="div">
              <div
                v-bind:key="transferTransaction.Id"
                v-for="transferTransaction in transactions"
                class="transaction-item"
              >
                <div class="transaction-icon">
                  <img v-bind:src="transferTransaction.CryptoCurrency.Icon" />
                </div>
                <div class="transaction-message">
                  {{ transferTransaction.Message + " " }}
                  <strong>{{ transferTransaction.Value + " " }} {{ transferTransaction.Currency + " " }}</strong>
                  using {{ transferTransaction.CryptoCurrency.Name }}
                </div>
                <div class="transaction-time">{{ transferTransaction.Time }}</div>
              </div>
            </transition-group>
          </div>
        </div>
      </div>
    </b-row>
  </b-container>
</template>
<script>
import Main from "./MainCryptoTransfersBlock";
export default {
  extends: Main,
  data() {
    return {
      transactions: [],
      currencies: [],
      randoms: [],
      counter: 0
    };
  },
  mounted() {
    this.currencies = [
      {
        Name: "Bitcoin",
        Icon: require("@/components/img/Bitcoin.svg")
      },
      // {
      //   Name: "Dash",
      //   Icon: require("@/components/img/Bitcoin.svg")
      // },
      // {
      //   Name: "Litecoin",
      //   Icon: require("@/components/img/Ethereum.svg")
      // },
      {
        Name: "Ethereum",
        Icon: require("@/components/img/Ethereum.svg")
      }
    ];
    for (let i = 0; i < 4; i++) {
      this.generateRandoms();
      this.fillTransactions();
    }
    this.transactionHandler();
  },
  methods: {
    onLeave(el) {
      el.style.display = "none";
    },
    generateRandoms() {
      let randomObj = {
        CurrentCurrencyId: Math.floor(Math.random() * 4),
        CurrentValue: Math.floor(Math.random() * 10000) + 1,
        CurrentHour: Math.floor(Math.random() * 10) + 1 + "h"
      };
      this.randoms.push(randomObj);
    },
    fillTransactions() {
      let transaction = {
        Id: this.counter++,
        Value: this.randoms[this.randoms.length - 1].CurrentValue,
        Message: "Someone has transferred",
        Time: this.randoms[this.randoms.length - 1].CurrentHour,
        Currency: "$",
        CryptoCurrency: this.currencies[
          this.randoms[this.randoms.length - 1].CurrentCurrencyId % 2
        ]
      };
      this.transactions.unshift(transaction);
    },
    transactionHandler() {
      let that = this;
      setInterval(() => {
        setTimeout(() => {
          that.generateRandoms();
          that.transactions.length = that.transactions.length - 1;
          that.fillTransactions();
        }, 2000);
      }, 10000);
    }
  }
};
</script>
<style scoped>
.transfer-transactions-block {
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
}
.transaction-block {
  width: 100%;
  display: block;
  height: 325px;
  position: relative;
}
.transaction-time {
  color: #9c9c9c;
  font-size: 13px;
  padding: 5px;
  font-weight: 300;
}
.transaction-message {
  display: block;
  margin-left: 20px;
  text-align: left;
  font-weight: 300;
}
.transaction-message strong {
  font-weight: 600;
}
.transaction-icon {
  width: 28px;
  margin-left: 5px;
}
.transaction-item {
  display: flex;
  align-items: center;
  color: #222123e6;
  background: rgba(255, 255, 255, 0.85);
  height: 75px;
  width: 90%;
  transition: 0.5s;
  font-size: 14px;
  margin: 0 auto 15px auto;
  position: relative;
  padding: 15px;
  border-radius: 5px;
  box-shadow: -1px 6px 20px #6f6f6f80;
}
.transaction-item:nth-of-type(1) {
  animation: incoming-transaction .5s;
}
@keyframes incoming-transaction {
  from {
    transform: translateX(-50px);
    opacity: 0;
  }
  to {
    transform: translateX(0);
    opacity: 1;
  }
}
@media (max-width: 992px) {
  .transaction-item {
    width: 100%;
  }
}
@media (max-width: 768px) {
  .transfer-transactions-block {
    position: relative;
    bottom: 0px;
  }
  .transaction-message {
    font-size: 12px;
  }
  .transaction-item:nth-of-type(3),
  .transaction-item:nth-of-type(4) {
    display: none;
  }
}
.transactions-block::after {
  content: "";
  background: linear-gradient(
    180deg,
    hsla(0, 0%, 98%, 0) 0,
    hsla(0, 0%, 98%, 0.84) 29%,
    #fafafa 88%,
    #fafafa 23%
  );
  width: 100%;
  height: 75px;
  position: absolute;
  left: 0;
  bottom: -30px;
  margin: 0 auto;
}
</style>

