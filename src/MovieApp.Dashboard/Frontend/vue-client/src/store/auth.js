import axios from "axios";
import router from "../router";

export default {
  namespaced: true,
  state: () => ({
    token: '',
    user: null
  }),
  mutations: {
    SET_USER(state, user) {
      state.user = user;
    },
    UNSET_USER(state) {
      state.user = null;
    }
  },
  actions: {
    async singIn(context, credentials) {
      try {
        console.log(credentials.get('email'));
        const response = await axios.post('/dashboard/account/token', credentials, {
          headers: {"Accept": "application/json"}
        });
        
        context.commit('SET_USER', response.data);
        localStorage.setItem('user', response.data.access_token)
      } catch (e) {
        console.error(e);
      }
    },
    singOut(context) {
      context.commit('UNSET_USER');
      localStorage.removeItem('user');
    },
    async singUp(context, credentials) {
      try {
        let response = await axios.post('/dashboard/account/register', credentials);
        context.commit('SET_USER', response.data);
        localStorage.setItem('user', JSON.stringify(response.data))
      } catch (e) {
        console.error(e);
      }
    }
  }
}