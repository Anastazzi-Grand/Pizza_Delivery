<template>
    <div>
        {{ product.name }}
        цена: {{ product.price }}
    </div>
    <div class="card" style="width: 18rem;">
        <img :src="product.image" class="card-img-top" :alt="product.name">
        <div class="card-body">
          <h5 class="card-title">{{product.name}}</h5>
          <a href="#" class="btn btn-primary">Заказать</a>
        </div>
      </div>
</template>
<script>
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
    }
}
</script>
<style lang="">
    
</style>
