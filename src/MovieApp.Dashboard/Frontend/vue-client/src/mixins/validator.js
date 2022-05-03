import {minLength, required, helpers, maxLength, email, numeric} from '@vuelidate/validators';
import useVuelidate from '@vuelidate/core'

export default {
  name: "validator",
  methods: {
    restrictionValidator() {
      return {
        validateRestriction: {
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
        validateCategory: {
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
        validateQuality: {
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
        validateCountry: {
          name: {
            required: helpers.withMessage(({$property}) => `the '${$property}' field cannot be empty`, required),
            minLength: minLength(2),
            maxLength: maxLength(25)
          },
          link: {
            required: helpers.withMessage(({$property}) => `the '${$property}' field cannot be empty`, required),
            minLength: minLength(2),
            maxLength: maxLength(25)
          },
          code: {
            required: helpers.withMessage(({$property}) => `the '${$property}' field cannot be empty`, required),
            numeric
          }
        }
      }
    },
    userValidator() {
      return {
        validateUser: {
          login: {
            required: helpers.withMessage(({$property}) => `the '${$property}' field cannot be empty`, required),
            minLength: minLength(2),
            maxLength: maxLength(25)
          },
          email: {
            required: helpers.withMessage(({$property}) => `the '${$property}' field cannot be empty`, required),
            minLength: minLength(5),
            maxLength: maxLength(25),
            email
          },
          password: {
            required: helpers.withMessage(({$property}) => `the '${$property}' field cannot be empty`, required),
            minLength: minLength(8),
            maxLength: maxLength(100),
          }
        }
      }
    },
    async validateFields(name) {
      const isFormCorrect = await this.v$.$validate()
      if (!isFormCorrect) {
        this.v$[`validate${name}`].$errors.forEach(e => {
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
