<template>
  <div class="legal-info-header">
    <router-link to="terms" active-class="active">Terms</router-link>
    <router-link to="privacy" active-class="active">Privacy</router-link>
    <router-link to="cookies" active-class="active">Cookies</router-link>
  </div>
</template>
<style scoped>
.active {
  border-bottom: 1px solid #ddd;
}
a {
    margin: 0 15px;    
    color: #2c3e50;
}
.legal-info-header {
  text-align: center;
  padding: 10px 0;
}
</style>