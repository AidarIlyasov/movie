<template>
    <div>
        <CustomModal>
            <template #header>
                <div class="search-movie">
                    <input type="text" class="form-control" id="search-movie_lable" placeholder="Use search to find your movie">
                </div>
            </template>
            <template #body>
                <div>
                    <span class="categories-result_lable">or select from category</span>
                    <div class="categories-result" v-show="serachResult.length < 1">
                        <ul class="categories-list">
                            <li v-for="category in categories" :key="category.id" @click="showCategoryMovies(category.id)">{{category.name}} <i class="fa fa-caret-right"></i></li>
                        </ul>
                        <div class="movies-list">
                            <div class="movie-item" v-for="(item, index) in categoryMovies" :key="index" @click="chooseItem(item.id)">
                                <img class="movie-item_pic" :src="img">
                                <div class="movie-item_name">{{item.title}}</div>
                            </div>
                        </div>
                    </div>
                    <div class="search-result movies-list" v-show="serachResult.length > 0">
                        <div class="movie-item" v-for="(item, index) in serachResult" :key="index" @click="chooseItem(item.id)">
                            <img class="movie-item_pic" :src="item.img">
                            <div class="movie-item_name">{{item.name}}</div>
                        </div>
                    </div>
                </div>
            </template>
        </CustomModal>
    </div>
</template>
<script>
import axios from 'axios'
import CustomModal from '../CustomModal.vue'
import Alert from '../Alert.vue'

export default {
    name: "ChooseMoveModal",
    data() {
        return {
            categories: [],
            categoryMovies: [],
            img: 'https://d1csarkz8obe9u.cloudfront.net/posterpreviews/adventure-movie-poster-template-design-7b13ea2ab6f64c1ec9e1bb473f345547_screen.jpg?ts=1636999411',
            serachResult: [
                // {
                //     id: 1,
                //     img: 'https://d1csarkz8obe9u.cloudfront.net/posterpreviews/adventure-movie-poster-template-design-7b13ea2ab6f64c1ec9e1bb473f345547_screen.jpg?ts=1636999411',
                //     name: 'Archer'
                // },
            ]
        }
    },
    methods: {
        chooseItem(id) {
            console.log(`drom choose movie modal vue  ${id}`);
            this.emitter.emit('chooseMovie', id);
        },
        showCategoryMovies(catId) {
            axios.get(`/dashboard/categories/${catId}/movies`)
                .then(r => this.categoryMovies = r.data)
        }
    },
    created() {
        axios.get('/dashboard/categories/')
            .then(r => this.categories = r.data);
    },
    components: {
        CustomModal,
        Alert
    }
}
</script>
<style scoped>
    /* movie modal */
    .search-movie {
        color: #fff;
        display: flex;
        width: 50%;
    }
    .categories-result {
        color: #fff;
        display: flex;
        align-items: flex-start;
    }
    .categories-result_lable {
        border-bottom: 1px solid #8d8888;
        padding-bottom: 2px;
        color: #fff;
    }
    .categories-list {
        padding: 0;
        width: 140px;
        border-right: solid 1px #8d8888;
    }
    .categories-list > li {
        line-height: 2;
        cursor: pointer;
        list-style: none;
    }
    .movies-list {
        display: flex;
        flex-wrap: wrap;
    }
    .movie-item {
        color: #fff;
        display: flex;
        flex-wrap: wrap;
        width: 140px;
        position: relative;
        border-bottom: solid 1px #8d8888;
        margin-right: 4px;
        margin-bottom: 4px;
    }
    .movie-item:nth-child(5n) {
        margin-right: 0;
    }
    .movie-item_name {
        position: absolute;
        bottom: 0;
        width: 100%;
        display: inline-block;
        background: rgba(3,3,3, .7);
    }
    .movie-item_pic {
        max-width: 100%;
        max-height: 100%;
    }
</style>
