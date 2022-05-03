<template>
	<div>
    <Preloader v-show="preloader"></Preloader>
		<h5 class="mb-2">Home page top</h5>
		<div class="input-group input-group-sm mb-3">
			<div class="input-group-prepend">
				<span class="input-group-text" id="season_items-title">Title</span>
			</div>
			<input type="text" :value="title" class="form-control" aria-describedby="season_items-title">
		</div>
		<div class="input-group input-group-sm mb-3">
			<div class="input-group-prepend">
				<span class="input-group-text" id="season_items-slides">Slide count</span>
			</div>
			<input type="number" min="4" max="8" :value=slideItemsCount class="form-control number-input" aria-describedby="season_items-slides">
			<small class="ml-1 form-text text-muted">min number 4</small>,
			<small class="ml-1 form-text text-muted">max number 8</small>
		</div>
		<div class="d-flex flex-wrap">
			<MovieItem 
				v-for="(movie, index) in movies"
				:key="index" :title="movie.title"
				:description="movie.description"
        :movieId="movie.id"
				:categories="movie.categories"
				:image="movie.image"
				:appendClass="'change-item'"
			><button class="btn btn-sm movie_item-btn_action movie_item-btn_edit" @click="openChooseMovieModal(index)">Choose another movie</button></MovieItem>
			<ChooseMovie></ChooseMovie>
		</div>
	</div>
</template>

<script>
import MovieItem from '../../components/Movie/MovieItem.vue'
import ChooseMovie from '../../components/Movie/ChooseMovie.vue'
import Preloader from "../../components/Preloader.vue";
import axios from 'axios'

const header = {
  headers: {"Authorization": "Bearer " + localStorage.getItem('user')}
}

export default {
	name: 'SeasonMovies',
	data() {
		return {
			title: 'NEW ITEMS OF THIS SEASON',
			slideItemsCount: 6,
			movies: [],
			selectedElement: 0,
      preloader: true,
		}
	},
	methods: {
		openChooseMovieModal(index) {
			this.selectedElement = index;
      this.emitter.emit('chooseMovieModal', true);
		}
	},
	components: {
    Preloader,
		MovieItem,
		ChooseMovie
	},
	created() {
		axios.get('/dashboard/movies/season/', header)
			.then(r => this.movies = r.data)
      .catch(e => console.error(e))
      .finally(() => this.preloader = false);

		this.emitter.on('chooseMovie', (movieId) => {
      axios.get(`/dashboard/movies/${movieId}`, header)
        .then(r => this.movies[this.selectedElement] = r.data);
		});
	}
}
</script>

<style scoped>

</style>