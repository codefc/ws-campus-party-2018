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
  
  data () {
      return {
          headers: [
          { text: 'Name', value: 'name' },
          { text: 'Full name', value: 'full_name' },
          { text: 'Description', value: 'description' }
        ],
          repositories: []
      }
  },
  created () {
      axios
      .get('https://resoluty-sh.azurewebsites.net/api/Values')
      .then(response => {
        console.log(response)
        this.repositories = response.data
      })
      .catch(error => {
        console.log(error)
        this.errored = true
      })
    }
}
</script>