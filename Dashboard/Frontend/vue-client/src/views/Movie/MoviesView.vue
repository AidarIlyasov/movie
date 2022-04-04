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
    ><a :href="'/movies/'+ movie.id +'/edit'" class="btn btn-sm movie_item-btn_action movie_item-btn_edit" role="button">Edit item</a></MovieItem>
  </div>
</template>

<script>
  import MovieItem from '../../components/Movie/MovieItem.vue'
  import Preloader from '../../components/Preloader.vue'
  import axios from 'axios'
  
  export default {
    name: "MoviesView",
    data() {
        return {
          movies: [],
          preloader: true
        }
    },
    components: {
      MovieItem,
      Preloader
    },
    created() {
      axios.get('/dashboard/movies/season/')
			  .then(r => this.movies = r.data)
        .catch(e => console.error(e))
        .finally(() => this.preloader = false)
    }
  }
</script>

<style scoped>
  
</style>