import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import MoviesView from '../views/Movie/MoviesView.vue'
import MovieEditView from '../views/Movie/MovieEditView.vue'
import CategoriesView from '../views/Category/CategoriesView.vue'
import ActorsView from '../views/ActorsView.vue'
import UsersView from '../views/UsersView.vue'
import PricingPlanView from '../views/PricingPlanView.vue'
import RestrictionsView from "../views/RestrictionsView.vue";
import CountriesView from "../views/CountriesView.vue";

import SeasonMovies from '../views/Home/SeasonMovies.vue'
import QualitiesView from "../views/QualitiesView.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/home/season-items',
      name: '/season',
      component: SeasonMovies
    },
    {
      path: '/movies',
      name: 'movies',
      component: MoviesView
    },
    {
      path: '/movies/filters/:filter',
      name: 'movies-filtered',
      component: MoviesView
    },
    {
      path: '/movies/:id/edit',
      name: 'movie-edit',
      component: MovieEditView
    },
    {
      path: '/categories',
      name: 'categories',
      component: CategoriesView
    },
    {
      path: '/actors',
      name: 'actors',
      component: ActorsView
    },
    {
      path: '/countries/',
      name: 'countries',
      component: CountriesView
    },
    {
      path: '/restrictions/',
      name: 'restrictions',
      component: RestrictionsView
    },
    {
      path: '/qualities/',
      name: 'qualities',
      component: QualitiesView
    },
    {
      path: '/users',
      name: 'users',
      component: UsersView
    },
    {
      path: '/pricing',
      name: 'pricing',
      component: PricingPlanView
    },
  ]
})

export default router
