<template>
  <div class="card" style="width: 38rem;">
    <div class="row g-0">
      <div class="col-md-7">
        <img :src="details.image" class="img-fluid rounded-start" :alt="details.name">
      </div>
      <div class="col-md-5">
        <div class="card-body">
          <h5 class="card-title">{{ details.name }}</h5>
          <p>Цена {{ details.price }} рублей</p>
          <p>Количество в заказе: {{ products.length }} шт</p>
          <p>Стоимость: {{ details.price * products.length }} рублей</p>
          <button type="button" class="btn btn-primary w-100" @click="basket.addProductToBasket(details)">Добавить ещё
          </button>
          <span></span>
          <button type="button" class="btn btn-secondary w-100 mt-2" @click="basket.removeProductFromBasket(this.products[0].id)">Удалить из заказа</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { inject } from 'vue';

export default {
  name: 'ProductCardByCart',
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
  computed: {
    /**
     * @type {{
     *             id: number;
     *             group: string;
     *             name: string;
     *             property: {
     *                 name: string;
     *                 options: {
     *                     key: string;
     *                     value: string;
     *                     markUp: number;
     *                         }
     *                     }[];
     *             price: number;
     *             image: string;
     *             coockingTime: string
     *         }}
     * */
    details: {
      get() {return this.dataService.getProductsById(this.products[0].id)}
    }
  },
  props: {
    /**
     @type{{
            id: number;
            property: {
                id: number;
                name: string;
                options: {
                    key: string;
                    value: string;
                    markUp: number;
                        }
                    }[];
            price: number;
        }[]}
     */
    products: Array,
  },
}
</script>

<style scoped>

</style>
