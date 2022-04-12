import {minLength, required, helpers, maxLength} from '@vuelidate/validators';
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
    categoriesValidator() {
      return {
        selectedCategory: {
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
    qualityValidator() {
      return {
        selectedQuality: {
          name: {
            required: helpers.withMessage(({$property}) => `the '${$property}' field cannot be empty`, required),
            minLength: minLength(2),
            maxLength: maxLength(10)
          }
        }
      }
    },
    countryValidator() {
      return {
        selectedCountry: {
          name: {
            required: helpers.withMessage(({$property}) => `the '${$property}' field cannot be empty`, required),
            minLength: minLength(2),
            maxLength: maxLength(25)
          },
          link: {
            required: helpers.withMessage(({$property}) => `the '${$property}' field cannot be empty`, required),
            minLength: minLength(2),
            maxLength: maxLength(25)
          }
        }
      }
    },
    async validateFields(name) {
      const isFormCorrect = await this.v$.$validate()
      if (!isFormCorrect) {
        this.v$[`selected${name}`].$errors.forEach(e => {
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
