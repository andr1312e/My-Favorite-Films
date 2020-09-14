<template>
    <div>
    <div v-if="this.film.title">
        <div class="film-title">
         {{film.title}}           
        </div>
        <div class="film-producer">
         {{film.producer}}           
        </div>
        <div class="film-updatedOn">
          {{film.updatedOn | humanize-filter}}          
        </div> 
    </div >   
    <div v-else>
         Выберите фильм пожалуйста на странице мои фильмы.       
    </div>
    </div>
</template>

<script lang="ts">
import IFilm from '@/types/Film';
import  Vue from 'vue';
import Component from 'vue-class-component';
import FilmService from '@/services/film-service';
const filmService = new FilmService();
@Component({
 name: 'Film',
})

export default class ThisFilm extends Vue{
    film: IFilm={id: 0, title: ""};
    created(){
        this.film.id=+this.$route.params.id.charAt(1);
        filmService.getFilmById(this.film.id).then(res=>this.film=res).catch(err=>console.log(err));
    }
}
</script>

<style lang="scss" scoped>

</style>