<template>
  <div>
    <ul class="list-group">
      <li class="list-group-item d-flex justify-content-end align-items-center" v-for="category in categories" :key="category.id">
        <span class="cat-title mr-auto">{{category.name}}</span>
        <i class="fa fa-cog"></i>
        <span class="badge badge-primary badge-pill">{{category.count}}</span>
      </li>
    </ul>
  </div>
</template>

<script>
import axios from 'axios'


export default {
  name: "CatalogView",
  data() {
    return {
      categories: []
    }
  },
  methods: {
  },
  created() {
    axios.get('/dashboard/categories/')
        .then(r => this.categories = r.data);
  }
}
</script>

<style scoped>

</style>