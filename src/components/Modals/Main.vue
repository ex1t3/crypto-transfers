<template>
  <div>
    <LoginModal/>
    <RemindPasswordModal/>
    <SignUpModal/>
  </div>
</template>
<script>
import LoginModal from "@/components/Modals/LoginModal";
import RemindPasswordModal from "@/components/Modals/RemindPasswordModal";
import SignUpModal from "@/components/Modals/SignUpModal";
export default {
  components: {
    LoginModal,
    RemindPasswordModal,
    SignUpModal
  }
};
</script>
<style>
.modal-header {
  padding: 1rem 1.5rem;
  border-bottom: 1px solid #48446808;
}
.close, .modal-title {
  color: #0d016b;
}
.modal {
  color: #08023e;
}
.modal a {
  color: #595292;
}
.modal a:hover {
  color: #0d016b
}
.modal-title {
  margin: 0;
}
</style>


