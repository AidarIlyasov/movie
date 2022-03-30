<template>
  <div>
    <Preloader v-show="preloader"></Preloader>
    <h5 class="mb-2">Movie edit page</h5>
    <div class="form-group">
      <span for="movie-title">Title</span>
      <input type="text" class="form-control" id="movie-title" v-model="movie.title">
    </div>
    <div class="form-group">
      <span for="movie-link">Link</span>
      <input type="text" class="form-control" id="movie-link" v-model="movie.slug">
    </div>
    <div class="form-group mb-3">
      <span for="movie-description">Description</span>
      <textarea type="text" class="form-control" id="movie-description" v-model="movie.description"></textarea>
    </div>
    <div class="form-group mb-3">
      <span for="movie-categories">Categories</span>
      <div class="categories-list">
        <div class="btn btn-tiny category-item" v-for="(category, index) in movie.categories" :key="category.id">{{category.name}}
          <i class="fa fa-close" @click="removeCategory(index, category.id)"></i>
        </div>
        <div class="btn btn-tiny btn-outline-primary category-item_add" @click="openCategoriesModal()"><i class="fa fa-plus"></i>add category</div>
      </div>
      <CustomModal :name="'categoriesModal'" v-show="categoriesModal">
        <template #header>Add a new category</template>
        <template #body>
          <ul class="modal_cat-list">
            <li class="modal_cat-item" v-for="(category, index) in availableCategories" :key="category.id" @click="addCategory(index)">
              <button type="button" class="btn btn-sm btn-secondary" :disabled="category.disabled">{{category.name}}</button>
            </li>
          </ul>
        </template>
      </CustomModal>
    </div>
    <div class="d-flex flex-wrap">
      <div class="form-group mb-3 mr-5">
        <span for="movie-qualities">Qualities</span>
          <hr>
          <div class="custom-control custom-checkbox" v-for="quality in qualities" :key="quality.id">
            <input 
              type="checkbox"
              class="custom-control-input"
              @change="selectQuality(quality, $event)"
              :checked="movie.qualities.find(q => q.id === quality.id)"
              :id="'quality-' + quality.name"
              :name="'quality-' + quality.name"
              
            >
            <label class="custom-control-label" :for="'quality-' + quality.name">{{quality.name}}</label>
          </div>
      </div>
      <div class="form-group mb-3 mr-5">
        <span>Restriction</span>
        <hr>
        <div class="custom-control custom-radio" v-for="restriction in restrictions" :key="restriction.id">
          <input 
            type="radio"
            :value="restriction.id"
            class="custom-control-input"
            :id="'restriction' + restriction.id"
            name="movie-restriction"
            :checked="movie.restriction.id === restriction.id"
            @change="selectRestriction(restriction)"
          >
          <label class="custom-control-label" :for="'restriction' + restriction.id">{{restriction.name}}+</label>
        </div>
      </div>
      <div class="form-group mb-3 mr-3 movie-duration">
        <div class="form-group">
          <span class="form-label">Duration</span>
          <hr>
          <input type="number" v-model="movie.duration" min="0" class="form-control form-control-sm" id="movie-duration">
          <span class="duration-measure">time in seconds</span>
        </div>
      </div>
      <div class="form-group movie-release mr-3">
        <label for="inputDate">Release:</label>
        <input type="date" v-model="movie.release" class="form-control form-control-sm">
      </div>
      <div class="form-group">
        <span>Countries</span>
        <hr>
        <div class="countries-list">
          <div class="btn btn-tiny country-item mb-1" v-for="(country, index) in movie.countries" :key="index">{{country.name}}
            <i class="fa fa-close" @click="removeCountry(index, country.id)"></i>
          </div>
          <div class="btn btn-tiny btn-outline-primary country-item_add mb-1" @click="openCountriesModal()"><i class="fa fa-plus"></i>add country</div>
        </div>
        <CustomModal :name="'countriesModal'" v-show="countriesModal">
          <template #header>Add a new country</template>
          <template #body>
            <ul class="modal_countries">
              <li class="modal_country-item" v-for="(country, index) in availableCountries" :key="country.id" @click="addCountry(index)">
                <button class="btn btn-sm btn-secondary" :disabled="country.disabled">{{country.name}}</button>
              </li>
            </ul>
          </template>
        </CustomModal>
      </div>
    </div>
    <div class="form-group">
      <span>Movie photos</span>
      <hr>
      <div class="movie-photos d-flex flex-wrap">
        <div class="movie-phtos_item" v-for="(photo, index) in movie.photos" :key="photo.id">
          <div class="photo-item_pic">
            <button 
              class="btn btn-sm btn-danger movie-photo_remove" 
              @click="removePhoto(index)"
              title="remove image"
            >
              <i class="fa fa-close"></i>
            </button>
            <img :src="'/image/' + photo.name">
          </div>
          <div class="form-group form-radio">
            <input type="radio" class="form-check-input photo-item_status-input" @change="setAsPoster($event)" :value="index" :id="'photo-' + photo.id" name="moviePoser">
            <label class="photo-item_status form-check-label" :for="'photo-' + photo.id"><span class="btn btn-tiny">set as a poster</span> <b>{{photo.isPoster}}</b></label>
          </div>  
        </div>
        <label for="add-photo" class="movie-phtos_item movie-photo_add">
          <div class="text-center">
            <span class="movie-photo_add-btn"><i class="fa fa-folder-o"></i>Add image</span>
            <input id="add-photo" type="file" accept="image/jpeg, image/jpg, image/png" @change="onUploadFile">
            <hr>
            <div class="w-100">max size: 1 mb</div>
            <div class="photo-types">types: jpeg, jpg, png</div>
          </div>
        </label>
      </div>
    </div>
    <button class="btn btn-tiny btn-outline-success" @click="saveChanges()">Save</button>
  </div>
