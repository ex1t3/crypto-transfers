import Vue from "vue";
import Vuex from "vuex";
import {
  SOCKET_ONOPEN,
  SOCKET_ONCLOSE,
  SOCKET_ONERROR,
  SOCKET_ONMESSAGE,
  SOCKET_RECONNECT,
  SOCKET_RECONNECT_ERROR
} from "./mutation-types";

Vue.use(Vuex);

const vm = new Vue();

export default new Vuex.Store({
  state: {
    user: Array,
    alerts: [],
    alertId: 0,
    isLoggedIn: false,
    currentPage: String,
    socket: {
      isConnected: false,
      message: "",
      reconnectError: false,
      sessionToken: null,
      rates: Array
    },
    transfer: {
      currency: "ETH",
      blockchainFee: "Regular",
      address: String,
      amount: {
        type: Number
      }
    },
    exchange: {
      givenCurrency: "ETH",
      receivedCurrency: "BTC",
      givenAmount: {
        type: Number
      },
      receivedAmount: {
        type: Number
      }
    },
    loadingButtonState: false
  },
  getters: {
    getUser: state => state.user,
    getAlerts: state => state.alerts,
    getLoginState: state => state.isLoggedIn,
    getCurrentPage: state => state.currentPage,
    getTransferData: state => state.transfer,
    getExchangeData: state => state.exchange,
    getSocketData: state => state.socket
  },
  actions: {
    authenticate: context => {
      let data = {
        action: "initialize_session",
        email: context.state.user.email,
        token: context.state.user.socketToken
      };
      Vue.prototype.$socket.send(JSON.stringify(data));
    },
    send: (context, message) => {
      let data = {
        action: message,
        token: context.state.socket.sessionToken
      };
      Vue.prototype.$socket.send(JSON.stringify(data));
    },
    setUser({ commit }, user) {
      commit("setUser", user);
    },
    addAlert({ commit }, alert) {
      commit("addAlert", alert);
      setTimeout(() => {
        commit("removeAlert", alert.id);
      }, alert.duration);
    },
    removeAlert({ commit }, index) {
      commit("removeAlert", index);
    },
    setLoginState({ commit }, flag) {
      commit("setLoginState", flag);
    },
    setCurrentPage({ commit }, page) {
      commit("setCurrentPage", page);
    },
    setTransferData({ commit }, data) {
      commit("setTransferData", data);
    },
    setExchangeData({ commit }, data) {
      commit("setExchangeData", data);
    }
  },
  mutations: {
    setUser(state, user) {
      state.user = user;
    },
    addAlert(state, alert) {
      state.alerts.unshift(alert);
      let index = state.alertId++;
      alert.id = index;
    },
    removeAlert(state, index) {
      state.alerts.splice(
        state.alerts
          .map(x => {
            return x.id;
          })
          .indexOf(index),
        1
      );
    },
    setLoginState(state, flag) {
      state.isLoggedIn = flag;
      if (flag) {
        vm.$connect();
      } else {
        state.user = null;
        vm.$disconnect();
      }
    },
    setCurrentPage(state, page) {
      state.currentPage = page;
    },
    setTransferData(state, data) {
      state.transfer = data;
    },
    setExchangeData(state, data) {
      data.receivedAmount = data.givenAmou;
      state.exchange = data;
    },
    [SOCKET_ONOPEN](state, event) {
      state.socket.isConnected = true;
      console.log(event);
    },
    [SOCKET_ONCLOSE](state, event) {
      state.socket.isConnected = false;
      state.socket.sessionToken = null;
      console.log(event);
    },
    [SOCKET_ONERROR](state, data) {
      console.log(data);
    },
    [SOCKET_ONMESSAGE](state, data) {
      console.log(data);
      switch (data.ResponseType) {
        case "initialize_session":
          state.socket.sessionToken = data.Token;
        case "get_rates":
          state.socket.rates = data.Rates;
      }
    },
    // mutations for reconnect methods
    [SOCKET_RECONNECT](state, count) {
      console.info(count);
    },
    [SOCKET_RECONNECT_ERROR](state) {
      state.socket.reconnectError = true;
    }
  }
});
