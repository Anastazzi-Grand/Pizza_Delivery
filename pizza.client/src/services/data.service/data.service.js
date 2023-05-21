import { AbstractDataService } from "./abstract.data.service";
import axios from 'axios';

export class DataService extends AbstractDataService {
    async getProducts(){
        console.log('getProducts')
        return axios.get(`${process.env.VUE_APP_API_URL}/products`).then(res => res.data).catch(err => console.error(err));
    }
    async gerOrders(){}
    async createOrder(order){
        console.log(order)
        return axios.get(process.env.VUE_APP_API_URL).then(res => res.data).catch(err => console.error(err));
    }
}
