<template>
    <div class="card" style="width: 18rem;">
        <img :src="product.image" class="card-img-top" :alt="product.name">
        <div class="card-body">
          <h5 class="card-title">{{product.name}}</h5>
          <div v-for="(property) in product.property" v-bind:key="property.name">
            <p>
                {{ property.name }}
            </p>
            <div v-for="(option, index) in property.options" v-bind:key="option.key" class="form-check">
                <input class="form-check-input" type="radio" :checked="index===0" :name="property.name+product.name" :id="option.key+'-'+product.id">
                <label class="form-check-label" :for="option.key+'-'+product.id">
                  {{ option.value }} {{ (option.markUp + product.price)}} руб.
                </label>
              </div>
          </div>
          <a href="#" class="btn btn-primary" @click="basket.addProductToBasket(product)">Заказать</a>
          <div class="btn-group" role="group" aria-label="Basic example">
            <button type="button" class="btn btn-primary">-</button>
            <button type="button" class="btn btn-primary">Выбрать</button>
            <button type="button" class="btn btn-primary">+</button>
          </div>
        </div>
      </div>
</template>
<script>

import { inject } from 'vue';
export default {
    props: {
        /** 
       {
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
        }
        */
        product: Object
    },
    setup() {
    const basket = inject('basket');
    return {
      basket
    }
  }
}
</script>
<style lang="">
    
</style>
