<template>
  <div class="table-responsive-sm">
    <table class="custom-list_table table table-bordered table-hover">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col" class="field-name" v-for="field in editableFields">{{ field }}</th>
          <th scope="col" style="width: 20%">Movies count</th>
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
          <label for="item-name">{{listName}} {{ field }}</label>
          <input type="text" class="form-control form-control-sm" id="item-name" v-model="selectedItem[field]">
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
    editableFields: {type: Array},
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
      this.$emit(this.operation.toLowerCase())
    }
  },
  created() {
    this.emitter.on(this.listName + 'SettingsModal', (e) => {
      this.modalOpen = e;
    })
  },
  computed: {
    // getName: {
    //   get() {
    //     return this.selectedItem.name?.trim();
    //   },
    //   set() {
    //     return this.selectedItem.name.trim();
    //   }
    // },
    // getLink: {
    //   get() {
    //     return this.selectedItem.link?.trim();
    //   }
    // }
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