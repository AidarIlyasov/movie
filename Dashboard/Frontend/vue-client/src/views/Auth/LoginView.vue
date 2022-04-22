<template>
  <div class="col-3 m-auto row align-items-center" style="height: 90vh;">
    <div class="w-100">
      <h3 class="text-center mb-2">Wellcome to Dashboard</h3>
      <div class="form-group w-100">
        <label for="staticEmail">Email</label>
        <input type="email" class="form-control form-control-sm" id="staticEmail" v-model="form.email" placeholder="email@example.com">
      </div>
      <div class="form-group w-100">
        <label for="inputPassword">Password</label>
        <input type="password" autocomplete="off" class="form-control form-control-sm" v-model="form.password" id="inputPassword">
      </div>
      <button class="btn btn-sm btn-success" @click="submit()">submit</button>
    </div>
  </div>
</template>

<script>
import { mapActions } from 'vuex'

export default {
  name: "LoginView.vue",
  data() {
    return {
      form: {
        email: 'admin@mail.ru',
        password: 12345678
      }
    }
  },
  methods: {
    ...mapActions({
      singIn: 'auth/singIn'
    }),
    submit() {
      let fd = new FormData();
      fd.append("grant_type", "password");
      fd.append("email", this.form.email);
      fd.append("password", this.form.password);
      this.singIn(fd);
      this.$router.push("/movies");
    }
  }
}
</script>

<style scoped>
  
</style>