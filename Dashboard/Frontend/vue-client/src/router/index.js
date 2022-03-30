import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import MoviesView from '../views/Movie/MoviesView.vue'
import MovieEditView from '../views/Movie/MovieEditView.vue'
import CatalogView from '../views/CatalogView.vue'
import ActorsView from '../views/ActorsView.vue'
import UsersView from '../views/UsersView.vue'
import PricingPlanView from '../views/PricingPlanView.vue'

import SeasonMovies from '../views/Home/SeasonMovies.vue'

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
      path: '/movies/:id/edit',
      name: 'movie-edit',
      component: MovieEditView
    },
    {
      path: '/catalog',
      name: 'catalog',
      component: CatalogView
    },
    {
      path: '/actors',
      name: 'actors',
      component: ActorsView
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
