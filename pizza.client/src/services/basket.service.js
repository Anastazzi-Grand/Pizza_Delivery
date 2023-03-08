export class BasketService {
    /**
     * @type Map<number, {id: number; price: number; count: number; property: {key: string; value: string}[]}>
     * */
    public basket;
    /**
     * @param {{
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
     *             cookingTime: string
     *         }} product
     *  @param {{key: string; value: string}[]} property
     * */
    addProductToOrder(product, property) {
        const markUp = product.property.reduce((acc, prop) => acc += p,0)
        if (this.basket.has(product.id)) {
            this.basket.get(product.id).count += 1;
            this.basket.get(product.id).price = product.price;
            this.basket.get(product.id).property = property;
        } else {
            this.basket.set(product.id, {
                id: product.id,
                price: product.price,
                count: 1,
                property
            })
        }
    }

    constructor() {
        this.basket = new Map();
    }

}
