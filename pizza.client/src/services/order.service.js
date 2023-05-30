import axios from 'axios';

export class OrderService {
    /**
     * Оформление заказа
     * @param {{
     * fullName: string;
     * phoneNumber: string;
     * address: string;
     * orderDate: string;
     * totalPrice: number;
    *  deliveryDate: string;
    *  productItems: {
    *       productId:number;
    *  }[];
     * }} data
     */
    async createOrder(data) {
        return axios.post(`/api/order`, data).then(res => {
            return res.data;
        }).catch(err => console.error(err));
    }
}
