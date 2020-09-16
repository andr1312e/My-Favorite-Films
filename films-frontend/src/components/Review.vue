<template>
  <div class="review-wrapper">
    Накалякал:
    <div class="review-author">{{review.reviewAuthor}}</div>САМО РЕВЬЮ:
    <div class="review-text">{{review.review}}</div>
    <div class="review-update">
      Дата публикации:
      {{review.updatedOn | humanize-filter}}
    </div>
    <div @click="DeleteReview(this.review.Id)" class="delete">х</div>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import ReviewService from "@/services/review-service.ts";
import IReview from "@/types/Review.d.ts";
const reviewServise = new ReviewService();

@Component({
  props: ["review", "FilmId"],
  name: "Review",
  components: {},
})
export default class Review extends Vue {
  async getReview(id: number) {
    console.log(id, "this if film id and we get metchod review");
  }
  mounted() {
    this.getReview(this.$props["FilmId"]);
    console.log("created method review");
    console.log(this.$props["review"], "get review");
  }
  async DeleteReview(id: number) {
    //await filmService.deleteFilmById(id);
    //this.$emit('deleted', id)
    console.log(id, "del");
  }
}
</script>

<style lang="scss" scoped>
</style>