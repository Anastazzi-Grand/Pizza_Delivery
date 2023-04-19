<template>
  <div class="card" style="width: 18rem;">
    <img :src="product.image" class="card-img-top" :alt="product.name">
    <div class="card-body">
      <h5 class="card-title">{{ product.name }}</h5>
      <div v-for="(property, index) in product.property" v-bind:key="property.name">
        <p>
          {{ property.name }}
        </p>
        <div v-for="(option) in property.options" v-bind:key="option.key" class="form-check">
          <input
              :disabled="selected > 0"
              class="form-check-input"
              type="radio"
              :name="property.name+product.name"
              :id="option.key+'-'+product.id"
              :value="option.key"
              v-model="markUp[index]">
          <label class="form-check-label" :for="option.key+'-'+product.id">
            {{ option.value }} {{ (option.markUp + product.price) }} руб.
          </label>
        </div>
      </div>
      <template v-if="selected > 0">
        <div class="btn-group" role="group" aria-label="Basic example">
          <button @click="remove" type="button" class="btn btn-primary">-</button>
          <button type="button" class="btn btn-primary">{{selected}}</button>
          <button @click="addToBasket" type="button" class="btn btn-primary">+</button>
        </div>
      </template>
      <button v-else type="button" class="btn btn-primary" @click="addToBasket">Выбрать</button>
    </div>
  </div>
</template>
<script>


import { inject } from 'vue';

export default {
  data() {
    return {
      markUp: [],
      selected: 0,
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
      this.selected ++;
      this.$emit('add-to-cart', this.markUp);
    },
    remove() {
      this.selected --;
      this.$emit('remove-with-cart', this.markUp);
    }
  }
}

</script>
<style lang="">

</style>
