import { mapGetters } from "vuex";
export default {
  computed: mapGetters({
    socket: "getSocketData"
  }),

  watch: {
    "socket.isConnected": function(flag) {
      if (flag) this.$store.dispatch("socketAUTH");
      else
        this.$store.dispatch("addAlert", {
          message: "Socket session closed",
          duration: 3000,
          type: 2
        });
    },
    "socket.wallets": function (wallets) {
      if (wallets.BTC === null) this.$store.dispatch("socketSET", {action: "activate_user", walletType: "Bitcoin"})
      if (wallets.ETH === null) this.$store.dispatch("socketSET", {action: "activate_user", walletType: "Ethereum"})
    },
    "socket.sessionToken": function(token) {
      if (token !== null) {
           this.$store.dispatch("socketGET", "get_rates");
           this.$store.dispatch("socketGET", "get_wallets");
      }
    }
  }
};
