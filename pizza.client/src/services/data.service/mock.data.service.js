import { AbstractDataService } from "./abstract.data.service";

export class MockDataService extends AbstractDataService {
    async getProducts(){
        return new Promise((resolve) => {
            setTimeout(() => {
              resolve([{
                id: 1,
                group: "Пицца",
                name: "Пепперони",
                property: [{
                        name: "Размер",
                        options: [{
                                key: "30",
                                value: "30 см",
                                markUp: 0,
                            }, {
                                key: "60",
                                value: "60 см",
                                markUp: 300,
                            }]
                    }],
                price: 500,
                image: "/images/pizza-pepperoni.png",
                cookingTime: "30 мин"
            }, {
                id: 2,
                group: "Пицца",
                name: "Маргарита",
                property: [{
                        name: "Размер",
                        options: [{
                                key: "30",
                                value: "30 см",
                                markUp: 0,
                            }, {
                                key: "60",
                                value: "60 см",
                                markUp: 300,
                            }]
                    }],
                price: 500,
                image: "/images/margherita.png",
                cookingTime: "30 мин"
            }, {
                id: 2,
                group: "Пицца",
                name: "4 сыра",
                property: [{
                        name: "Размер",
                        options: [{
                                key: "30",
                                value: "30 см",
                                markUp: 0,
                            }, {
                                key: "60",
                                value: "60 см",
                                markUp: 300,
                            }]
                    }],
                price: 500,
                image: "/images/pizza-goat-cheese.png",
                cookingTime: "30 мин"
            }, {
                id: 2,
                group: "Пицца",
                name: "Цыпленок барбекю",
                property: [{
                        name: "Размер",
                        options: [{
                                key: "30",
                                value: "30 см",
                                markUp: 0,
                            }, {
                                key: "60",
                                value: "60 см",
                                markUp: 300,
                            }]
                    }],
                price: 500,
                image: "/images/barbeku.png",
                cookingTime: "30 мин"
            }, {
                id: 2,
                group: "Пицца",
                name: "Мексиканская пицца",
                property: [{
                        name: "Размер",
                        options: [{
                                key: "30",
                                value: "30 см",
                                markUp: 0,
                            }, {
                                key: "60",
                                value: "60 см",
                                markUp: 300,
                            }]
                    }],
                price: 500,
                image: "/images/kisspng-california-style-pizza-sicilian-pizza-hawaiian-piz-hawaiian-pizza-5b15bd84002d61.5996858115281514280007.png",
                cookingTime: "30 мин"
            },
            {
                id: 3,
                group: "Бургер",
                name: "Бургер с курицей",
                property: [{
                        name: "Размер",
                        options: [{
                                key: "big",
                                value: "Большой",
                                markUp: 50,
                            }, {
                                key: "small",
                                value: "маленький",
                                markUp: 0,
                            }]
                    }],
                price: 150,
                image: "/images/chicken-sandwich.png",
                cookingTime: "20 мин"
            }, 
            {
                id: 3,
                group: "Бургер",
                name: "Бургер с говядиной",
                property: [{
                        name: "Размер",
                        options: [{
                                key: "big",
                                value: "Большой",
                                markUp: 50,
                            }, {
                                key: "small",
                                value: "маленький",
                                markUp: 0,
                            }]
                    }],
                price: 150,
                image: "/images/cheeseburger-beef.png",
                cookingTime: "20 мин"
            }]);
            }, 300);
          });
    }
    async gerOrders(){
        
    }
    async createOrder(order){
        return new Promise((res) => {
            return res(console.log(order))
        })
    }
}
