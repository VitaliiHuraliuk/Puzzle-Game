<template>
  <div class="login-container">
    <h1 class="login-title">Enter your username and password</h1>
    <form class="login-form" @submit.prevent="login">
      <div class="form-group">
        <label class="form-label"></label>
        <input class="form-input" type="text" v-model="username" placeholder="Username" required>
      </div>
      <div class="form-group">
        <label class="form-label"></label>
        <input class="form-input" type="password" v-model="password" placeholder="Password" required>
      </div>
      <button class="login-button" type="submit">Log In</button>
    </form>
    <p>{{ error }}</p>
    <button class="registration-button" @click="goToRegistration">Registration</button>
  </div>
</template>

<script lang="js">
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
  login() {
    axios.post('https://localhost:7082/Users/login-user', {
  login: this.username,
  password: this.password
  })
    .then(response => {
      if (response.data === 'Login successful') {
        this.$router.push('/game');
      } else {
        this.error = 'Invalid username or password';
      }
    })
    .catch(error => {
      this.error = 'Login failed';
    });
  },
  goToRegistration() {
    this.$router.push('/registration');
  }
 }
}
</script>

<style scoped>
</style>
