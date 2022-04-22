<template>
  <div>
    <Preloader v-show="preloader"></Preloader>
    <CustomList
        listName="country"
        :selectedItem="selectedCountry"
        :operation="operation"
        :tableFields="tableFields"
        @update="updateCountry($event)"
        @add="insertCountry($event)"
    >
      <tr v-for="(country, index) in countries" :key="country.id">
        <th scope="row">{{index + 1}}</th>
        <td>{{country.name}}</td>
        <td>{{country.link}}</td>
        <td>{{country.code}}</td>
        <td>
          <a
              :href="'/movies/filters/country=' + country.id"
              class="btn btn-sm btn-outline-secondary mr-1"
              title="movies count"
              role="button"
          >
            <span>
              {{country.moviesCount}}
              <i class="fa fa-arrow-right"></i>
            </span>
          </a>
        </td>
        <td>
          <button
              class="btn btn-sm btn-outline-secondary"
              title="edit country"
              @click="editCountry(index)"
          ><i class="fa fa-cog"></i>
          </button>
        </td>
      </tr>
    </CustomList>
    <button class="btn-sm btn-success" @click="addCountry()">Add country</button>
  </div>
</template>

<script>
import axios from "axios";
import validator from "../mixins/validator.js";
import displayErrors from "../mixins/displayErrors.js";
import CustomList from "../components/CustomList.vue";
import Preloader from "../components/Preloader.vue";
import useVuelidate from "@vuelidate/core";

const selectedCountry = {
    name: "",
    link: "",
    code: ""
};

const header = {
  headers: {"Authorization": "Bearer " + localStorage.getItem('user')}
}

export default {
  name: "CountriesView.vue",
  mixins: [validator, displayErrors],
  setup: () => ({ v$: useVuelidate() }),
  data() {
    return {
      countries: [],
      tableFields:[
        {name: "name", type: "text", editable: true},
        {name: "link", editable: true, type: "text"},
        {name: "code", editable: true, type: "text"},
        {name: "movie count", editable: false}  
      ],
      selectedCountry: selectedCountry,
      validateCountry: {},
      selectedIndex: 0,
      preloader: true,
      operation: 'Update'
    }
  },
  validations () {
    return this.countryValidator();
  },
  methods: {
    editCountry(index) {
      this.operation = 'Update';
      this.selectedIndex = index;
      this.selectedCountry = JSON.parse(JSON.stringify(this.countries[index]));
      this.emitter.emit('countrySettingsModal', true);
    },
    async updateCountry(updatedData) {
      this.validateCountry = updatedData;
      if (!await this.validateFields("Country")) return;

      axios.put(`/dashboard/countries/${this.selectedCountry.id}/`, updatedData, header)
          .then(r => this.countries[this.selectedIndex] = r.data)
          .then(() => this.$notify({
            title: `Country ${this.selectedCountry.name} was updated`,
            type: "success"
          }))
          .catch(e => this.displayErrors(e.response))
    },
    addCountry() {
      this.selectedCountry = selectedCountry;
      this.operation = 'Add';
      this.emitter.emit('countrySettingsModal', true);
    },
    async insertCountry(addedData) {
      this.validateCountry = addedData;
      if (!await this.validateFields("Country")) return;

      axios.post(`/dashboard/countries/`, addedData, header)
          .then(r => this.countries.push(r.data))
          .then(() => this.$notify({
            title: "Country was successfully added",
            type: "success"
          }))
          .catch(e => this.displayErrors(e.response));
    }
  },
  created() {
    axios.get('/dashboard/countries/', header)
      .then(r => this.countries = r.data)
      .catch(e => this.displayErrors(e.response))
      .finally(() => this.preloader = false);

    axios.get('/dashboard/home/name', header)
    .then(r => console.log(r.data))
  },
  components: {
    CustomList,
    Preloader
  }
}
</script>

<style scoped>

</style>