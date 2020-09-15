import IReview from "../types/Review"
import axios from "axios"

export default class ReviewService{
    API_URL=process.env.VUE_APP_API_URL;
 
    public async getAllReviews(id: number): Promise<IReview[]>{
        console.log(`${this.API_URL}/film/${id}/reviews`)
        const result=await axios.get(`${this.API_URL}/film/${id}/reviews`);
        console.log(result.data, "DARSAAAA")
        return result.data;
    }
}