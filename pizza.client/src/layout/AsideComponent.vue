<template>
  <ul class="nav flex-column">
    <li class="nav-item">
      <router-link to="/" class="navbar-brand mb-0 h2"  aria-current="page">
        <span class="d-block" style="font-size: 24px; margin-bottom: 20px;">Каталог</span>
      </router-link>
    </li>
    <li class="nav-item">
      <router-link to="/cart" class="navbar-brand mb-0 h2">
        <span class="d-block" style="font-size: 24px; margin-bottom: 20px;">Корзина</span>
      </router-link>
    </li>
    <li class="nav-item">
      <router-link to="/orders" class="navbar-brand mb-0 h2">
        <span class="d-block" style="font-size: 24px; margin-bottom: 20px;">Заказы</span>
      </router-link>
    </li>
  </ul>
</template>
<script>
export default {
    
}
</script>
<style>
    .nav-link.router-link-active {
      color: #7676fc;
    }
</style>
