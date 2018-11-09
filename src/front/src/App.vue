<template>
  <div id="app">
    <v-app>
    <v-toolbar color="indigo" dark fixed app>
      <v-toolbar-title>Campus Party MG 2018 | Workshop - Feature Toggle/Trung Based</v-toolbar-title>
    </v-toolbar>
    <v-content>
      <v-container fluid fill-height>
        <v-layout
        justify-center column fill-height
        >
        <grid :repositories="repositories"></grid>

        </v-layout>
      </v-container>
    </v-content>
    <v-footer color="indigo" app inset>
      <span class="white--text">&copy; Code FC 2018</span>
    </v-footer>
    </v-app>
  </div>
</template>

<script>
import Grid from './Grid'
import axios from "axios";


export default {
  name: 'app',
  data () {
    return {
      repositories: Array
    }
  },
  components: {
    Grid
  },
  created () {
      axios
      .get('https://resoluty-sh.azurewebsites.net/api/Values')
      .then(response => {
        console.log(response)
        this.repositories = response
      })
      .catch(error => {
        console.log(error)
        this.errored = true
      })
    }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

h1, h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
}
</style>
