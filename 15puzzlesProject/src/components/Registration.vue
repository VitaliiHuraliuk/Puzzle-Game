<template>
  <div class="registration-container">
    <h1 class="registration-title">Create an account</h1>
    <form class="registration-form" @submit.prevent="register">
      <div class="form-group">
        <label class="form-label"></label>
        <input class="form-input" type="text" v-model="username" placeholder="Username" required>
      </div>
      <div class="form-group">
        <label class="form-label"></label>
        <input class="form-input" type="password" v-model="password" placeholder="Password" required>
      </div>
      <button class="register-button" type="submit">Register</button>
    </form>
    <p>{{ error }}</p>
    <button class="login-button" @click="goToLogin">Login</button>
  </div>
</template>

<script>
import axios from '../services/axios';

export default {
  data() {
    return {
      username: '',
      password: '',
      error: ''
    };
  },
  methods: {
    register() {
      axios.post('https://localhost:7082/Users/register-user', { 
        login: this.username,
        password: this.password
      })
      .then(response => {

        this.$router.push('/login');
      })
      .catch(error => {
        this.error = 'Registration failed';
        console.error(error);
      });
    },
    goToLogin() {
      this.$router.push('/login');
    }
  }
};
</script>

<style scoped>
</style>