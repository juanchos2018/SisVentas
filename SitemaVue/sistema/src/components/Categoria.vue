<template>
    <v-layout align-start>
        <v-flex>
            <v-toolbar flat color="white">
                <v-toolbar-title>Categorías</v-toolbar-title>
                <v-divider
                class="mx-2"
                inset
                vertical
                ></v-divider>
                <v-spacer></v-spacer>
                <v-text-field class="text-xs-center" v-model="search" append-icon="search" label="Búsqueda" single-line hide-details></v-text-field>
                <v-spacer></v-spacer>
                <v-dialog v-model="dialog" max-width="500px">
                    <v-btn slot="activator" color="primary" dark class="mb-2">Nuevo</v-btn>
                    <v-card>
                    <v-card-title>
                    <span class="headline">{{ formTitle }}</span>
                    </v-card-title>
            
                        <v-card-text>
                        <v-container grid-list-md>
                            <v-layout wrap>
                            <v-flex xs12 sm12 md12>
                                <v-text-field v-model="nombre" label="Nomnbre Categoria"></v-text-field>
                            </v-flex>
                            <v-flex xs12 sm12 md12>
                                <v-text-field v-model="descripcion" label="Descripcion"></v-text-field>
                            </v-flex>
                        

                            <v-flex xs12 sm12 md12 v-show="valida">
                               <div class="red--text" v-for="v in validamensaje" :key="v" v-text="v">

                               </div>
                            </v-flex>

                            </v-layout>
                        </v-container>
                        </v-card-text>
            
                        <v-card-actions>
                        <v-spacer></v-spacer>
                            <v-btn color="blue darken-1" flat @click.native="close">Cancelar</v-btn>
                            <v-btn color="blue darken-1" flat @click.native="guardar">Guardar</v-btn>
                    </v-card-actions>
                </v-card>
                </v-dialog>


                <v-dialog v-model="adModal" max-width="290">
                        <v-card>
                            <v-card-title class="headline" v-if="adAccion==1" > Activar Inten?</v-card-title>
                             <v-card-title class="headline" v-if="adAccion==2" > Desctivar Inten?</v-card-title>

                             <v-card-text>
                                 estas  a  punto de 
                                 <span  v-if="adAccion==1">Activar</span>
                                 <span  v-if="adAccion==2">Desactivar</span>

                                 el item {{adNombre}}
                             </v-card-text>

                             <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn color="greem darken-1" flat="flat" @click="activarDesactivarCerrar">Cancelar</v-btn>
                                     <v-btn v-if="adAccion==1" color="orange darken-1" flat="flat" v-on:click="Activar"> Activar</v-btn>
                                      <v-btn v-if="adAccion==2" color="orange darken-1" flat="flat" v-on:click="Desactivar"> Desactivar</v-btn>
                             </v-card-actions>
                        </v-card>
                </v-dialog>

            </v-toolbar>
            <v-data-table
                :headers="headers"
                :items="categorias"
                :search="search"
                class="elevation-1"
            >
                <template slot="items" slot-scope="props">
                     <td class="justify-center layout px-0">
                    <v-icon
                    small
                    class="mr-2"
                    @click="editItem(props.item)"
                    >
                    edit
                    </v-icon>
                    <template v-if="props.item.condicion">                   
                        <v-icon
                        small
                        @click="activarDesactivarMostrar(2,props.item)"
                        >
                        block
                        </v-icon>
                     </template>

                      <template v-else>                   
                        <v-icon
                        small
                        @click="activarDesactivarMostrar(1,props.item)"
                        >
                        check
                        </v-icon>
                     </template>


                </td>
                <td>{{ props.item.nombre }}</td>
                <td>{{ props.item.descripcion }}</td>
                <td >
                    <div v-if="props.item.condicion">
                            <span class="blue--text">Activo</span>
                    </div>
                     <div v-else>
                            <span class="red--text">Inactivo</span>
                    </div>
                    
                </td>
                
               
                </template>
                <template slot="no-data">
                <v-btn color="primary" @click="listar">Resetear</v-btn>
                </template>
            </v-data-table>
        </v-flex>
    </v-layout>
