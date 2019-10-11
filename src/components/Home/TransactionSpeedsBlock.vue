<template>
  <b-container class="islb-crypto-transfers--transaction-speeds">
    <b-row>
      <div id="speed-bar-block" class="col-sm-12">
        <h2>Cryptocurrencies transaction speeds</h2>
        <h4>Compare to Visa and PayPal</h4>
      </div>
    </b-row>
    <b-row>
      <div class="speed-bar-block" :class="{scrolled: isScrolledToBlock }">
        <div class="speed-bar-item islb-speed">
          <h4 class="speed-bar-title">ISLB</h4>
          <h5 class="speed-bar-amount">
            <span id="speed-value-islb" data-value="100000">0</span>k
          </h5>
        </div>
        <div class="speed-bar-item visa-speed">
          <h4 class="speed-bar-title">VISA</h4>
          <h5 class="speed-bar-amount">
            <span id="speed-value-visa" data-value="24000">0</span>k
          </h5>
        </div>
        <div class="speed-bar-item ripple-speed">
          <h4 class="speed-bar-title">RIPPLE</h4>
          <h5 class="speed-bar-amount">
            <span id="speed-value-ripple" data-value="1500">0</span>k
          </h5>
        </div>
        <div class="speed-bar-item paypal-speed">
          <h4 class="speed-bar-title">PAYPAL</h4>
          <h5 class="speed-bar-amount">
            <span id="speed-value-paypal" data-value="193">0</span>
          </h5>
        </div>
        <div class="speed-bar-item etherium-speed">
          <h4 class="speed-bar-title">ETHEREUM</h4>
          <h5 class="speed-bar-amount">
            <span id="speed-value-ethereum" data-value="20">0</span>
          </h5>
        </div>
      </div>
      <p class="speed-explanation">Transactions per second (tps)</p>
    </b-row>
  </b-container>
</template>
<script>
export default {
  data() {
    return {
      isScrolledToBlock: false
    };
  },
  methods: {
    handleScroll(event) {
      if (!this.isScrolledToBlock) {
        if (
          this.isScrolledIntoView(document.getElementById("speed-bar-block"))
        ) {
          this.isScrolledToBlock = true;
          this.animateValue("speed-value-islb", 2500);
          this.animateValue("speed-value-visa", 2500);
          this.animateValue("speed-value-paypal", 2500);
          this.animateValue("speed-value-ripple", 2500);
          this.animateValue("speed-value-ethereum", 2500);
        }
      }
    },
    isScrolledIntoView(el) {
      var rect = el.getBoundingClientRect();
      var elemTop = rect.top;
      var elemBottom = rect.bottom;

      // Only completely visible elements return true:
      var isVisible = elemTop >= 0 && elemBottom <= window.innerHeight;
      // Partially visible elements return true:
      //isVisible = elemTop < window.innerHeight && elemBottom >= 0;
      return isVisible;
    },
    animateValue(id, duration) {
      // assumes integer values for start and end

      var obj = document.getElementById(id);
      let start = 0;
      let end = parseInt(obj.dataset.value);
      var range = end - start;
      // no timer shorter than 50ms (not really visible any way)
      var minTimer = 50;
      // calc step time to show all interediate values
      var stepTime = Math.abs(Math.floor(duration / range));

      // never go below minTimer
      stepTime = Math.max(stepTime, minTimer);

      // get current time and calculate desired end time
      var startTime = new Date().getTime();
      var endTime = startTime + duration;
      var timer;

      function run() {
        var now = new Date().getTime();
        var remaining = Math.max((endTime - now) / duration, 0);
        var value = Math.round(end - remaining * range);
        obj.innerHTML = value > 1000 ? value / 1000 : value;
        if (value == end) {
          clearInterval(timer);
        }
      }

      timer = setInterval(run, stepTime);
      run();
    }
  },
  created() {
    window.addEventListener("scroll", this.handleScroll);
  },
  destroyed() {
    window.removeEventListener("scroll", this.handleScroll);
  }
};
</script>

<style scoped>
.islb-crypto-transfers--transaction-speeds {
  margin: 50px auto;
  text-align: center;
  padding-top: 20px;
  padding-bottom: 20px;
}
.speed-explanation {
  margin-top: 60px;
  font-size: 14px;
  width: 100%;
}
.speed-bar-block {
  margin-top: 20px;
  height: 300px;
  display: -webkit-box;
  display: -ms-flexbox;
  display: flex;
  width: 100%;
  align-items: flex-end;
}
.speed-bar-item {
  width: 16%;
  height: 0;
  transition: 2.5s height;
  position: relative;
  margin: 0 auto;
  background: linear-gradient(#493bc3, #aea9e2);
}
.scrolled .speed-bar-item.islb-speed {
  height: 100%;
}
.scrolled .speed-bar-item.visa-speed {
  height: 25%;
}
.scrolled .speed-bar-item.ripple-speed {
  height: 15%;
}
.scrolled .speed-bar-item.paypal-speed {
  height: 10%;
}
.scrolled .speed-bar-item.etherium-speed {
  height: 2%;
}
.speed-bar-title {
  position: absolute;
  bottom: -40px;
  margin: 0;
  left: 50%;
  transform: translateX(-50%);
}
.speed-bar-amount {
  top: -30px;
  position: absolute;
  margin: 0;
  left: 50%;
  transform: translateX(-50%);
}
@media (max-width: 700px) {
  .speed-bar-title {
    bottom: -30px;
  }
  .speed-bar-amount {
    top: -20px;
  }
  .speed-explanation {
    font-size: 12px;
    margin-top: 40px;
  }
}
</style>