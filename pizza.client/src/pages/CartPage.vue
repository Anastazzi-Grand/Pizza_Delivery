<template>
  <div>Корзина</div>
  <div class="d-grid gap-2">
    <ProductCardByCart v-for="(productList, index) in basket.cart" v-bind:key="index" :products="productList[1]"/>
  </div>
  <router-link class="btn btn-primary mb-4" to="orders/create">
    <span>Оформить заказ</span>
  </router-link>
</template>

<script>
import { inject } from 'vue';
import ProductCardByCart from '@/components/ProductCardByCart.vue';

export default {
  name: 'CartPage',
  components: {ProductCardByCart},
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
}
</script>

<style scoped>

</style>
