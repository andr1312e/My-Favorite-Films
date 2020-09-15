<template>
    <div @click="findFilm(film.id)"  class="film-wrapper">
        <div class="film-title">
         {{film.title}}           
        </div>
        <div class="film-producer">
         {{film.producer}}           
        </div>
        <div class="film-updatedOn">
            Дата съемки: 
          {{film.updatedOn | humanize-filter}}          
        </div>
        <div @click="deleteFilm(film.id)" class="delete">
            x
        </div>
    </div>
</template>
<script lang="ts">
import FilmService from '@/services/film-service';
import IFilm from '@/types/Film';
import { Component, Prop ,Vue } from 'vue-property-decorator';

const filmService=new FilmService();
@Component({
    name:"Film",
    components:{},
})


export default class Film extends Vue {
    @Prop({required: true})
    film!: IFilm;

    async deleteFilm(id: number){
        await filmService.deleteFilmById(id);
        this.$emit('deleted', id)
    }

    async getFilm(id: number)
    {
        console.log("Get Film method")
        Vue.component('film',{props: id});
        console.log("Get Film", id);
        
    }
    async findFilm(id: number)
    {
        const str='/currentFilm/:'+id;
        this.$router.push(str);        
    }


}
</script>

<style lang="scss" scoped>
    .film-wrapper{
        position: relative;
        width: 12.8rem;
        margin: 0.9rem;
        padding: 0.5rem;
        background-color: #fafafa;
        border: 2px groove #555;
        border-radius: 5px;
          box-shadow: 0 19px 38px rgba(0,0,0,0.30), 0 15px 12px rgba(0,0,0,0.22);
    }
    .film-title{
        margin: 0.9rem;
        font-size: 1.2rem;
        font-weight: bold;
    }
    .film-producer{
        color: #333;
    }
    .film-updatedOn{
        color: #333;
    }
    .delete{
        position: absolute;
        top: 5px;
        right: 10px;
        font-size: 0.9rem;
        font-weight: bold;
        color:#CE3355;
        cursor: pointer;
    }
</style>