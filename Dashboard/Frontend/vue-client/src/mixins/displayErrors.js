export default {
  name: "displayErrors",
  methods: {
    displayErrors(response) {
      // response.data
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