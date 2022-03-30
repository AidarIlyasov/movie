<template>
  <nav class="navbar navbar-expand-lg navbar-light">
    <div class="container">
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerDemo03" aria-controls="navbarTogglerDemo03" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <a class="navbar-brand" asp-area="Panel" asp-controller="Panel" asp-action="Index">Logotype</a>
      <div class="collapse navbar-collapse" id="navbarTogglerDemo03">
        <ul class="navbar-nav w-100 mt-2 mt-lg-0">
          <li class="nav-item active">
            <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
          </li>
          <li class="nav-item">
            <a class="nav-link" asp-controller="Panel" asp-action="Support">Support</a>
          </li>
          <li class="nav-item dropdown profile-dropdown">
            <a href="#" class="dropdown-toggle nav-link" data-toggle="dropdown" id="navbarDropdownProfile">
              <img src="images/user.png" class="nav-avatar">
            </a>
            <ul class="dropdown-menu dropdown-menu-left" aria-labelledby="navbarDropdownProfile">
              <li>
                <a href="#">Inbox</a>
              </li>
              <li>
                <a asp-controller="Account" asp-action="Settings">Account Settings</a>
              </li>
              <hr>
              <li>
                <a asp-controller="Account" asp-action="Logout">Logout</a>
              </li>
            </ul>
          </li>
        </ul>
      </div>
    </div>
    <!-- /navbar-inner -->
  </nav>
</template>

<script>
export default {
  name: "Navbar"
}
</script>

<style scoped>

</style>