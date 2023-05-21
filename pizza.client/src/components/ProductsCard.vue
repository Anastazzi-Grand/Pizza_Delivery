<template>
  <div class="card" style="width: 18rem;">
    <img :src="product.image" class="card-img-top" :alt="product.name">
    <div class="card-body">
      <h5 class="card-title">{{ product.name }}</h5>
<!--      <div v-for="(property, index) in product.property" v-bind:key="property.name">-->
<!--        <p>-->
<!--          {{ property.name }}-->
<!--        </p>-->
<!--        <div v-for="(option) in property.options" v-bind:key="option.key" class="form-check">-->
<!--          <input-->
<!--              :disabled="selected > 0"-->
<!--              class="form-check-input"-->
<!--              type="radio"-->
<!--              :name="property.name+product.name"-->
<!--              :id="option.key+'-'+product.id"-->
<!--              :value="option.key"-->
<!--              v-model="markUp[index]">-->
<!--          <label class="form-check-label" :for="option.key+'-'+product.id">-->
<!--            {{ option.value }} {{ (option.markUp + product.price) }} руб.-->
<!--          </label>-->
<!--        </div>-->
<!--      </div>-->
<!--      <template v-if="selected > 0">-->
<!--        <div class="btn-group" role="group" aria-label="Basic example">-->
<!--          <button @click="remove" type="button" class="btn btn-primary">-</button>-->
<!--          <button type="button" class="btn btn-primary">{{selected}}</button>-->
<!--          <button @click="addToBasket" type="button" class="btn btn-primary">+</button>-->
<!--        </div>-->
<!--      </template>-->
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
      markUp: [],
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
  created() {
    // Установка первого значения из списка опций
    this.markUp = Object.keys(this.product.property).reduce((acc, key, index) => (acc.push(this.product.property[index].options[0].key) && acc), []);
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
