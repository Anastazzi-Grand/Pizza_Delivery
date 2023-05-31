<template>
  <div class="navbar text-white sticky-top bg-dark">
    <div class="container-fluid d-flex justify-content-between">
      <h3 class="mb-0">Название</h3>
      <div class="cart d-flex align-items-center">
        <form class="d-flex mx-5" @submit.prevent="search">
          <input v-model="searchTerm" class="form-control mr-2" type="search" placeholder="Поиск по названию" aria-label="Search">
          <button class="btn btn-outline-success" type="submit">Найти</button>
        </form>
        <p class="my-0" v-if="basket.total.count === 0">В корзине пусто</p>
        <p v-else class="my-0">
          Выбрано {{basket.total.count}} на сумму {{basket.total.sum}}
          <button class="btn btn-warning mx-2">Перейти в корзину</button>
        </p>
      </div>
    </div>
  </div>
</template>
<script>
import { inject } from 'vue';

export default {
    data() {
      return {
        basket: inject("basket"),
          /**
         * @type {AbstractDataService}
         * */
        dataService: inject('dataService'),
        searchTerm: ''
      }
    },
  computed: {
    cart() {
      return this.basket.cart
    }
  },
  methods: {
      search() {
        this.dataService.searchTerm = this.searchTerm
        console.log(this.searchTerm)
        this.searchTerm = ''; // очищаем поле ввода

    },
  }
}
</script>
<style>
    .cart {
      height: 50px;
    }
</style>
