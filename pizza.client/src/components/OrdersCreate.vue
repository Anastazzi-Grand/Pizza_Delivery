<template>
  <p>Создание заказа</p>
  <form @submit.prevent="onSubmit" class="d-grid gap-2">
    <input v-model="fullName" type="text" placeholder="Имя"/>
    <input v-model="phoneNumber" type="text" placeholder="Номер телефона"/>
    <input v-model="address" type="text" placeholder="Адрес"/>
    <button type="submit" class="btn btn-primary w-100">Заказать</button>
  </form>
</template>

<script>
import router from '@/router/router';
import { inject } from 'vue';

export default {
  name: 'OrdersCreate',
  data() {
    return {
      fullName: null,
      phoneNumber: null,
      address: null
    }
  },
  setup() {
    return {
      /**
       * @type {OrderService}
       * */
      orderService: inject('orderService'),
      /**
       * @type {BasketService}
       * */
      basket: inject('basket')
    }
  },
  methods: {
    onSubmit() {
      if (!this.fullName || !this.phoneNumber || !this.address) {
        // если пустые поля, то не отправляем
        return;
      }
      this.orderService.createOrder({
        fullName: this.fullName,
        phoneNumber: this.phoneNumber,
        address: this.address,
     orderDate: new Intl.DateTimeFormat('ru-RU', {
            year: 'numeric',
            month: '2-digit',
            day: '2-digit',
            hour: '2-digit',
            minute: '2-digit',
            second: '2-digit'
          }).format(new Date()),
          deliveryDate: new Intl.DateTimeFormat('ru-RU', {
            year: 'numeric',
            month: '2-digit',
            day: '2-digit',
            hour: '2-digit',
            minute: '2-digit',
            second: '2-digit'
          }).format(new Date(new Date().setHours(new Date().getHours() + 1))),
          totalPrice: this.basket.total.sum,
          // eslint-disable-next-line no-unused-vars
          orderItems: Array.from(this.basket.cart).reduce((acc, [_, list]) => {
            list.forEach(p => acc.push({
              productId: p.id
            }))
            return acc;
          }, [])
      }).then(() => {
        this.basket.clear()
        router.push({name: 'Catalog'})
      })
    }
  }

}
</script>

<style scoped>

</style>
