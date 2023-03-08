<template>
    <ProductsCard :product="item" v-for="item in catalog" v-bind:key="item.id"></ProductsCard>
</template>
<script>
import ProductsCard from './ProductsCard.vue';
import {inject} from 'vue';
export default {
    async setup(){
        const dataService = inject('dataService')
    const catalog = await dataService.getProducts()
    return catalog
    },

    components: { ProductsCard }
}
</script>
<style lang="">
    
</style>