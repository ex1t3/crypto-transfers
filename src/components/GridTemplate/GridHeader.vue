<template>
    <div class="simple-grid-header">
        <div :key="index" v-for="(item, index) in headers" class="simple-grid-header-item">
            {{ item.Label }}
        </div>
    </div>
</template>
<script>
export default {
    props: ['headers']
}
</script>
<style scoped>
.simple-grid-header {
    background: #ddd;
    display: flex;
    width: 100%;
    padding: 10px 0px;
    border-top-left-radius: 3px;
    border-top-right-radius: 3px;
}
.simple-grid-header-item {
    padding: 5px;
    margin: 0 auto;
    font-size: 12px;
    width: 20%;
    word-break: break-all;
}
</style>


