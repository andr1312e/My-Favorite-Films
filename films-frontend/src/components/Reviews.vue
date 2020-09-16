<template>
  <div class="ComentsField">
    <div class="ListOfComments">
      <div v-if="this.getReviewsCount() > 0">
        <div v-for="review in ReviewsList" v-bind:key="review.id">
          Вошли в цикл
          <review :review="review" :FilmId="FilmId">
            Пытаемся писать ревью
            {{ review.Review }}
          </review>
        </div>
        <div class="Review-form-to-write">
          <input type="text" placeholder="Write review here" />
          <button class="Button-submit">Submit</button>
        </div>
      </div>
    </div>
    <hr />
    <div class="AddNewComment">Add</div>
  </div>
</template>

<script lang="ts">
import ReviewService from "@/services/review-service.ts";
import IReview from "@/types/Review.d.ts";
import Vue from "vue";
import Component from "vue-class-component";
import Review from "@/components/Review.vue";
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";

const reviewService = new ReviewService();
@Component({
  props: ["FilmId"],
  name: "Reviews",
  components: { Review },
})
export default class Reviews extends Vue {
  ReviewsList: IReview[] = [];
  getReviewsCount() {
    return this.ReviewsList.length;
  }
  async getAllReviews() {
    await reviewService
      .getAllReviews(this.$props["FilmId"])
      .then((data) => (this.ReviewsList = data))
      .catch((err) => console.error(err));
    console.log(this.ReviewsList, "1111111111s");
    console.log(this.ReviewsList.length, "222222");
  }
  created() {
    console.log(this.$props["FilmId"], "id фильма");
    this.getAllReviews();
  }
}
</script>

<style lang="scss">
.ComentsField {
}
.ListOfComments {
}
.Review-form-to-write {
}
.Button-submit {
}
</style>
