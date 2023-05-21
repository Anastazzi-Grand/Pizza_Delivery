<template>
  <div>Корзина</div>
</template>

<script>
import { inject } from 'vue';

export default {
  name: 'CartPage',
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
