/**
 * Abstract Class AbstractDataService
 * @class AbstractDataService
 */
export class AbstractDataService {
    /**
     * Получение продуктов из каталога
     * @returns{Promise<{
            id: number;
            group: string;
            name: string;
            property: {
                name: string;
                options: {
                    key: string;
                    value: string;
                    markUp: number;
                        }
                    }[];
            price: number;
            image: string;
            coockingTime: string
        }[]>}
     */
    async getProducts(){}
    /** 
     * Оформление заказа
     * @param {{id:number; count:number; property:{key:string,value:string}[]}[]} order 
     */
    async createOrder(order){
        return new Promise((res) => {
            return res(console.log(order))
        })
    }
    /**
     * Получение заказов
     * @returns{{status:string; dateOfOrder:string; dateOfExecution:string; payment:string}[]}
     */
    async getOrders(){}

}
