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
        .then(response => {
          this.users = response.data; 
        })
        .catch(error => {
          this.error = ''; 
          console.error(error);
        });
    },
    createResult() {
      const seconds = Math.floor(this.timer % 60);
      const minutes = Math.floor(this.timer / 60);
      const time = `${minutes}:${seconds < 10 ? '0' : ''}${seconds}`;

      axios.post('/results', { time, moves: this.score }) 
        .then(response => {
          console.log('You win!!!');
          console.log('Time:', time);
        })
        .catch(error => {
          console.error(error);
        });
    }
  }
};
</script>

<style scoped>
.background {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: #19242f;
  z-index: -1; 
}

.game {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 100vh;
  color: #fff;
}

.title {
  font-size: 24px;
  margin-bottom: 20px;
}

.score {
  font-size: 18px;
  margin-bottom: 20px;
}

.board {
  display: grid;
  grid-template-columns: repeat(4, 1fr);
  grid-gap: 10px;
  width: 400px;
  margin-bottom: 20px;
}

.tile {
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 24px;
  background-color: #555;
  color: #fff;
  cursor: pointer;
  border-radius: 4px;
  height: 80px;
}

.tile.matched {
  background-color: #333;
  cursor: default;
}

.reset-button {
  padding: 10px 20px;
  background-color: #3a3a3a;
  color: #fff;
  border: none;
  border-radius: 4px;
  font-size: 16px;
  cursor: pointer;
}

.reset-button:hover {
  background-color: #1b1b1b;
}

.game-over-message {
  font-size: 18px;
}
</style>