<template>
  <div class="overflowed-block">
    <GridHeader :headers="headers"/>
    <GridBody :headers="headers" :data="data" />
  </div>
</template>
<script>
import GridHeader from "./GridHeader";
import GridBody from "./GridBody";
export default {
  props: ["headers", "data"],
  components: {
    GridHeader,
    GridBody
  }
};
</script>
<style scoped>

.overflowed-block {
    overflow-x: auto;
    min-width: 600px;
}
</style>

