import { createRouter, createWebHistory } from 'vue-router';
import CountryList from '../views/CountryList.vue';
import CountryDetails from '../views/CountryDetails.vue';

const routes = [
  {
    path: '/',
    name: 'CountryList',
    component: CountryList,
  },
  {
    path: '/details/:name',
    name: 'CountryDetails',
    component: CountryDetails,
    props: true,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;