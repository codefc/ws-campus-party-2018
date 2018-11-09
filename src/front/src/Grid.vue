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

export default {
  name: 'grid',
  
  props: {
          headers: [
          { text: 'Name', value: 'name' },
          { text: 'Full name', value: 'full_name' },
          { text: 'Description', value: 'description' }
        ],
          repositories: Array
      },
  data () {
      return {}
  }
}
</script>