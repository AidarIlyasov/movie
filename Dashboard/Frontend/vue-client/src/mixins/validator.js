import { minLength, required, helpers } from '@vuelidate/validators';
import useVuelidate from '@vuelidate/core'

export default {
  name: "validator",
  methods: {
    restrictionValidator() {
      return {
        selectedRestriction: {
          name: {
            required: helpers.withMessage(({$property}) => `the '${$property}' field cannot be empty`, required),
            minLength: minLength(2)
          },
          link: {
            required: helpers.withMessage(({$property}) => `the '${$property}' field cannot be empty`, required),
            minLength: minLength(1)
          }
        }
      }
    },
    async validateRestrictionsFields() {
      const isFormCorrect = await this.v$.$validate()
      
      if (!isFormCorrect) {
        this.v$.selectedRestriction.$errors.forEach(e => {
          this.$notify({
            title: `${e.$property}: ${e.$message.toLowerCase()}`,
            type: "error"
          });
        });
      }

      return isFormCorrect;
    }
  }
}
