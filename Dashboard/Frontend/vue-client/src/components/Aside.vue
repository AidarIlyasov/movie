<template>
  <div class="col-3 pr-0">
    <div class="sidebar">
      <ul class="list-group">
        <li class="list-group-item">
          <a class="custom-dropdown-toggle" @click="showDropdown('home')">
            <i class="fa fa-home"></i>Home page <i class="fa fa-caret-down"></i>
          </a>
          <ul class="custom-dropdown-container" v-show="openDropdown == 'home'">
            <li><RouterLink to="/home/season-items">New items of this season</RouterLink></li>
            <li><RouterLink to="/home/new-items">New items</RouterLink></li>
            <li><RouterLink to="/home/expected-premire">Expected premiere</RouterLink></li>
          </ul>
        </li>
        <li class="list-group-item">
          <RouterLink to="/movies"><i class="fa fa-file-movie-o"></i>Movies Settings</RouterLink>
        </li>
        <li class="list-group-item">
          <RouterLink to="/catalog"><i class="fa fa-list-ul"></i>Catalog page</RouterLink>
        </li>
        <li class="list-group-item">
          <RouterLink to="/actors"><i class="fa fa-star"></i>Actors</RouterLink>
        </li>
        <li class="list-group-item">
          <RouterLink to="/users"> <i class="fa fa-users"></i>Users</RouterLink>
        </li>
        <li class="list-group-item">
          <a href="activity.html"><i class="fa fa-area-chart"></i>Charts</a>
        </li>
        <li class="list-group-item">
          <RouterLink to="/pricing"><i class="fa fa-money"></i>Pricing plan</RouterLink>
        </li>
<!--        <li class="list-group-item">-->
<!--          <RouterLink to="/about"><i class="fa fa-money"></i>About page</RouterLink>-->
<!--        </li>-->
        <li class="list-group-item">
          <a href="message.html">
            <i class="menu-icon icon-inbox"></i>Inbox
            <span class="label-green pull-right">
                                    11
                                </span>
          </a>
        </li>
        <li class="list-group-item">
          <a href="task.html">
            <i class="menu-icon icon-tasks"></i>Tasks
            <span class="label-orange pull-right">
                                    19
                                </span>
          </a>
        </li>
      </ul>
      <ul class="list-group">
        <li class="list-group-item">
          <a href="index.html">
            <i class="menu-icon icon-dashboard"></i>Dashboard
          </a>
        </li>
        <li class="list-group-item">
          <a href="activity.html"><i class="menu-icon icon-bullhorn"></i>News Feed </a>
        </li>
        <li class="list-group-item">
          <a href="message.html">
            <i class="menu-icon icon-inbox"></i>Inbox
            <b class="label green pull-right">
              11
            </b>
          </a>
        </li>
        <li class="list-group-item">
          <a href="task.html">
            <i class="menu-icon icon-tasks"></i>Tasks
            <b class="label orange pull-right">
              19
            </b>
          </a>
        </li>
      </ul>
    </div>
    <!--/.sidebar-->
  </div>
</template>

<script>
export default {
  name: "Aside",
  data() {
    return {
      openDropdown: 'home'
    }
  },
  methods: {
    showDropdown(name) {
      this.openDropdown = name == this.openDropdown ? 'empty' : name;
    }
  }
}
</script>

<style scoped>

</style>