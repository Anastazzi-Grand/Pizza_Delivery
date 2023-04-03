import { reactive } from 'vue';

export class BasketService {
    /**
     * @type Map<number, {id: number; price: number; count: number; property: {key: string; value: string}}>
     * */
    cart = reactive(new Map());

    /**
     * @type {{count: number; sum: number}}
     * */
    get total() {
        const result = {
            count: 0,
            sum: 0
        }
        this.cart.forEach(value => {
            result.count += value.count;
            result.sum += value.price;
        });
        return result;
    }
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
     *                         }[]
     *                     }[];
     *             price: number;
     *             image: string;
     *             cookingTime: string
     *         }} product
     *  @param {string | number[]} property
     * */
    addProductToBasket(product, property) {
        const markUp = this.calculateMarkUp(product, property)
        if (this.cart.has(product.id)) {
            this.cart.get(product.id).count += 1;
            this.cart.get(product.id).price = (product.price + markUp)*(this.cart.get(product.id).count);
            this.cart.get(product.id).property = property;
        } else {
            this.cart.set(product.id, {
                id: product.id,
                price: product.price + markUp,
                count: 1,
                property
            })
        }
    }

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
    *                         }[]
    *                     }[];
    *             price: number;
    *             image: string;
    *             cookingTime: string
    *         }} product
    *  @param {{key: string; name: string}[]} property
    * */
    removeProductFromBasket(product, property) {
        const markUp = this.calculateMarkUp(product, property)
        if (this.cart.has(product.id)) {
            this.cart.get(product.id).count -= 1;
            this.cart.get(product.id).price = (product.price + markUp)*(this.cart.get(product.id).count);
            this.cart.get(product.id).property = property;
        }
    }

    calculateMarkUp(product, property) {
        return product.property.reduce((acc, prop, index) => {
            acc += prop.options.find(o => o.key === property[index]).markUp;
            return acc
        },0)
    }
    constructor() {}

}
