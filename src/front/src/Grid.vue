<template>
<div class="col-md-12">   
    <div class="table-responsive">
      <table class="table table-striped table-bordered" style="width:100%">
          <thead width="400px">
              <tr>
                  <th scope="col">Name</th>
                  <th scope="col" >Full Name</th>
                  <th scope="col" >Description</th>
                  <th v-if="toggle">#</th>
              </tr>
          </thead>
          <tbody>
              <tr v-for="(item, index) in repositories" :key="index">                
                <td>{{item.name}}</td>
                <td>{{item.full_name}}</td>
                <td>{{item.description}}</td>
                <td v-if="toggle">
                  <b-button v-on:click="novaAcao" >
                   Ação
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
          toggle: false
      }
  },
  created () {
      this.client = configcat.createClient("<API_KEY>")
      return this.client.getValue("ACAO", false, { identifier: "usuario_COMUM"}, (acaoExcluir) => {
        this.toggle = acaoExcluir;
      });

      axios
      .get('<API>')
      .then(response => {
        this.repositories = response.data
      })
      .catch(error => {
        console.log(error)
        this.errored = true
      })
    },
    methods: {
      novaAcao: function(){
        
      }
    },
}
</script>

