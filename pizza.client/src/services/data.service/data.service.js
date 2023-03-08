import { AbstractDataService } from "./abstract.data.service";

export class DataService extends AbstractDataService {
    async getProducts(){}
    async gerOrders(){}
    async createOrder(order){
        return new Promise((res) => {
            return res(console.log(order))
        })
    }
}