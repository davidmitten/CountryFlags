<template>
  <div class="container">
    <h1>Countries</h1>
    <div class="row">
      <div v-for="country in countries" :key="country.name.common" class="col-md-4 mb-3">
        <div class="card">
          <router-link :to="{ name: 'CountryDetails', params: { name: country.name.common } }">
            <img :src="country.flags.png" class="card-img-top" :alt="`${country.name.common} flag`" />
          </router-link>
          <div class="card-body">
            <h5 class="card-title">{{ country.name.common }}</h5>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'CountryList',
  data() {
    return {
      countries: [],
    };
  },
  mounted() {
    this.fetchCountries();
  },
  methods: {
    async fetchCountries() {
      try {
        const response = await axios.get('http://localhost:5000/api/country/flags');
        this.countries = response.data;
      } catch (error) {
        console.error('Error fetching countries:', error);
      }
    },
  },
};
</script>

<style scoped>
.card {
  transition: transform 0.2s;
}
.card:hover {
  transform: scale(1.05);
}
.card-img-top {
  height: 200px;
  object-fit: cover;
}
</style>