/**
 * Abstract Class AbstractDataService
 * @class AbstractDataService
 */
export class AbstractDataService {
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
    products;

    /**
     * Получение продукта по id
     *
     * @param {number} id
     * @return {{
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
     *         }}
     * */
    // eslint-disable-next-line no-unused-vars
    getProductsById(id = null) {}
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
     * Получение заказов
     * @returns{{status:string; dateOfOrder:string; dateOfExecution:string; payment:string}[]}
     */
    async getOrders(){}

}
