/// <reference path="./global.d.ts" />
//
// @ts-check

/**
 * Determine the price of the pizza given the pizza and optional extras
 *
 * @param {Pizza} pizza name of the pizza to be made
 * @param {Extra[]} extras list of extras
 *
 * @returns {number} the price of the pizza
 */
function getPrice(option) {
  switch (option) {
    case 'Margherita':
      return 7;
    case 'Caprese':
      return 9;
    case 'Formaggio':
      return 10;
    case 'ExtraSauce':
      return 1;
    case 'ExtraToppings':
      return 2;
    default:
      return 0;
  }
}

export function pizzaPrice(pizza, ...extras) {
  if (extras.length > 0) {
    return getPrice(extras.pop()) + pizzaPrice(pizza, ...extras);
  } else {
    return getPrice(pizza);
  }
}

/**
 * Calculate the price of the total order, given individual orders
 *
 * (HINT: For this exercise, you can take a look at the supplied "global.d.ts" file
 * for a more info about the type definitions used)
 *
 * @param {PizzaOrder[]} pizzaOrders a list of pizza orders
 * @returns {number} the price of the total order
 */
export function orderPrice(pizzaOrders) {
  let tot = 0;
  while (pizzaOrders.length > 0) {
    const order = pizzaOrders.pop();
    tot += pizzaPrice(order.pizza, ...order.extras);
  }
  return tot;
}
