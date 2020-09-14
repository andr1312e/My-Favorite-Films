<template>
    <div class="add-film-wrapper">
        <h1>Add new Film</h1>

    <div class="add-film-form">
        <ul class="new-film">
            <li>
            <label for="title">Film Title</label>
            <input type="text" id="title" v-model="film.title"/>
            </li>
            <li>
                <label for="producer">Film Producer</label>
                <input type="text" id="producer" v-model="film.producer"/>
            </li>
        </ul>
        <button
        :disabled="isButtonDisabled"
         @click="addFilm">Add Film</button>
    </div> 
</div>
</template>

<script lang="ts">
import IFilm from '@/types/Film';
import Vue from 'vue'
import Component from 'vue-class-component';
import FilmService from '@/services/film-service.ts';

const filmService= new FilmService();

 @Component ({
     name: "AddFilm",
     components:{}
 })

 export default class AddFilm extends Vue {
        film: IFilm={
            title:"",
            producer:"",

        };

        get isButtonDisabled(){
            return this.film.title=== "" || this.film.producer===""
        }

        addFilm(){
            filmService.AddNewFilm(this.film);
            filmService.getAllFilms();
        }
 }

</script>

<style lang="scss">
    .new-film{
        list-style-type: none;
        list-style: none;
        padding: 0;
        margin: 0;
    }
    input{
        height: 1.8rem;
        margin-bottom: 1.2rem;
        font-size: 1.1rem;
        line-height: 1.3rem;
        padding:  0.2rem;
        color: #555;
    }
    label{
        font-weight: bold;
        display: block;
        margin-bottom: 0.3rem;
    }
</style>