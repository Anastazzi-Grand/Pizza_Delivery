import { createRouter, createWebHistory } from 'vue-router';
import CatalogPage from '@/pages/CatalogPage.vue';
import CartPage from '@/pages/CartPage.vue';
import ProfilePage from '@/pages/ProfilePage.vue';
import OrderPage from '@/pages/OrderPage.vue';
import EmployeesPage from '@/pages/EmployeesPage.vue';
import UsersPage from '@/pages/UsersPage.vue';
import OrdersPage from '@/pages/OrdersPage.vue';
import NotFoundPage from '@/pages/NotFoundPage.vue';

const routes = [
    {
        path: '/',
        name: 'Catalog',
        component: CatalogPage,
        meta: { requiresAuth: false },
    },
    {
        path: '/cart',
        name: 'Cart',
        component: CartPage,
        meta: { requiresAuth: true },
    },
    {
        path: '/profile',
        name: 'Profile',
        component: ProfilePage,
        meta: { requiresAuth: true },
    },
    {
        path: '/order/:id',
        name: 'OrderDetails',
        component: OrderPage,
        meta: { requiresAuth: true },
    },
    {
        path: '/employees',
        name: 'Employees',
        component: EmployeesPage,
        meta: { requiresAuth: true, requiresAdmin: true },
    },
    {
        path: '/users',
        name: 'Users',
        component: UsersPage,
        meta: { requiresAuth: true, requiresAdmin: true },
    },
    {
        path: '/orders',
        name: 'Orders',
        component: OrdersPage,
        meta: { requiresAuth: true, requiresAdmin: true },
    },
    {
        path: '/:pathMatch(.*)*',
        name: 'NotFoundPage',
        component: NotFoundPage,
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

router.beforeEach((to, from, next) => {
    const isAuthenticated = localStorage.getItem('token');
    const requiresAuth = to.matched.some(record => record.meta.requiresAuth);
    const requiresAdmin = to.matched.some(record => record.meta.requiresAdmin);

    if (requiresAuth && !isAuthenticated) {
        next('/');
    } else if (requiresAdmin && isAuthenticated && localStorage.getItem('role') !== 'admin') {
        next('/');
    } else {
        next();
    }
});

export default router;
