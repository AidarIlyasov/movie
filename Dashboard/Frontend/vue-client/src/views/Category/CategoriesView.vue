<template>
  <div>
    <Preloader v-show="preloader"></Preloader>
    <CustomList
        listName="category"
        :selectedItem="selectedCategory"
        :operation="operation"
        :editableFields="editableFields"
        @update="updateCategory()"
        @add="insertCategory()"
    > <tr v-for="(category, index) in categories" :key="category.id">
      <th scope="row">{{index + 1}}</th>
      <td>{{category.name}}</td>
      <td>{{category.link}}</td>
      <td>
        <a
            :href="'/movies/filters/category=' + category.id"
            class="btn btn-sm btn-outline-secondary mr-1"
            title="movies count"
            role="button"
        >
            <span>
              {{category.moviesCount}}
              <i class="fa fa-arrow-right"></i>
            </span>
        </a>
      </td>
      <td>
        <button
            class="btn btn-sm btn-outline-secondary"
            title="edit category"
            @click="editCategory(index)"
        ><i class="fa fa-cog"></i>
        </button>
      </td>
    </tr>
    </CustomList>
    <button class="btn-sm btn-success" @click="addCategory()">Add category</button>
  </div>
</template>

<script>
import axios from 'axios'
import Preloader from "../../components/Preloader.vue";
import CustomList from "../../components/CustomList.vue";
import displayErrors from "../../mixins/displayErrors.js";
import validator from "../../mixins/validator.js";
import useVuelidate from "@vuelidate/core";

export default {
  name: "CategoriesView",
  mixins: [displayErrors, validator],
  setup: () => ({ v$: useVuelidate() }),
  data() {
    return {
      categories: [],
      editableFields:["name", "link"],
      preloader: true,
      selectedIndex: 0,
      operation: 'Update',
      selectedCategory: {}
    }
  },
  validations () {
    return this.categoriesValidator();
  },
  methods: {
    editCategory(index) {
      this.operation = 'Update';
      this.selectedIndex = index;
      this.selectedCategory = this.categories[index];
      this.emitter.emit('categorySettingsModal', true);
    },
    async updateCategory() {
      if (!await this.validateFields("Category")) return;

      axios.put(`/dashboard/categories/${this.selectedCategory.id}/`, this.selectedCategory)
          .then(r => this.categories[this.selectedIndex] = r.data)
          .then(() => this.$notify({
            title: `Category ${this.selectedCategory.name} was updated`,
            type: "success"
          }))
          .catch(e => this.displayErrors(e.response))
    },
    addCategory() {
      this.selectedCategory = {};
      this.operation = 'Add';
      this.emitter.emit('categorySettingsModal', true);
    },
    async insertCategory() {
      if (!await this.validateFields("Category")) return;
      
      axios.post(`/dashboard/categories/`, this.selectedCategory)
          .then(r => this.categories.push(r.data))
          .then(() => this.$notify({
            title: "Category was successfully added",
            type: "success"
          }))
          .catch(e => this.displayErrors(e.response));
    }
  },
  components: {
    Preloader,
    CustomList
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