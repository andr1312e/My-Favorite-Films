import IFilm from '@/types/Film';
import axios from 'axios'

export default class FilmService{
    API_URL=process.env.VUE_APP_API_URL;
    public async getAllFilms(): Promise<IFilm[]>{
        const result = await axios.get(`${this.API_URL}/films`)
        return result.data;
    } 

    public async AddNewFilm(film: IFilm){
        const result = await axios.post(`${this.API_URL}/films`, film)
        return result.data;
    }
    
    public async deleteFilmById(id: number){
        const result = await axios.delete(`${this.API_URL}/films/${id}`)
        return result.data;
    }
}