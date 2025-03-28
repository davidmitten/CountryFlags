<template>
  <div class="container mt-5">
    <h1>{{ country?.name?.common }} Details</h1>
    <div v-if="country" class="card" style="max-width: 18rem; margin: auto;">
      <img :src="country.flags.png" class="card-img-top" :alt="`${country.name.common} flag`" />
      <div class="card-body">
        <h5 class="card-title">{{ country.name.common }}</h5>
        <p class="card-text">
          <strong>Population:</strong> {{ country.population.toLocaleString() }}<br />
          <strong>Capital:</strong> {{ country.capital?.join(', ') || 'N/A' }}
        </p>
        <router-link to="/" class="btn btn-primary">Back to List</router-link>
      </div>
    </div>
    <div v-else>Loading...</div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'CountryDetails',
  props: ['name'],
  data() {
    return {
      country: null,
    };
  },
  mounted() {
    this.fetchCountryDetails();
  },
  watch: {
    name() {
      this.fetchCountryDetails();
    },
  },
  methods: {
    async fetchCountryDetails() {
      try {
        const response = await axios.get('http://localhost:5000/api/country/details');
        this.country = response.data.find(c => c.name.common === this.name);
      } catch (error) {
        console.error('Error fetching country details:', error);
      }
    },
  },
};
</script>

<style scoped>
.card-img-top {
  height: 200px;
  object-fit: cover;
}
</style>