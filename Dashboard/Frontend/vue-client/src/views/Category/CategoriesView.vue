<template>
  <div>
    <Preloader v-show="preloader"></Preloader>
    <ul class="list-group">
      <li class="list-group-item d-flex justify-content-end align-items-center" v-for="(category, index) in categories" :key="category.id">
        <span class="cat-title mr-auto">{{category.name}}</span>
        <a 
            :href="'/categories/' + category.id"
            class="btn btn-sm btn-outline-secondary mr-1"
            title="movies count"
            role="button"
          ><i class="fa fa-film"></i> {{category.moviesCount}}
        </a>
        <button class="btn btn-sm btn-outline-secondary" title="edit category" @click="editCategory(index)"><i class="fa fa-cog"></i></button>
      </li>
    </ul>
    <CustomModal v-show="modalOpen" name="categorySettingsModal">
      <template #header>Edit category</template>
      <template #body>
        <div class="form-group">
          <label for="category-name">Category name</label>
          <input type="text" class="form-control form-control-sm" id="category-name" v-model="selectedCategory.name">
        </div>
        <div class="form-group">
          <label for="category-link">Category link</label>
          <input type="text" class="form-control form-control-sm" id="category-link" v-model="selectedCategory.link">
        </div>
        <button class="btn-sm btn-success" @click="saveCategory()">Save</button>
      </template>
    </CustomModal>
  </div>
</template>

<script>
import axios from 'axios'
import Preloader from "../../components/Preloader.vue";
import CustomModal from "../../components/CustomModal.vue";

export default {
  name: "CategoriesView",
  data() {
    return {
      categories: [],
      preloader: true,
      modalOpen: false,
      selectedCategory: {}
    }
  },
  methods: {
    editCategory(catIndex) {
      this.modalOpen = true;
      this.selectedCategory = this.categories[catIndex];
    },
    saveCategory() {
      axios.put(`/dashboard/categories/${this.selectedCategory.id}/`, this.selectedCategory)
      .then(r => this.$notify({
          title: `Category ${r.data.name} was updated`,
          type: "success"
        }))
      .catch(e => console.error(e));
    }
  },
  components: {
    Preloader,
    CustomModal
  },
  created() {
    axios.get('/dashboard/categories/')
      .then(r => this.categories = r.data)
      .catch(e => console.error(e))
      .finally(() => this.preloader = false);

    this.emitter.on('categorySettingsModal', (e) => {
      this.modalOpen = e;
    })
  }
}
</script>

<style scoped>
  label[for^='category-'] {
    color: #ffffff;
  }
</style>