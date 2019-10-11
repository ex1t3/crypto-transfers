<template>
  <div class="overflowed-block">
    <GridHeader :headers="headers"/>
    <GridBody v-if="data.length > 0" :headers="headers" :data="data" :styles="styles" />
      <div v-if="data.length === 0" class="no-data">No transactions were made yet</div>
  </div>
</template>
<script>
import GridHeader from "./GridHeader";
import GridBody from "./GridBody";
export default {
  props: ["headers", "data", "styles"],
  components: {
    GridHeader,
    GridBody
  },
  mounted () {
    console.log(this.data)
  }
};
</script>
<style scoped>

.overflowed-block {
    overflow-x: auto;
    min-width: 800px;
}

.no-data {
  text-align: center;
  font-size: 16px;
  padding: 25px;
  width: 100%;
}

</style>

