<template>
<v-app>
    <v-content>
        <v-container class="fill-height">
            <v-row align="center" justify="center">
                <v-col cols="12" sm="8" ms="8">
                    <v-card class="elevevation-12">

                        <v-window v-model="step">
                                <v-window-item :value="1">
                                   <v-row>
                                        <v-col cols="12" md="8">
                                        <v-card-text  class="mt-12">
                                            <h1 class="text-center display-2 teal--text text--accent-3">Inicio de sesion</h1>

                                            <div class="text-center" mt-4 >
                                                <v-btn class="mx-2" fab color="black" outlined>
                                                    <v-icon>fab -fa-facebook</v-icon>
                                                </v-btn>

                                            <v-btn class="mx-2" fab color="black" outlined>
                                                  <v-icon>fab -fa-facebook</v-icon>
                                            </v-btn>

                                               <v-btn class="mx-2" fab color="black" outlined>
                                                  <v-icon>fab -fa-facebook</v-icon>
                                            </v-btn>

                                            </div>

                                            <h4 class="text-center mlt-4">Registracion</h4>
                                        <v-form >
                                            <v-text-field label="Email"
                                            name="Email"
                                            prepend-icon="email"
                                            type="text"
                                            color="teal accent-3">
                                            </v-text-field>

                                            <v-text-field
                                            id="password"
                                            label="password"
                                            name="password"
                                            prepend-icon="lock"
                                            type="password"
                                            color="teal accent-3">

                                              </v-text-field>
                                        </v-form>
                                        <h3 class="text-center mt-3"> fortet your password ?</h3>

                                        </v-card-text>
                                            <div class="text-center mt-3"> 
                                                    <v-btn rounded color="teal accent-3" dark> iniciar sesion</v-btn>
                                            </div>
                                        </v-col> 
                                        <v-col cols="12" md="4" class="teal accent-3">
                                            <v-card-text class="white--text met-12">
                                               <h1 class="text-center display-1">Hello,frind </h1> 
                                           
                                                <h5 class="text-center   ">enter youu personal details </h5>

                                            </v-card-text>

                                            <div class="text-center">
                                                    <v-btn rounded outlined="" dark @click="step++">
                                                            ingresar we
                                                    </v-btn>
                                            </div>
                                          </v-col>
                                   </v-row>
                                </v-window-item>

                        </v-window>

                    </v-card>
                </v-col>
            </v-row>

        </v-container>
    </v-content>
</v-app>
</template>

<script>
export default {
    data:()=>({

        step:1
    }),
    props:{
        source:String
    }
    
}
</script>