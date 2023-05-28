<template>
  <div class="card" style="width: 18rem;">
    <img :src="product.image" class="card-img-top" :alt="product.group">
    <div class="card-body">
      <h5 class="card-title">{{ product.name }}</h5>
      <button v-if="!basket.cart.get(product.id)?.length" type="button" class="btn btn-primary w-100" @click="basket.addProductToBasket(product)">Выбрать</button>
      <div v-else class="d-grid gap-2">
        <router-link class="btn btn-primary" to="/cart">
          <span>Перейти к оформлению</span>
        </router-link>
        <button type="button" class="btn btn-secondary" @click="basket.removeProductFromBasket(product.id)">Удалить из заказа</button>
      </div>
    </div>
  </div>
</template>
<script>


import { inject } from 'vue';

export default {
  data() {
    return {
      selected: false,
      /**
       * @type {BasketService}
       * */
      basket: inject('basket')
    }
  },
  props: {
    /**
     @type{{
            id: number;
            group: string;
            name: string;
            property: {
                name: string;
                options: {
                    key: string;
                    value: string;
                    markUp: number;
                        }
                    }[];
            price: number;
            image: string;
            cookingTime: string
        }}
     */
    product: Object
  },
  emits: ['add-to-cart'],
  methods: {
    addToBasket() {
      console.log('addToBasket')
      this.selected = true;
      // this.$emit('add-to-cart', this.markUp);
    },
    remove() {
      this.selected = false;
      // this.$emit('remove-with-cart', this.markUp);
    }
  }
}

</script>
<style lang="">

</style>
