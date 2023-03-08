export class BasketService {
    /**
     * @type Map<number, {id: number; price: number; count: number; property: {key: string; value: string}[]}>
     * */
    basket;
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
    addProductToBasket(product, property) {
        const markUp = this.calculateMarkUp(product, property)
        if (this.basket.has(product.id)) {
            this.basket.get(product.id).count += 1;
            this.basket.get(product.id).price += (product.price + markUp)*(this.basket.get(product.id).count);
            this.basket.get(product.id).property = property;
        } else {
            this.basket.set(product.id, {
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
        if (this.basket.has(product.id)) {
            this.basket.get(product.id).count -= 1;
            this.basket.get(product.id).price -= (product.price + markUp)*(this.basket.get(product.id).count);
            this.basket.get(product.id).property = property;
        }
    }

    calculateMarkUp(product, property) {
        return product.property.reduce((acc, prop) => {
            property.filter(e => e.name === prop.name).forEach(p => {
                prop.options.forEach(f => {
                    if (f.key === p.key) { acc += f.markUp }
                })
            })
            return acc
        },0)
    }
    constructor() {
        this.basket = new Map();
    }

}
