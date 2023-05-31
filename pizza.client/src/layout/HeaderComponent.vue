<template>
  <div class="navbar text-white sticky-top bg-dark">
    <div class="container-fluid d-flex justify-content-between">
      <h3 class="mb-0">Название</h3>
      <div class="cart d-flex align-items-center">
        <div id="header-search">
        </div>
        <p class="my-0" v-if="basket.total.count === 0">В корзине пусто</p>
        <p v-else class="my-0">
          Выбрано {{ basket.total.count }} на сумму {{ basket.total.sum }}
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
      basket: inject('basket'),
    }
  }
}
</script>
<style>
.cart {
  height: 50px;
}
</style>
