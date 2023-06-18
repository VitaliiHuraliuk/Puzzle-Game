<template>
  <div class="game">
    <div class="background"></div>
    <h1 class="title">15 Puzzle Game</h1>
    <div class="score">Amount of moves: {{ score }}</div>
    <div class="board">
      <div v-for="tile in tiles" :key="tile.id" class="tile" :class="{ matched: tile.matched }" @click="handleTileClick(tile)">
        {{ tile.value }}
      </div>
    </div>
    <button class="reset-button" @click="resetGame">Reset</button>
    <div v-if="gameOver" class="game-over-message">Congratulations! You won!</div>
    <div class="error" v-if="error">{{ error }}</div>
  </div>
</template>

<script>
import axios from '../services/axios';

export default {
  data() {
    return {
      tiles: [],
      score: 0,
      timer: 0,
      gameOver: false,
      users: [],
      error: ''
    };
  },
  created() {
    this.startGame();
    this.fetchUsers();
  },
  methods: {
    startGame() {
      this.tiles = this.generateTiles();
      this.score = 0;
      this.timer = 0;
      this.gameOver = false;
    },
    handleTileClick(tile) {
      if (!tile.matched) {
        if (this.isAdjacentToEmpty(tile)) {
          this.swapTiles(tile);
          this.score++;

          if (this.checkWin()) {
            this.gameOver = true;
            this.createResult();
          }
        }
      }
    },
    resetGame() {
      this.startGame();
    },
    generateTiles() {
      const tiles = [];
      const values = Array.from({ length: 15 }, (_, index) => index + 1);

      for (let i = values.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [values[i], values[j]] = [values[j], values[i]];
      }

      for (let i = 0; i < values.length; i++) {
        const tile = {
          id: i + 1,
          value: values[i],
          matched: false
        };

        tiles.push(tile);
      }

      tiles.push({
        id: 16,
        value: '',
        matched: false
      });

      return tiles;
    },
    isAdjacentToEmpty(tile) {
      const emptyTile = this.tiles.find((t) => t.value === '');

      if (emptyTile) {
        const rowDiff = Math.abs(tile.id - emptyTile.id) % 4;
        const colDiff = Math.floor(Math.abs(tile.id - emptyTile.id) / 4);

        return (rowDiff === 1 && colDiff === 0) || (rowDiff === 0 && colDiff === 1);
      }

      return false;
    },
    swapTiles(tile) {
      const emptyTile = this.tiles.find((t) => t.value === '');

      if (emptyTile) {
        const tempValue = tile.value;
        tile.value = emptyTile.value;
        emptyTile.value = tempValue;
      }
    },
    checkWin() {
      for (let i = 0; i < this.tiles.length - 1; i++) {
        if (this.tiles[i].value !== i + 1) {
          return false;
        }
      }

      return true;
    },
    fetchUsers() {
      axios.get('/users')
        .then((response) => {
          this.users = response.data;
        })
        .catch((error) => {
          this.error = '';
          console.error(error);
        });
    },
    createResult() {
      const seconds = Math.floor(this.timer % 60);
      const minutes = Math.floor(this.timer / 60);
      const time = `${minutes}:${seconds < 10 ? '0' : ''}${seconds}`;

      axios.post('/api/results', { time, moves: this.score })
        .then((response) => {
          console.log('You win!!!');
          console.log('Time:', time);
        })
        .catch((error) => {
          console.error(error);
        });
    }
  }
};
</script>

<style scoped>
</style>