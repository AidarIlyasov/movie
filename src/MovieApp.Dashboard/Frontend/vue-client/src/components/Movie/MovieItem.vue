﻿<template>
  <div :class="'col-4 movie-item mb-2 ' + appendClass">
    <slot></slot>
    <div class="movie-card card">
      
        <div class="movie-card_image">
          <div class="movie-card_photo" :style="'background: url(/image/'+movieId+'/'+image+'.jpg) center / cover'"></div>
        </div>
        <div class="card-body">
          <a href="/dashboard/movie/{1}"><h5 class="card-title">{{title}}</h5></a>
          <p class="card-text">{{description}}</p>
          <hr>
          <div class="movie-actors_list d-flex flex-wrap">
            <a :href="'/categories/' + category.link" class="move-cat_list-name" v-for="category in categories" :key="category.id">{{ category.name }}</a>
          </div>
        </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "MovieItem",
  props: {
    movieId: {type: Number, default: 2},
    title: {type: String},
    description: {type: String},
    categories: {type: Array},
    image: {type: String},
    appendClass: {type: String, default: ""}
  }
}
</script>

<style scoped>
  .movie-item {
    position: relative;
    padding: 0;
  }
  .movie-item:nth-child(3) {
    margin-left: 0;
  }
  /*.movie-item:not(:nth-child(3)) {*/
  /*  padding-left: 0;*/
  /*}*/
  .move-cat_list-name:not(:last-child)::after {
    content: ',';
    margin-right: 5px;
  }
  .card-title {
    min-height: 45px;
  }
  .card-text {
    text-overflow: ellipsis;
    overflow: hidden;
    -webkit-box-orient: vertical;
    display: -webkit-box;
    -webkit-line-clamp: 4;
  }
  .change-item:hover::after {
    display: block;
  }
  .change-item::after {
    content: '';
    display: none;
    z-index: 1;
    position: absolute;
    left: 0;
    top: 227px;
    width: 100%;
    height: 50px;
    background: rgba(3, 3, 3, .8);
  }
  .movie-card_image, .movie-card_photo {
    min-height: 250px;
  }
  .movie-card_photo:hover {
    transition: .3s;
    min-height: 450px;
    position: absolute;
    z-index: 5;
    width: 100%;
  }
</style>