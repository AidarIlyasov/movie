<template>
  <div>
    <notifications width="370"></notifications>
    <div v-show="userExisted">
      <Navbar></Navbar>
      <div class="wrapper">
        <div class="container">
          <div class="row">
            <Aside></Aside>
            <div class="col-9">
              <RouterView :key="$route.fullPath" />
            </div>
          </div>
        </div>
      </div>
    </div>
    <div v-show="!userExisted">
      <RouterView name="LoginView"></RouterView>
      <RouterView name="PageNotFound"></RouterView>
    </div>
  </div>
</template>

<script>
    import Navbar from '@/components/Navbar.vue'
    import Aside from '@/components/Aside.vue'
    import axios from 'axios'
      
    export default {
      data() {
        return {
          count: 0,
          message: ''
        }
      },
      components: {
        Aside,
        Navbar
      },
      created() {
        if (!this.userExisted) 
          this.$router.push('/login');
      },
      computed: {
        userExisted() {
          return !!localStorage.getItem('user');
        }
      }
    }
</script>

<style>
  @import '@/assets/main.css';
  .vue-notification {
    font-size: 18px;
  }
</style>