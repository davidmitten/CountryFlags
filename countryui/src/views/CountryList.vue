<template>
  <div>
    <h1>Countries</h1>
    <div v-if="loading">Loading...</div>
    <div v-else-if="error" class="error">{{ error }}</div>
    <ul v-else>
      <li v-for="country in countries" :key="country.name.common">
        <img 
          :src="country.flags.png" 
          :alt="country.flags.alt || 'Flag of ' + country.name.common" 
          width="50" 
          @error="handleImageError"
        />
        <span>{{ country.name.common }}</span>
        <small>({{ country.name.official }})</small>
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  data() {
    return {
      countries: [],
      loading: false,
      error: null,
    };
  },
  mounted() {
    this.fetchCountries();
  },
  methods: {
    async fetchCountries() {
      this.loading = true;
      try {
        const response = await fetch('https://localhost:7033/api/country', {
          method: 'GET',
          headers: {
            'Accept': 'application/json',
          },
        });
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const data = await response.json();
        this.countries = data;
      } catch (err) {
        this.error = `Failed to load countries: ${err.message}`;
      } finally {
        this.loading = false;
      }
    },
    handleImageError(event) {
      event.target.src = 'https://via.placeholder.com/50?text=No+Flag'; // Fallback image
    },
  },
};
</script>

<style scoped>
ul {
  list-style: none;
  padding: 0;
}
li {
  display: flex;
  align-items: center;
  margin: 10px 0;
}
img {
  margin-right: 10px;
}
small {
  color: #666;
  margin-left: 5px;
}
.error {
  color: red;
}
</style>