</template>

<script>

import axios from  'axios'

    export default{

        data(){
            return{

                categorias:[],    

                search:'',   
                dialog: false,
                headers: [
                { text: 'Opciones', value: 'opciones', sortable: false } ,             
                { text: 'Nombre', value: 'nombre' },
                { text: 'Descricpcion', value: 'descripcion' ,sortable:false},
                { text: 'Estado', value: 'condicion' ,sortable:false},
              
                ],
        
                   editedIndex: -1, 
                    id:'',
                    nombre:'',
                    descripcion:'',
                    valida:0,
                    validamensaje:[],
                    adModal:0,
                    adAccion:0,
                    adNombre:'',
                    adId:''
                

            }
        },

        computed: {
            formTitle () {
            return this.editedIndex === -1 ? 'Nueva Categoria' : 'Actualizar Categoria'
            },
        },

        watch: {
            dialog (val) {
            val || this.close()
            },
        },

        created () {
         
            this.listar();

        },

        methods:{
            
        listar(){

            let me=this;
             axios.get('api/Categorias/Listar').then(function(response){
             me.categorias=response.data;
             
             console.log(response);


         }).catch(function(error){
             console.log(error);
         });

        },      

        editItem (item) {
            
            this.id=item.idcategoria;
            this.nombre=item.nombre;
            this.descripcion=item.descripcion;
            this.editedIndex=1;
            this.dialog = true
        },

        deleteItem (item) {
        const index = this.desserts.indexOf(item)
        confirm('Are you sure you want to delete this item?') && this.desserts.splice(index, 1)
        },

        close () {
         this.dialog = false
         this.limpiar();

        
        },

        limpiar(){
            this.id="";
            this.nombre="";
            this.descripcion="";
            this.editedIndex=-1;
        },

        guardar () {

         if(this.validar()){

            return;
         }   

        if (this.editedIndex > -1) {
                
            let me =this;
            axios.put('api/Categorias/Actualizar',{
                 'idcategoria':me.id,   
                'nombre':me.nombre,
                'descripcion':me.descripcion

            }).then(function(response){

                me.close();
                me.listar();
                me.limpiar();
            }).catch(function(error){
                console.log(error);
            });
            //codigopara editar
        //  Object.assign(this.desserts[this.editedIndex], this.editedItem)

        } else {
            //codigo para guardar
        // this.desserts.push(this.editedItem)

            let me =this;
            axios.post('api/Categorias/Crear',{

                'nombre':me.nombre,
                'descripcion':me.descripcion

            }).then(function(response){

                me.close();
                me.listar();
                me.limpiar();
            }).catch(function(error){
                console.log(error);
            });
        
        }
        
        },
        validar(){

            this.valida=0;
            this.validamensaje=[];
            if(this.nombre.length<3 || this.nombre.length>50 ){

                    this.validamensaje.push("el nombre debe tener mas de 3 catarres");

            }
            if(this.validamensaje.length){
                this.valida=1;
            }
            return  this.valida;

        },
        activarDesactivarMostrar(accion,item){

                this.adModal=1;
                this.adNombre=item.nombre;
                this.adId=item.idcategoria;

                if(accion==1){
                    this.adAccion=1;
                }
                else if(accion==2){
                   this.adAccion=2;
                }else{
                     this.adModal=0;
                }


        },
        Activar(){

                let me =this;
                axios.put('api/Categorias/Activar/'+this.adId,{
                    

                }).then(function(response){

                    me.adModal=0;
                    me.accion=0;
                    me.nombre="";
                    me.adId="";
                    me.listar();
                }).catch(function(error){
                    console.log(error);
                });
        },
        Desactivar(){

             let me =this;
            axios.put('api/Categorias/Desactivar/'+this.adId,{                

            }).then(function(response){
                me.adModal=0;
                me.accion=0;
                me.nombre="";
                me.adId="";
                me.listar();
            }).catch(function(error){
                console.log(error);
            });
        },
        activarDesactivarCerrar(){
            this.adModal=0;

        }

    }

}
</script>