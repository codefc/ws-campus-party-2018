<template>
  <div id="grid">
    <v-data-table
            :headers="headers"
            :items="repositories"
            hide-actions
            class="elevation-1"
          >
            <template slot="items" slot-scope="props">
              <td>{{ props.item.name }}</td>
              <td class="text-xs-right">{{ props.item.calories }}</td>
              <td class="text-xs-right">{{ props.item.fat }}</td>
              <td class="text-xs-right">{{ props.item.carbs }}</td>
              <td class="text-xs-right">{{ props.item.protein }}</td>
              <td class="text-xs-right">{{ props.item.iron }}</td>
            </template>
          </v-data-table>
  </div>
</template>

<script>
import axios from "axios";


export default {
  name: 'grid',
  mounted () {
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
    },
  data () {
      return {
        headers: [
          { text: 'Name', value: 'name' },
          { text: 'Full name', value: 'full_name' },
          { text: 'Description', value: 'description' }
        ],
        repositories: []
      }
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
