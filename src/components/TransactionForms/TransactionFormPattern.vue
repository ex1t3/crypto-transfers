<template>
  
</template>

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
.rates {
  text-align: right;
  font-size: 12px;
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
    text-align: center;
  }
}
</style>