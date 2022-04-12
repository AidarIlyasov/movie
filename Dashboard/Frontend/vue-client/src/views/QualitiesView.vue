<template>
  <div>
    <Preloader v-show="preloader"></Preloader>
    <CustomList
        listName="quality"
        :selectedItem="selectedQuality"
        :operation="operation"
        :editableFields="editableFields"
        @update="updateQuality()"
        @add="insertQuality()"
    >
      <tr v-for="(quality, index) in qualities" :key="quality.id">
        <th scope="row">{{index + 1}}</th>
        <td>{{quality.name}}</td>
        <td>
          <a
              :href="'/movies/filters/quality=' + quality.id"
              class="btn btn-sm btn-outline-secondary mr-1"
              title="movies count"
              role="button"
          >
            <span>
              {{quality.moviesCount}}
              <i class="fa fa-arrow-right"></i>
            </span>
          </a>
        </td>
        <td>
          <button
              class="btn btn-sm btn-outline-secondary"
              title="edit quality"
              @click="editQuality(index)"
          ><i class="fa fa-cog"></i>
          </button>
        </td>
      </tr>
    </CustomList>
    <button class="btn-sm btn-success" @click="addQuality()">Add quality</button>
  </div>
</template>

<script>
import axios from "axios";
import validator from "../mixins/validator.js";
import displayErrors from "../mixins/displayErrors.js";
import CustomList from "../components/CustomList.vue";
import Preloader from "../components/Preloader.vue";
import useVuelidate from "@vuelidate/core";

export default {
  name: "QualitiesView.vue",
  mixins: [validator, displayErrors],
  setup: () => ({ v$: useVuelidate() }),
  data() {
    return {
      qualities: [],
      selectedQuality: {},
      editableFields:["name"],
      selectedIndex: 0,
      preloader: true,
      operation: 'Update'
    }
  },
  validations () {
    return this.qualityValidator();
  },
  methods: {
    editQuality(index) {
      this.operation = 'Update';
      this.selectedIndex = index;
      this.selectedQuality = this.qualities[index];
      this.emitter.emit('qualitySettingsModal', true);
    },
    async updateQuality() {
      if (!await this.validateFields("Quality")) return;

      axios.put(`/dashboard/qualities/${this.selectedQuality.id}/`, this.selectedQuality)
          .then(r => this.qualities[this.selectedIndex] = r.data)
          .then(() => this.$notify({
            title: `Quality ${this.selectedQuality.name} was updated`,
            type: "success"
          }))
          .catch(e => this.displayErrors(e.response))
    },
    addQuality() {
      this.selectedQuality = {};
      this.operation = 'Add';
      this.emitter.emit('qualitySettingsModal', true);
    },
    async insertQuality() {
      if (!await this.validateFields("Quality")) return;

      axios.post(`/dashboard/qualities/`, this.selectedQuality)
          .then(r => this.qualities.push(r.data))
          .then(() => this.$notify({
            title: "Quality was successfully added",
            type: "success"
          }))
          .catch(e => this.displayErrors(e.response));
    }
  },
  created() {
    axios.get('/dashboard/qualities/')
        .then(r => this.qualities = r.data)
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