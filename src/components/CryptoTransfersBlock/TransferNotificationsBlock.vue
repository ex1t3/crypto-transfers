<template>
  <b-container class="transfer-notifications-block">
    <b-row>
      <div class="col-sm-6 col-lg-5">
        <div class="block-item">
          <div class="notifications-block">
            <transition-group v-on:leave="onLeave" name="transfer-notifications" tag="div">
              <div
                v-bind:key="transferNotification.Id"
                v-for="transferNotification in notifications"
                class="notification-item"
              >
                <div class="notification-icon">
                  <img v-bind:src="transferNotification.CryptoCurrency.Icon">
                </div>
                <div class="notification-message">
                  {{ transferNotification.Message + " " }}
                  <strong>{{ transferNotification.Value + " " }} {{ transferNotification.Currency + " " }}</strong>
                  using {{ transferNotification.CryptoCurrency.Name }}
                </div>
                <div class="notification-time">{{ transferNotification.Time }}</div>
              </div>
            </transition-group>
          </div>
        </div>
      </div>
    </b-row>
  </b-container>
</template>
<script>
import Main from "@/components/CryptoTransfersBlock/MainCryptoTransfersBlock";
export default {
  extends: Main,
  data() {
    return {
      notifications: [],
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
      {
        Name: "Dash",
        Icon: require("@/components/img/Dash.svg")
      },
      {
        Name: "Litecoin",
        Icon: require("@/components/img/Litecoin.svg")
      },
      {
        Name: "Ethereum",
        Icon: require("@/components/img/Ethereum.svg")
      }
    ];
    for (let i = 0; i < 4; i++) {
      this.generateRandoms();
      this.fillNotifications();
    }
    this.notificationHandler();
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
    fillNotifications() {
      let notification = {
        Id: this.counter++,
        Value: this.randoms[this.randoms.length - 1].CurrentValue,
        Message: "Someone has transferred",
        Time: this.randoms[this.randoms.length - 1].CurrentHour,
        Currency: "$",
        CryptoCurrency: this.currencies[
          this.randoms[this.randoms.length - 1].CurrentCurrencyId
        ]
      };
      this.notifications.unshift(notification);
    },
    notificationHandler() {
      let that = this;
      setInterval(() => {
        setTimeout(() => {
          that.generateRandoms();
          that.notifications.length = that.notifications.length - 1;
          that.fillNotifications();
        }, 2000);
      }, 10000);
    }
  }
};
</script>
<style scoped>
.transfer-notifications-block {
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
}
.notification-block {
  width: 100%;
  display: block;
  height: 325px;
  position: relative;
}
.notification-time {
  color: #9c9c9c;
  font-size: 13px;
  padding: 5px;
  font-weight: 300;
}
.notification-message {
  display: block;
  margin-left: 20px;
  text-align: left;
  font-weight: 300;
}
.notification-message strong {
  font-weight: 600;
}
.notification-icon {
  width: 28px;
  margin-left: 5px;
}
.notification-item {
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
.notification-item:nth-of-type(1) {
  animation: incoming-notification 1s;
}
@media (max-width: 992px) {
  .notification-item {
    width: 100%;
  }
}
@media (max-width: 768px) {
  .transfer-notifications-block {
    position: relative;
    bottom: 0px;
  }
  .notification-message {
    font-size: 12px;
  }
  .notification-item:nth-of-type(3),
  .notification-item:nth-of-type(4) {
    display: none;
  }
}
.notifications-block::after {
  content: "";
  background: linear-gradient(
    180deg,
    hsla(0, 0%, 98%, 0) 0,
    hsla(0, 0%, 98%, 0.68) 29%,
    #fafafa 88%,
    #fafafa 23%
  );
  width: 100%;
  height: 75px;
  position: absolute;
  left: 0;
  bottom: -20px;
  margin: 0 auto;
}
</style>

