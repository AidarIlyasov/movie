<template>
  <div class="table-responsive-sm">
    <table class="custom-list_table table table-bordered table-hover">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Name</th>
          <th scope="col">Link</th>
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
        <div class="form-group">
          <label for="item-name">{{listName}} name</label>
          <input type="text" class="form-control form-control-sm" id="item-name" v-model="selectedItem.name">
        </div>
        <div class="form-group">
          <label for="item-link">{{listName}} link</label>
          <input type="text" class="form-control form-control-sm" id="item-link" v-model="selectedItem.link">
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
</style>