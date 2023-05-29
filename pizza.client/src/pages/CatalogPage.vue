<template>
  <div class="d-grid gap-2">
    <ProductsCard
        :product="item"
        v-for="item in catalog" v-bind:key="item.id"></ProductsCard>
  </div>
</template>
<script>
import ProductsCard from '../components/ProductsCard.vue';
import { inject } from 'vue';

export default {
  data() {
    return {
      catalog: []
    }
  },
  setup() {
    return {
      /**
       * @type {AbstractDataService}
       * */
      dataService: inject('dataService'),
      /**
       * @type {BasketService}
       * */
      basket: inject('basket')
    }
  },
  created() {
    this.dataService.getProducts().then(data => {
      this.catalog = data;
    })
  },
  methods: {
    addToCard(markUp, product) {
      this.basket.addProductToBasket(product, markUp)
    }
  },
  components: {ProductsCard}
}
</script>
<style lang="">

</style>
