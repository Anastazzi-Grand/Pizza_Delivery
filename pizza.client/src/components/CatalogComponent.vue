<template>
  <ProductsCard :product="item" v-for="item in catalog" v-bind:key="item.id"></ProductsCard>
</template>
<script>
import ProductsCard from './ProductsCard.vue';
import { inject } from 'vue';

export default {
  data() {
    return {
      catalog: []
    }
  },
  setup() {
    const dataService = inject('dataService');
    return {
      dataService
    }
  },
  created() {
    this.dataService.getProducts().then(data => {
      this.catalog = data;
    })
  },
  components: {ProductsCard}
}
</script>
<style lang="">

</style>
