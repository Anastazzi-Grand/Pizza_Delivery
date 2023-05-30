import axios from 'axios';

export class OrderService {
    /**
     * Оформление заказа
     * @param {{
     * fullName: string;
     * phoneNumber: string;
     * address: string;
     * order: {
     *     orderCreateDate: string;
     *     deliveryDate: string;
     *     totalPrice: number;
     *     products: {
     *         id: number;
     *     }[];
     *  }
     * }} data
     */
    async createOrder(data) {
        return axios.post(`/api/order`, data).then(res => {
            return res.data;
        }).catch(err => console.error(err));
    }
}
