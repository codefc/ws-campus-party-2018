<template>
<div class="col-md-12">   
    <div class="table-responsive">
      <table class="table table-striped table-bordered" style="width:100%">
          <thead width="400px">
              <tr>
                  <th scope="col">Name</th>
                  <th scope="col" >Full Name</th>
                  <th scope="col" >Description</th>
                  <th>#</th>
              </tr>
          </thead>
          <tbody>
              <tr v-for="(item, index) in repositories" :key="index">                
                <td>{{item.name}}</td>
                <td>{{item.full_name}}</td>
                <td>{{item.description}}</td>
                <td>
                  <b-button v-on:click="excluir" v-if="acaoExcluirHabilitada">
                   Excluir
                  </b-button>
                </td>
              </tr>
          </tbody>
      </table>
    </div>
  </div>

</template>

<script>
import axios from "axios";
const configcat = require("configcat-node");

export default {
  name: 'grid',
  
  data () {
      return {         
          repositories: [],
          client : {},
          acaoExcluirHabilitada: false
      }
  },
  created () {
      this.client = configcat.createClient("UULWCKjmCACU7eTV-m68mw/WDlzpoCU-E6t1EkARRUyUA")
      return this.client.getValue("AcaoExcluir", false, { identifier: "usuario"}, (acaoExcluir) => {
        this.acaoExcluirHabilitada = acaoExcluir;
      });

      axios
      .get('https://resoluty-sh.azurewebsites.net/api/Values')
      .then(response => {
        this.repositories = response.data
      })
      .catch(error => {
        console.log(error)
        this.errored = true
      })
    },
    methods: {
      excluir: function(){
        alert(acaoExcluirHabilitada);
      },
      featureToggle : function(toggleName) {
        this.client.forceRefresh();

        return this.client.getValue(toggleName, false);
      }
    },
}
</script>

