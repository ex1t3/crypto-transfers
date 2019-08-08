<template>
  <div>
    <LoginModal v-if="!isLoggedIn" />
    <RemindPasswordModal v-if="!isLoggedIn" />
    <SignUpModal v-if="!isLoggedIn" />
    <ExchangeConfirm v-if="isOpenedExchangeConfirm"/>
  </div>
</template>
<script>
import LoginModal from "@/components/Modals/LoginModal";
import RemindPasswordModal from "@/components/Modals/RemindPasswordModal";
import SignUpModal from "@/components/Modals/SignUpModal";
import ExchangeConfirm from "@/components/Modals/ExchangeConfirmModal";

import { mapGetters } from "vuex";
export default {
  computed: mapGetters({
    isLoggedIn: "getLoginState",
    isOpenedExchangeConfirm: "getExchangeConfirmationState"
  }),
  components: {
    LoginModal,
    RemindPasswordModal,
    SignUpModal,
    ExchangeConfirm
  }
};
</script>
<style>
.modal-header {
  padding: 1rem 1.5rem;
  border-bottom: 1px solid #48446808;
}
.close,
.modal-title {
  color: #0d016b;
}
.modal {
  color: #08023e;
}
.modal a {
  color: #595292;
}
.modal a:hover {
  color: #0d016b;
}
.modal-title {
  margin: 0;
}
</style>


