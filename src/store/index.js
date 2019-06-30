import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    user: [],
    isLoggedIn: false,
  },
  getters: {
    getUser: state => {
      return state.user
    },
    getLoginState: state => {
      return state.isLoggedIn
    }
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setLoginState(state, flag) {
      state.isLoggedIn = flag
    }
  },
  actions: {}
});