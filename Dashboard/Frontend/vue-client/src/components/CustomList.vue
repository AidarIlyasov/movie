<template>
  <div class="table-responsive-sm">
    <table class="custom-list_table table table-bordered table-hover">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col" class="field-name" v-for="field in tableFields">{{ field.name }}</th>
          <th scope="col">Options</th>
        </tr>
      </thead>
      <tbody>
        <slot></slot>
      </tbody>
    </table>
    <CustomModal v-show="modalOpen" :name="listName + 'SettingsModal'">
      <template #header>{{operation}} {{listName}}</template>
      <template #body>
        <div class="form-group" v-for="field in editableFields">
          <label :for="'item-' + field.name">{{listName}} {{ field.name }}</label>
          <select 
              v-if="field.type === 'select'"
              :name="field.name"
              :id="'item-' + field.name"
              v-model="selectedItem[`${field.name}Id`]"
              @select="selectOption($event)"
              class="custom-select custom-select-sm"
          >
            <option
                v-for="option in field.options"
                :value="option.id"
            >
              {{option.name}}
            </option>
          </select>
          <input v-else 
                 :type="field.type" 
                 class="form-control form-control-sm" 
                 :id="'item-' + field.name" 
                 v-model="selectedItem[field.name]"
                 autocomplete="off"
          >
        </div>
        <button class="btn-sm btn-success" @click="saveChanges()">Save</button>
      </template>
    </CustomModal>
  </div>
</template>


<script>
import CustomModal from "./CustomModal.vue";

export default {
  name: "CustomList.vue",
  props: {
    tableFields: {type: Array},
    listName: { type: String },
    selectedItem: {},
    operation:  { type: String, default: 'Edit' }
  },
  data() {
    return {
      modalOpen: false
    }
  },
  methods: {
    saveChanges() {
      this.$emit(this.operation.toLowerCase(), this.selectedItem)
    }
  },
  created() {
    this.emitter.on(this.listName + 'SettingsModal', (e) => {
      this.modalOpen = e;
    })
  },
  computed: {
    editableFields() {
      return this.tableFields.filter(field => field.editable);
    }
  },
  components: {
    CustomModal
  }
}
</script>

<style scoped>
  label[for^='item-'] {
    color: #ffffff;
  }
  
  .custom-list_table {
    background-color: #ffffff;
  }
  
  .field-name:first-letter {
    text-transform: uppercase;
  }
</style>