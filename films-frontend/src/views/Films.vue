<template>
  <div class="film-container" >
    <h1>My films</h1>
    <div v-if="myFilms.length" >
      <film
      
      @deleted="getAllFilms"
      :film="film" 
      v-for="film in myFilms" v-bind:key="film.id" 
      @getById="getCurrentFilm" 
     
      >{{film.title}}
      </film>
      </div>
  </div>
</template>

<script lang="ts">
import FilmService from '@/services/film-service';
import IFilm from '@/types/Film';
import  Vue from 'vue';
import Component from 'vue-class-component';
import Film from "@/components/film.vue"

const filmService = new FilmService();
@Component({
 name: 'MyFilms',
  components:{ Film }
})


export default class MyFilms extends Vue{
 
     myFilms: IFilm[]=[];
     get filmCount(){
       return this.myFilms.length;
      }
      getAllFilms(){
        filmService.getAllFilms().then(res=>this.myFilms=res).catch(err=>console.error(err));
      }
      created(){
        this.getAllFilms();
      }
}

</script>

<style lang="scss" scoped>

</style>