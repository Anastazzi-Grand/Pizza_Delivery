<template>
  <Header/>
  <div class="container">
    <div class="row">
      <Aside class="col-4 py-2"/>
      <Main class="col-8 py-2"/>
    </div>
  </div>

</template>

<script>
import Header from './layout/HeaderComponent.vue';
import Main from './layout/MainComponent.vue';
import Aside from './layout/AsideComponent.vue';
import { config } from '@/config';
import { MockDataService } from '@/services/data.service/mock.data.service';
import { DataService } from '@/services/data.service/data.service';
import { BasketService } from './services/basket.service';
import { OrderService } from '@/services/order.service';


export default {
  name: 'App',
  components: {
    Header,
    Main,
    Aside
  },
  provide() {
    return {
      dataService: config.demo ? new MockDataService() : new DataService(),
      basket: new BasketService(),
      orderService: new OrderService()
    }
  }
}
</script>

<style>
#app {

}
</style>
