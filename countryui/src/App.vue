<template>
  <div id="app">
    <h1>Countries</h1>
    
    <!-- Loading State -->
    <p v-if="loading">Loading countries...</p>
    
    <!-- Error State -->
    <p v-if="error">{{ error }}</p>
    
    <!-- Country List -->
    <div v-if="!selectedCountry && !loading && !error" class="country-grid">
      <div v-for="country in countries" :key="country.common" class="country-card">
        <img 
          :src="country.png" 
          :alt="`${country.common} flag`" 
          @click="fetchCountryDetails(country.common)"
          class="flag-image"
        >
        <p>{{ country.common }}</p>
      </div>
    </div>

    <!-- Country Details -->
    <div v-if="selectedCountry" class="details">
      <h2>{{ selectedCountry.name.common }}</h2>
      <img :src="selectedCountry.flags.png" :alt="`${selectedCountry.name.common} flag`">
      <p><strong>Population:</strong> {{ selectedCountry.population.toLocaleString() }}</p>
      <p><strong>Capital:</strong> {{ selectedCountry.capital ? selectedCountry.capital.join(', ') : 'N/A' }}</p>
      <button @click="selectedCountry = null">Back to List</button>
    </div>
  </div>
</template>

<script>
export default {
  name: 'App',
  data() {
    return {
      countries: [],
      selectedCountry: null,
      loading: true,
      error: null,
    };
  },
  async created() {
    await this.fetchCountries();
  },
  methods: {
    async fetchCountries() {
      try {
        this.loading = true;
        const response = await fetch('https://localhost:7033/api/Country', {
          mode: 'cors',
        });
        if (!response.ok) throw new Error(`Failed to fetch countries: ${response.statusText}`);
        this.countries = await response.json();
        console.log('Countries fetched:', this.countries);
      } catch (error) {
        this.error = `Error fetching countries: ${error.message}`;
        console.error(this.error);
      } finally {
        this.loading = false;
      }
    },
    async fetchCountryDetails(countryName) {
      try {
        this.loading = true;
        const response = await fetch(`https://localhost:7033/api/Country/details/${encodeURIComponent(countryName)}`, {
          mode: 'cors',
        });
        if (!response.ok) throw new Error(`Failed to fetch details for ${countryName}: ${response.statusText}`);
        this.selectedCountry = await response.json();
        console.log('Country details fetched:', this.selectedCountry);
      } catch (error) {
        this.error = `Error fetching country details: ${error.message}`;
        console.error(this.error);
      } finally {
        this.loading = false;
      }
    },
  },
};
</script>

<style>
.country-grid {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(200px, 1fr));
  gap: 20px;
  padding: 20px;
}
.country-card {
  text-align: center;
  cursor: pointer;
}
.flag-image {
  max-width: 100%;
  height: auto;
  transition: transform 0.2s;
}
.flag-image:hover {
  transform: scale(1.1);
}
.details {
  padding: 20px;
  text-align: center;
}
button {
  margin-top: 10px;
  padding: 8px 16px;
  background-color: #007bff;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}
button:hover {
  background-color: #0056b3;
}
</style>