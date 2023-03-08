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


export default {
  name: 'App',
  components: {
    Header,
    Main,
    Aside
}
}
</script>

<style>
#app {

}
</style>
