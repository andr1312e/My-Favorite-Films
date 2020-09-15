<template>
    <div class="review-wrapper">
        РЕВЬЮЮЮЮЮЮЮЮЮЮЮ
        <div class="review-author">
             {{review.ReviewAuthor}}   
        </div>
        <div class="review-text">
            {{review.Review}}
        </div>
        <div class="review-update">
            Дата публикации: 
            {{review.updatedOn | humanize-filter}}
        </div>
        <div @click="DeleteReview(this.review.Id)" class="delete">х</div>
    </div>
</template>

<script lang="ts">
import { Component, Prop ,Vue } from 'vue-property-decorator';
import ReviewService from '@/services/review-service.ts'
import IReview from '@/types/Review.vue'
const reviewServise=new ReviewService();

@Component({
    props:['FilmId'],
    name : "Review", 
    components: {},
})

export default class Review extends Vue{
    @Prop({required: true})
    review!: IReview

    async getReview(id: number){
        console.log(id , "get metchod");
    }
    created(){
        this.getReview(this.$props['FilmId']);
        console.log("created");
        console.log(this.review)
    }
    async DeleteReview(id: number){
        //await filmService.deleteFilmById(id);
        //this.$emit('deleted', id)
        console.log(id, "del")
    }

}

</script>

<style lang="scss" scoped>

</style>