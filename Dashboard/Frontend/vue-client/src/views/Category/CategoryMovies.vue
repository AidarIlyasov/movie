<template>
  <div class="d-flex flex-wrap w-100">
    <Preloader v-show="preloader"></Preloader>
    <MovieItem
        v-for="(movie, index) in movies"
        :key="index"
        :title="movie.title"
        :description="movie.description"
        :categories="movie.categories"
        :appendClass="'change-item'"
    >
      <a :href="'/movies/'+ movie.id +'/edit'" class="btn btn-sm movie_item-btn_action movie_item-btn_edit" role="button">Edit item</a>
      <button class="btn btn-sm movie_item-btn_action movie_item-btn_remove" @click="removeCategoryFromMovie(movie.id, index)">remove category</button>
    </MovieItem>
  </div>
</template>

<script>
import MovieItem from '../../components/Movie/MovieItem.vue'
import Preloader from '../../components/Preloader.vue'
import axios from 'axios'

export default {
  name: "CategoryMovies.vue",
  data() {
    return {
      movies: [],
      preloader: true
    }
  },
  methods: {
    removeCategoryFromMovie(movieId, movieIndex) {
      axios.delete(`/dashboard/movies/${movieId}/categories/${this.$route.params.id}`)
          .then(r => this.movies[movieIndex].categories = r.data)
          .then(() => this.$notify({
              title: `Category was successfully removed`,
              type: "success"
          }))
          .catch(e => console.error(e))
          .finally(() => this.preloader = false)
    }
  },
  components: {
    MovieItem,
    Preloader
  },
  created() {
    axios.get(`/dashboard/categories/${this.$route.params.id}/movies`)
        .then(r => this.movies = r.data)
        .catch(e => console.error(e))
        .finally(() => this.preloader = false)
  }
}
</script>

<style scoped>

</style>