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
.login-container {
  position: fixed;
  inset: 0;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  background-color: #19242f;
  z-index: 9999;
}

.login-title {
  font-size: 28px;
  margin-bottom: 20px;
  color: #fff;
}

.login-form {
  display: flex;
  flex-direction: column;
  width: 300px;
}

.form-group {
  margin-bottom: 15px;
}

.form-label {
  font-size: 25px;
  color: #fff;
}

.form-input {
  padding: 10px;
  font-size: 22px;
  border: none;
  border-radius: 10px;
}

.login-button {
  margin-right: 10px;
  padding: 10px;
  font-size: 16px;
  background-color: #515151;
  color: #fff;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

.registration-button {
  padding: 10px;
  font-size: 19px;
  background-color: #515151;
  color: #fff;
  border: none;
  border-radius: 52px;
  cursor: pointer;
  margin-top: -14px;
}
</style>
