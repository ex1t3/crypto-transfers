<template>
  <transition-group class="alert-block" name="alert" tag="div">
    <div :class="item.type" class="alert-item" v-for="item in alerts" :key="item.id">
      <p class="alert-message">{{ item.message }}</p>
      <button class="close-alert" @click="$store.dispatch('removeAlert', item.id)">&times;</button>
    </div>
  </transition-group>
</template>
<script>
import { mapGetters } from "vuex";
import store from "../store";
export default {
  store,
  computed: mapGetters({
    alerts: "getAlerts"
  })
};
</script>
<style scoped>
.alert-block {
  position: fixed;
  right: 2%;
  top: 100px;
  z-index: 9999;
}
.alert-item {
  min-height: 80px;
  width: 250px;
  box-shadow: 0px 1px 14px 0px rgba(120, 120, 120, 0.24);
  transition: .3s;
  border-radius: 3px;
  color: #2c3e50;
  background: rgb(255, 2555, 255);
  margin-bottom: 20px;
  position: relative;
}
.alert-enter-active {
  opacity: 1;
}
.alert-enter, .alert-leave-to /* .list-leave-active below version 2.1.8 */ {
  opacity: 0;
  transform: translateX(30px);
}

.alert-message {
  padding: 20px;
  margin: 0;
  text-align: left;
}
.alert-message::before {
  content: "";
  position: absolute;
  height: 100%;
  width: 5px;
  top: 50%;
  left: 0px;
  border-top-left-radius: 3px;
  border-bottom-left-radius: 3px;
  transform: translateY(-50%);
}
.alert-item.success .alert-message::before {
  background: #6bd175;
}
.alert-item.error .alert-message::before {
  background: #df4437;
}
.alert-item.info .alert-message::before {
  background: #dfb737;
}
.alert-item .close-alert {
  border: none;
  overflow: hidden;
  padding: 2px 10px;
  background: transparent;
  cursor: pointer;
  position: absolute;
  right: 5px;
  top: 10px;
  font-size: 16px;
}
@keyframes appear {
  from {
    opacity: 0;
    transform: translateX(40px);
  }
  to {
    opacity: 1;
    transform: translateX(0);
  }
}
</style>
