<template>
    <div>
      <Navbar></Navbar>
      <div class="wrapper">
        <div class="container">
          <div class="row">
            <Aside></Aside>
            <div class="col-9">
              <RouterView />
            </div>
          </div>
        </div>
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
      // created() {
      //   axios.get('/dashboard/pages')
      //       .then(r => this.message = r.data);
      // },
      components: {
        Aside,
        Navbar
      }
    }
</script>

<style>
@import '@/assets/main.css';
</style>