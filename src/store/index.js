import Vue from "vue";
import Vuex from "vuex";
import {
  SOCKET_ONOPEN,
  SOCKET_ONCLOSE,
  SOCKET_ONERROR,
  SOCKET_ONMESSAGE,
  SOCKET_RECONNECT,
  SOCKET_RECONNECT_ERROR,
  OPEN_EXCHANGE_CONFIRM,
  OPEN_TRANSFER_CONFIRM,
  PAGE_LOADED
} from "./mutation-types";

Vue.use(Vuex);

const vm = new Vue();

export default new Vuex.Store({
  state: {
    isPageLoaded: false,
    user: Array,
    alerts: [],
    alertId: 0,
    isLoggedIn: false,
    isExchangeConfirmOpened: false,
    isTransferConfirmOpened: false,
    currentPage: String,
    socket: {
      isConnected: false,
      message: "",
      reconnectError: false,
      sessionToken: null,
      rates: Array,
      wallets: Array
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
      givenAmount: "",
      receivedAmount: "",
      addressTo: "",
      payment: Array
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
    getSocketData: state => state.socket,
    getExchangeConfirmationState: state => state.isExchangeConfirmOpened,
    getTransferConfirmationState: state => state.isTransferConfirmOpened,
    isPageLoaded: state => state.isPageLoaded
  },
  actions: {
    socketAUTH: context => {
      let data = {
        action: "initialize_session",
        email: context.state.user.email,
        token: context.state.user.socketToken
      };
      Vue.prototype.$socket.send(JSON.stringify(data));
    },
    socketGET: (context, message) => {
      let data = {
        action: message,
        token: context.state.socket.sessionToken
      };
      Vue.prototype.$socket.send(JSON.stringify(data));
    },
    socketSET: (context, data) => {
      data.token = context.state.socket.sessionToken;
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
    },
    setExchangeConfirm({ commit }) {
      commit(OPEN_EXCHANGE_CONFIRM);
    },
    openTransferConfirm({ commit }) {
      commit(OPEN_TRANSFER_CONFIRM);
    },
    loadPage({ commit }) {
      commit(PAGE_LOADED);
    }
  },
  mutations: {
    setUser(state, user) {
      if (user.identity.year === user.identity.month)
        user.identity.year = user.identity.month = user.identity.day = user.identity.dialCode = user.identity.country =
          "";
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
      if (isNaN(data.givenAmount)) {
        data.givenAmount = "";
        data.receivedAmount = "";
        return;
      }
      data.addressTo = data.addressTo === "" ? state.user.wallets[data.receivedCurrency.toLowerCase()] : data.addressTo;
      data.receivedAmount =
        data.givenAmount /
        (state.socket.rates[data.receivedCurrency] /
          state.socket.rates[data.givenCurrency]);
      state.exchange = data;
    },
    [OPEN_EXCHANGE_CONFIRM](state) {
      state.isExchangeConfirmOpened = !state.isExchangeConfirmOpened;
    },
    [OPEN_TRANSFER_CONFIRM](state) {
      state.isTransferConfirmOpened = !state.isTransferConfirmOpened;
    },
    [PAGE_LOADED](state) {
      state.isPageLoaded = true;
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
        case "initialize_session": {
          state.socket.sessionToken = data.Token;
          break;
        }
        case "get_rates": {
          state.socket.rates = data.Rates;
          break;
        }
        case "get_wallets": {
          state.socket.wallets = {
            BTC: data.Wallets[0],
            ETH: data.Wallets[1]
          };
          break;
        }
        case "activate_user": {
          switch (data.WalletType) {
            case "Bitcoin":
              state.socket.wallets.BTC = data.Address;
              break;
            case "Ethereum":
              state.socket.wallets.ETH = data.Address;
              break;
            default:
              break;
          }
        }
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
