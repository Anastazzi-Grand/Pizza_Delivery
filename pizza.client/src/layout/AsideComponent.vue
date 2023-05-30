<template>
  <ul class="nav flex-column">
    <li class="nav-item">
      <router-link to="/" class="nav-link"  aria-current="page">Каталог</router-link>
    </li>
    <li class="nav-item">
      <router-link to="/cart" class="nav-link">Корзина</router-link>
    </li>
    <li class="nav-item">
      <router-link to="/orders" class="nav-link">Заказы</router-link>
    </li>
  </ul>
</template>
<script>
export default {
    
}
</script>
<style>
    .nav-link.router-link-active {
      font-weight: bold;
    }
</style>