</template>

<script>
import axios from 'axios'
import CustomModal from '../../components/CustomModal.vue'
import Preloader from '../../components/Preloader.vue'

export default {
  name: "MovieEditView.vue",
  data() {
    return {
      movie: {},
      info: null,
      availableCategories: [],
      availableCountries: [],
      qualities: [],
      restrictions: [],
      categoriesModal: false,
      countriesModal: false,
      preloader: true,
      lastUploadImage: '',
      availablePhotoTypes: ['image/jpeg', 'image/jpg', 'image/png'],
      maxImageSize: 100000
    }
  },
  methods: {
    openCategoriesModal() {
      this.categoriesModal = true;
      this.getCategories();
    },
    openCountriesModal() {
      this.countriesModal = true;
      this.getCountries();
    },
    addCategory(index) {
      this.availableCategories[index].disabled = true;
      this.movie.categories.push(this.availableCategories[index]);
    },
    addCountry(index) {
      this.availableCountries[index].disabled = true;
      this.getCountries();
      this.movie.countries.push(this.availableCountries[index]);
    },
    removeCountry(index, countryId) {
      this.movie.countries.splice(index, 1);
      this.getCountries()
        .then(() => this.availableCountries.find(c => c.id === countryId).disabled = false);
    },
    removeCategory(index, catId) {
      this.movie.categories.splice(index, 1);
      this.getCategories()
        .then(() => this.availableCategories.find(c => c.id === catId).disabled = false);
    },
    selectRestriction(value) {
      this.movie.restriction = value;
    },
    selectQuality(value, event) {
      let qualityExists = this.movie.qualities.findIndex(e => e.id === value.id);

      // removie quality form movie.qualities array if it exists and target checked = false
      if (qualityExists !== -1 && !event.target.checked) {
        this.movie.qualities.splice(qualityExists, 1);
      }
      // append quality to movie.qualities
      if (event.target.checked) {
        this.movie.qualities.push(value);
      } 
    },
    onUploadFile(event) {

      if (event.target.files.length < 1) return;

      let image = event.target.files[0];
      let reader = new FileReader();
      reader.onload = e => this.movie.lastUploadImage = e.target.result;

      if (this.availablePhotoTypes.filter(type => type === image.type).length < 1) {
        alert('acceptable image types ' + this.availablePhotoTypes.join(', '));
        return;
      }

      if (image.size > this.maxImageSize) {
        alert('max image size should be less than ' + this.maxImageSize);
        return;
      }

      reader.readAsDataURL(image);

      this.movie.photos.push({
        id: 2,
        image: image,
        isPoster: false  
      })
      this.movie.raiting = '9,6';
    },
    setAsPoster(event) {
      let index = event.target.value;
      this.movie.photos.forEach(p => p.isPoster = false);
      this.movie.photos[index].isPoster = true;
    },
    removePhoto(index) {
      this.movie.photos.splice(index, 1);
    },
    saveChanges() {
      let formData = new FormData();
      
      for(let key in this.movie) {

        if (Array.isArray(this.movie[key])) {
          this.movie[key].forEach((obj, index) => {
            for(let innerKey in obj) {
              formData.append(`${key}[${index}].${innerKey}`, obj[innerKey]);
            }
          })

          continue;
        }

        if (typeof this.movie[key] === 'object') {
          for (let innerKey in this.movie[key]) {
            formData.append(`${key}.${innerKey}`, this.movie[key][innerKey]);
          }

          continue;
        }

        formData.append(key, this.movie[key]);
      }

      axios.post(`/dashboard/movies/${this.$route.params.id}`, formData, {
        headers: {
          'content-type': `multipart/form-data; boundary=${formData._boundary}`
          }
        })
        .then(r => console.log(r))
        .catch(e => console.error(e));
    },
    async getCountries() {
      if (this.availableCountries.length > 0) return;


      // slit to mixin
      await axios.get(`/dashboard/countries/`)
        .then(r => r.data)
        .then(countries => countries.map(c => {
          if (this.movie.countries.find(mv => mv.id === c.id) !== undefined) {
            c.disabled = true;
          }
          return c;
        }))
        .then(data => this.availableCountries = data)
        .catch(e => console.error(e));
    },
    async getCategories() {
      if (this.availableCategories.length > 0) return;

      await axios.get(`/dashboard/categories/`)
        .then(r => r.data)
        .then(catList => catList.map(c => {
          if (this.movie.categories.find(g => g.id === c.id) !== undefined) {
            c.disabled = true;
          }
          return c;
        }))
        .then(data => this.availableCategories = data)
        .catch(e => console.error(e));
    }
  },
  computed() {

  },
  async created() {
    axios.get(`/dashboard/qualities`)
      .then(r => this.qualities = r.data)
      .catch(e => console.error(e));

    axios.get(`/dashboard/restrictions/`)
      .then(r => this.restrictions = r.data)
      .catch(e => console.error(e));

    let movie = await axios.get(`/dashboard/movies/${this.$route.params.id}/edit`)
      .then(r => this.movie = r.data)
      .catch(e => console.error(e))
      .finally(() => this.preloader = false)


    // modal status listeners
    this.emitter.on('categoriesModal', (e) => {
      this.categoriesModal = e;
    });

    this.emitter.on('countriesModal', (e) => {
      this.countriesModal = e;
    });
  },
  components: {
    CustomModal,
    Preloader
  }
}
</script>

