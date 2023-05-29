import { AbstractDataService } from "./abstract.data.service";
import axios from 'axios';

export class DataService extends AbstractDataService {
    /**
     * @type {{
     *             id: number;
     *             group: string;
     *             name: string;
     *             property: {
     *                 name: string;
     *                 options: {
     *                     key: string;
     *                     value: string;
     *                     markUp: number;
     *                         }
     *                     }[];
     *             price: number;
     *             image: string;
     *             coockingTime: string
     *         }[]}
     * */
    #products = null;
    get products() {
        return this.#products;
    }

    getProductsById(id) {
        return this.#products.find(p => p.id === id);
    }
    async getProducts(){
        console.log('getProducts')
        return axios.get(`api/products`).then(res => {
            this.#products = res.data;
            return res.data;
        }).catch(err => console.error(err));
    }
    async gerOrders(){}
}
