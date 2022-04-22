<template>
  <div>
    <Preloader v-show="preloader"></Preloader>
    <CustomList 
        listName="restriction"
        :selectedItem="selectedRestriction"
        :operation="this.operation"
        :tableFields="tableFields"
        @update="updateRestriction($event)"
        @add="insertRestriction($event)"
    >
      <tr v-for="(restriction, index) in restrictions" :key="restriction.id">
        <th scope="row">{{index + 1}}</th>
        <td>{{restriction.name}}</td>
        <td>{{restriction.link}}</td>
        <td>
          <a
            :href="'/movies/filters/restriction=' + restriction.id"
            class="btn btn-sm btn-outline-secondary mr-1"
            title="movies count"
            role="button"
          >
            <span>
              {{restriction.moviesCount}}
              <i class="fa fa-arrow-right"></i>
            </span>
          </a>
        </td>
        <td>
          <button 
              class="btn btn-sm btn-outline-secondary"
              title="edit restriction"
              @click="editRestriction(index)"
          ><i class="fa fa-cog"></i>
          </button>
        </td>
      </tr>
    </CustomList>
    <button class="btn-sm btn-success" @click="addRestriction()">Add restriction</button>
  </div>
</template>

<script>
import axios from "axios";
import validator from "../mixins/validator.js";
import displayErrors from "../mixins/displayErrors.js";
import CustomList from "../components/CustomList.vue";
import Preloader from "../components/Preloader.vue";
import useVuelidate from "@vuelidate/core";

const header = {
  headers: {"Authorization": "Bearer " + localStorage.getItem('user')}
}

export default {
  name: "RestrictionsView.vue",
  mixins: [validator, displayErrors],
  setup: () => ({ v$: useVuelidate() }),
  data() {
    return {
      restrictions: [],
      selectedRestriction: {},
      validateRestriction: {},
      tableFields:[ 
          {name: "name", editable: true, type: "text"},
          {name: "link", editable: true, type: "text"},
          {name: "movies count", editable: false},
      ],
      selectedIndex: 0,
      preloader: true,
      operation: 'Update'
    }
  },
  validations () {
    return this.restrictionValidator();
  },
  methods: {
    editRestriction(index) {
      this.operation = 'Update';
      this.selectedIndex = index;
      this.selectedRestriction = JSON.parse(JSON.stringify(this.restrictions[index]));
      this.emitter.emit('restrictionSettingsModal', true);
    },
    async updateRestriction(updatedData) {
      this.validateRestriction = updatedData;
       if (!await this.validateFields("Restriction")) return;

      axios.put(`/dashboard/restrictions/${this.selectedRestriction.id}/`, updatedData, header)
        .then(r => this.restrictions[this.selectedIndex] = r.data)
        .then(() => this.$notify({
          title: `Restriction ${this.selectedRestriction.name} was updated`,
          type: "success"
        }))
          .catch(e => this.displayErrors(e.response))
    },
    addRestriction() {
      this.selectedRestriction = {};
      this.operation = 'Add';
      this.emitter.emit('restrictionSettingsModal', true);
    },
    async insertRestriction(addedData) {
      this.validateRestriction = addedData;
      if (!await this.validateFields("Restriction")) return;
      
      axios.post(`/dashboard/restrictions/`, addedData, header)
        .then(r => this.restrictions.push(r.data))
        .then(() => this.$notify({
          title: "Restriction was successfully added",
          type: "success"
        }))
        .catch(e => this.displayErrors(e.response));
    }
  },
  created() {
    axios.get('/dashboard/restrictions/', header)
        .then(r => this.restrictions = r.data)
        .catch(e => console.error(e))
        .finally(() => this.preloader = false);
  },
  components: {
    CustomList,
    Preloader
  }
}
</script>

<style scoped>

</style>