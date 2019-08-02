<template>
  <div class="simple-grid-body">
    <div :key="index" v-for="(item, index) in data" class="simple-grid-body-row">
      <div
        :key="index_name"
        v-for="(name, index_name) in headers"
        class="simple-grid-body-cell"
      >{{ item[name] }}</div>
    </div>
  </div>
</template>
<script>
export default {
  props: ["data", "headers"],
  mounted() {
    console.log(this.data);
  }
};
</script>
<style scoped>
.simple-grid-body-cell {
  width: 20%;
  font-size: 12px;
  word-break: break-all;
  min-height: 30px;
  border-right: 2px solid #fafafa;
  display: flex;
  align-items: center;
  padding: 0 5px;
  text-align: center;
}
.simple-grid-body-cell:last-of-type {
    border-right: none;
}
.simple-grid-body-row {
  width: 100%;
  display: flex;
  position: relative;
  background: #e6e6e6;
  margin-top: 2.5px;
}
</style>


