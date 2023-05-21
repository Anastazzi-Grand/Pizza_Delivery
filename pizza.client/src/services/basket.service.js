import { reactive } from 'vue';

export class BasketService {
    /**
     * @type Map<number, {id: number; price: number; property: {id: number; name: string, option: {key: string, value: string, markUp: number}}[]}[]>
     * */
    cart = reactive(new Map());

    getProductFromCart(id) {
        this.cart.get(id);
    }

    /**
     * @type {{count: number; sum: number}}
     * */
    get total() {
        const result = {
            count: 0,
            sum: 0
        }
        this.cart.forEach(value => {
            result.count += value.length;
            value.forEach(p => {
                result.sum += (p.price + p.property.reduce((sum, pr) => sum += pr.option.markUp, 0));
            })
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
    addProductToBasket(product) {
        console.log(product)
        // const markUp = this.calculateMarkUp(product, property)
        if (!this.cart.has(product.id)) {
            this.cart.set(product.id, [])
        }
        const newProduct = {
            id: product.id,
            price: product.price,
            // изначально добавляем первую из списка опцию
            property: product.property.map(p => ({id: p.id, name: p.name, option: p.options[0]}))
        }
        this.cart.get(product.id).push(newProduct);
        // this.cart.get(product.id).count += 1;
        // this.cart.get(product.id).price = (product.price + markUp)*(this.cart.get(product.id).count);
        // this.cart.get(product.id).property = property;
        // if (this.cart.has(product.id)) {
        //     this.cart.get(product.id).count += 1;
        //     this.cart.get(product.id).price = (product.price + markUp)*(this.cart.get(product.id).count);
        //     this.cart.get(product.id).property = property;
        // } else {
        //     this.cart.get(product.id)
        //     this.cart.set(product.id, {
        //         id: product.id,
        //         price: product.price + markUp,
        //         count: 1,
        //         property
        //     })
        // }
    }

    /**
     * @param {number} product
    *  @param {{key: string; name: string}[] | undefined} property
    * */
    removeProductFromBasket(product, property = undefined) {
        if (!this.cart.has(product)) {
            return;
        }
        if (property === undefined) {
            this.cart.delete(product);
        }
        // const markUp = this.calculateMarkUp(product, property)
        // if (this.cart.has(product.id)) {
        //     this.cart.get(product.id).count -= 1;
        //     this.cart.get(product.id).price = (product.price + markUp)*(this.cart.get(product.id).count);
        //     this.cart.get(product.id).property = property;
        // }
    }

    calculateMarkUp(product, property) {
        return product.property.reduce((acc, prop, index) => {
            acc += prop.options.find(o => o.key === property[index]).markUp;
            return acc
        },0)
    }
    constructor() {}

}
