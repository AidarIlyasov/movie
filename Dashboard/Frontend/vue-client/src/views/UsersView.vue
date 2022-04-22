<template>
  <div>
    <Preloader v-show="preloader"></Preloader>
    <CustomList
        listName="user"
        :selectedItem="selectedUser"
        :operation="this.operation"
        :tableFields="tableFields"
        @update="updateUser($event)"
        @add="insertUser($event)"
    >
      <tr v-for="(user, index) in users" :key="user.id">
        <th scope="row">{{index + 1}}</th>
        <td>{{user.login}}</td>
        <td>{{user.email}}</td>
        <td>{{user.password}}</td>
        <td>{{user.role}}</td>
        <td>
          <button
              class="btn btn-sm btn-outline-secondary"
              title="edit user"
              @click="editUser(index)"
          ><i class="fa fa-cog"></i>
          </button>
        </td>
      </tr>
    </CustomList>
    <button class="btn-sm btn-success" @click="addUser()">Add user</button>
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
  name: "UsersView.vue",
  mixins: [validator, displayErrors],
  setup: () => ({ v$: useVuelidate() }),
  data() {
    return {
      users: [],
      selectedUser: {},
      validateUser: {},
      tableFields:[
          {name: "login", editable: true, type: "text"},
          {name: "email", editable: true, type: "email"},
          {name: "password", editable: true, type: "password"},
          {name: "role", editable: true, type: "select", options: {}
          }
      ],
      selectedIndex: 0,
      preloader: true,
      operation: 'Update'
    }
  },
  validations () {
    return this.userValidator();
  },
  methods: {
    editUser(index) {
      this.operation = 'Update';
      this.selectedIndex = index;
      this.selectedUser = JSON.parse(JSON.stringify(this.users[index]));
      this.emitter.emit('userSettingsModal', true);
    },
    async updateUser(updatedData) {
      this.validateUser = updatedData;
      if (!await this.validateFields("User")) return;

      axios.put(`/dashboard/users/${this.selectedUser.id}/`, updatedData, header)
          .then(r => this.users[this.selectedIndex] = r.data)
          .then(() => this.$notify({
            title: `User ${this.selectedUser.login} was updated`,
            type: "success"
          }))
          .catch(e => this.displayErrors(e.response))
    },
    addUser() {
      this.selectedUser = {};
      this.operation = 'Add';
      this.emitter.emit('userSettingsModal', true);
    },
    async insertUser(updatedData) {
      this.validateUser = updatedData;
      if (!await this.validateFields("User")) return;

      axios.post(`/dashboard/users/`, updatedData, header)
          .then(r => this.users.push(r.data))
          .then(() => this.$notify({
            title: "User was successfully added",
            type: "success"
          }))
          .catch(e => this.displayErrors(e.response));
    }
  },
  created() {
    axios.get('/dashboard/users/', header)
        .then(r => this.users = r.data)
        .catch(e => console.error(e))
        .finally(() => this.preloader = false);
    
    axios.get('/dashboard/roles/', header)
      .then(r => this.tableFields[3].options = r.data)
      .catch(e => console.error(e));
  },
  components: {
    CustomList,
    Preloader
  }
}
</script>

<style scoped>

</style>