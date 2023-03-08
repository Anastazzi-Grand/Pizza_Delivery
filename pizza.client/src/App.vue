<template>
  <Header/>
  <div class="container">
    <div class="row">
      <Aside class="col-4"/>
      <Main class="col-8"/>
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


export default {
  name: 'App',
  components: {
    Header,
    Main,
    Aside
  },
  provide() {
    return {
      dataService: config.demo ? new MockDataService() : new DataService()
    }
  }
}
</script>

<style>
#app {

}
</style>
