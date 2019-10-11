<template></template>

<script>
import { mapGetters } from "vuex";
import store from "../../store";
export default {
  store,
  data() {
    return {
      isLoading: false,
      isConfirmationVisible: false
    };
  },
  computed: mapGetters({
    socket: "getSocketData",
    exchange: "getExchangeData",
    transfer: "getTransferData"
  }),
  methods: {
    updateForm(commit, data) {
      this.$store.dispatch(commit, data);
    }
  }
};
</script>

<style scoped>
.form-control:focus {
  box-shadow: 0 0 0 0rem rgba(143, 136, 206, 0.17);
  border: transparent;
}
.exchange-to-icon {
  padding-top: 10px;
}
.rates {
  text-align: center;
  font-size: 13px;
  margin: 0;
}
.selected-currency {
  margin: 0 3px;
  font-weight: 600;
  border-bottom: 1px solid;
}
@media (max-width: 768px) {
  #termsAgreement {
    margin-top: 15px;
  }
  .rates {
    display: inline-block;
    margin-top: 10px;
    font-size: 12px;
  }
}
@media (max-width: 576px) {
  .exchange-to-icon {
    padding: 0;
    transform: rotateZ(90deg);
  }
}
</style>