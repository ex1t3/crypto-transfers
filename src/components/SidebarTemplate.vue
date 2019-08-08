<template>
  <div class="col-sm-10 offset-sm-1 sidebar-block">
    <div
      class="content-sidebar-item"
      :class="{'active': currentPage === item.Name}"
      :key="index"
      v-for="(item, index) in items.sidebarItems"
      @click="setCurrentPage(item.Name)"
    >{{ item.Label }}</div>
  </div>
</template>
<script>
import store from "../store";
import { mapGetters } from "vuex";
export default {
  props: ["items"],
  computed: mapGetters({
    currentPage: "getCurrentPage"
  }),
  mounted() {
    this.setCurrentPage(this.items.sidebarItems[0].Name);
  },
  methods: {
    setCurrentPage(page) {
      this.$store.dispatch("setCurrentPage", page);
    }
  }
};
</script>

<style scoped>
.sidebar-block {
  display: flex;
  padding-top: 100px;
}
@media (max-width: 560px) {
  .sidebar-block {
    display: block;
  }
}
.content-sidebar-item {
  padding: 8px;
  transition: 0.5s background-color;
  cursor: pointer;
  font-size: 12px;
  margin: 0 auto;
  border-radius: 5px;
  display: flex;
  align-items: center;
}
.content-sidebar-item:hover {
  background-color: #ddd;
}
.content-sidebar-item.active {
  background-color: #ddd;
}
</style>
