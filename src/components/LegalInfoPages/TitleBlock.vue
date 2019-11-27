<template>
  <div>
    <p>
      <a :href="downloadLink">Download PDF</a>
    </p>
    <h2>{{ name }}</h2>
    <p class="last-update">Last updated: {{ lastUpdate }}</p>
    <hr/>
  </div>
</template>
<script>
export default {
  props: {
    name: String,
    lastUpdate: String,
    downloadLink: String
  }
};
</script>
<style scoped>
.last-update {
    color: #828d97;
}
</style>