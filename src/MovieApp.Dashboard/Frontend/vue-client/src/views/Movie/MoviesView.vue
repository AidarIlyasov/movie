<template>
  <div class="d-flex flex-wrap w-100">
    <Preloader v-show="preloader"></Preloader>
    <MovieItem 
      v-for="(movie, index) in movies"
      :key="index"
      :movieId="movie.id"
      :title="movie.title"
      :image="movie.image"
      :description="movie.description"
      :categories="movie.categories"
      :appendClass="'change-item'"
    >
      <a :href="'/movies/'+ movie.id +'/edit'" class="btn btn-sm movie_item-btn_action movie_item-btn_edit" role="button">Edit item</a>
      <button 
          v-show="this.$route.params"
          class="btn btn-sm movie_item-btn_action movie_item-btn_remove"
          @click="removeItem(movie.id, index)">remove {{this.$route.params.filter}}
      </button>
    </MovieItem>
  </div>
</template>

<script>
  import MovieItem from '../../components/Movie/MovieItem.vue'
  import Preloader from '../../components/Preloader.vue'
  import axios from 'axios'

  const header = {
    headers: {"Authorization": "Bearer " + localStorage.getItem('user')}
  }

  export default {
    name: "MoviesView",
    data() {
        return {
          movies: [],
          preloader: true
        }
    },
    methods: {
      getSeasonMovies() {
        axios.get('/dashboard/movies/season/', header)
            .then(r => this.movies = r.data)
            .catch(e => console.error(e))
            .finally(() => this.preloader = false)
      },
      getFilteredMovies() {
          axios.get(`/dashboard/movies/filters?${this.$route.params.filter}`, header)
            .then(r => this.movies = r.data.movies)
            .catch(e => console.error(e))
            .finally(() => this.preloader = false)
      },
      removeItem(movieId, index) {
        axios.delete(`/dashboard/movies/${movieId}/categories/${this.$route.params.id}`, header)
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
      if (Object.keys(this.$route.params).length !== 0) {
        this.getFilteredMovies()
      } else {
        this.getSeasonMovies();
      }
    }
  }
</script>

<style scoped>
  
</style>