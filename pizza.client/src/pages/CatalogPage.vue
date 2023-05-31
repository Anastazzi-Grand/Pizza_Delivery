<template>
  <div class="d-grid gap-2">
    <ProductsCard
        :product="item"
        v-for="item in filteredProducts" v-bind:key="item.id"></ProductsCard>
  </div>
</template>
<script>
import ProductsCard from '../components/ProductsCard.vue';
import { inject } from 'vue';
import { reactive } from 'vue';

export default {
  data() {
    return {
      catalog: reactive([]),
      term: {
        get() {return this.dataService.searchTerm.toLowerCase()}
      }
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
  computed: {
      filteredProducts: {
        get() {
          console.log(this.catalog)
          console.log(this.dataService.searchTerm)
          console.log(this.term.value?.length ? this.catalog?.filter(product => product.name.toLowerCase().includes(this.term.value)) : this.catalog)
          return this.term.value?.length ? this.catalog?.filter(product => product.name.toLowerCase().includes(this.term.value)) : this.catalog}
      }
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
