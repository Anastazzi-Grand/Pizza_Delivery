<template>
  <div class="d-grid gap-2">
    <ProductsCard
        :product="item"
        v-for="item in filteredProducts" v-bind:key="item.id"></ProductsCard>
  </div>
  <teleport to="#header-search">
    <form class="d-flex mx-5">
      <input @input="search" v-model="searchTerm" class="form-control mr-2" type="search" placeholder="Поиск по названию" aria-label="Search">
    </form>
  </teleport>
</template>
<script>
import ProductsCard from '../components/ProductsCard.vue';
import { inject } from 'vue';
import { reactive } from 'vue';

export default {
  data() {
    return {
      catalog: reactive([]),
      searchTerm: '',
      term: ''

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
      this.term = data;
    })
  },
  computed: {
      filteredProducts: {
        get() {
          return this.term;
        },
        set(value) {
          this.term = this.catalog?.filter(product => value ? product.name.toLowerCase().includes(value.toLowerCase()) : product);
        }
      }
    },
  methods: {
    search(event) {
      this.filteredProducts = event.target.value;
    }
  },
  components: {ProductsCard}
}
</script>
<style lang="">

</style>
