<template>
  <div class="simple-grid-body">
    <div
      :key="index"
      v-for="(item, index) in data"
      class="simple-grid-body-row"
      :style="getStyle(item)"
    >
      <div
        :key="index_name"
        v-for="(header, index_name) in headers"
        class="simple-grid-body-cell"
      >{{ item[header.Name] }}</div>
    </div>
  </div>
</template>
<script>
export default {
  props: ["data", "headers", "styles"],
  methods: {
    getStyle(item) {
      return this.styles === undefined
        ? null
        : this.styles.values[item[this.styles.key]];
    }
  }
};
</script>
<style scoped>
.simple-grid-body-cell {
  width: 20%;
  font-size: 12px;
  word-break: break-word;
  min-height: 45px;
  padding: 10px 0 5px 0;
  text-align: center;
}
.simple-grid-body-cell:last-of-type {
  border-right: none;
}
.simple-grid-body-row {
  width: 100%;
  display: flex;
  position: relative;
  background: #f0f0f0;
}
.simple-grid-body-row:nth-child(2n) {
  background: #f6f6f6;
}
</style>