<style scoped>
  hr {
    margin-top: 0.2rem;
    margin-bottom: 0.2rem;
  }
  #movie-description {
    min-height: 150px;
  }
  .category-item, .country-item {
    border: solid 1px;
    margin-right: 5px;
  }
  .category-item i, .country-item i {
    margin-left: 5px;
  }
  .category-item i:hover, .country-item i:hover {
    color: tomato;
    cursor: pointer;
  }
  .category-item_add, .country-item_add {
    cursor: pointer;
  }
  .category-item_add i, .country-item_add i {
    margin-right: 5px;
  }
  .modal_cat-list, .modal_countries {
    padding-left: 20px;
    display: flex;
    cursor: pointer;
    flex-wrap: wrap;
  }
  .countries-list {
    max-width: 300px;
  }
  .modal_cat-item, .modal_country-item {
    list-style: none;
    color: #fff;
    margin-right: 5px;
    margin-bottom: 5px;
  }

  .movie-phtos_item {
    width: 150px;
  }
  .movie-phtos_item:not(:nth-child(5n)) {
    margin-right: calc((100% - 150px * 5) / 4);
  }
  .photo-item_pic {
    position: relative;
  }
  .photo-item_pic img {
    max-width: 100%;
    max-height: 100%;
  }
  .movie-photo_add {
    height: 225px;
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    align-items: center;
    border: dashed 1px rgb(75, 115, 200);
    cursor: pointer;
  }
  
  #add-photo, .photo-item_status-input {
    display: none;
  }
  .movie-photo_add:hover {
    border: solid 1px #333;
  }
  .photo-types, .photo-item_status, .duration-measure {
    font-size: 14px;
  }
  .form-check-label {
    display: flex;
    align-items: center;
  }
  .form-check-label > span {
    border: 1px #333 solid;
    margin: 2px 4px 2px 0;
    cursor: pointer;
  }
  .movie-photo_add-btn {
    font-size: 26px;
    text-align: center;
    justify-content: center;
    color: rgb(75, 115, 200);
  }
  .movie-photo_add-btn > i {
    margin-right: 5px;
  }
  .movie-photo_remove {
    position: absolute;
    right: 0;
    top: 0;
  }
  .movie-duration {
    width: 100px;
  }
  .movie-release {
    width: 140px;
  }
</style>