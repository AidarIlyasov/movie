export default {
  name: "displayErrors",
  methods: {
    displayErrors(response) {
      // response.data
      // if (response.status === 403) {
      //   window.location.href = "/login";
      // }
      //
      // if (response.status === 401) {
      //   this.$notify({
      //     title: "Access denied",
      //     type: "error"
      //   });
      //  
      //   return;
      // }
      
      if (response.data.errorMessage) {
        this.$notify({
          title: response.data.errorMessage,
          type: "error"
        })
      }
      
      for (let error in response.data.errors) {
        if (!response.data.errors.hasOwnProperty(error)) continue;
        response.data.errors[error].forEach(value => {
          this.$notify({
            title: value,
            type: "error"
          })
        })
      }
    }
  }
}