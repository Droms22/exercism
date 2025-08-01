/// <reference path="./global.d.ts" />
// @ts-check

/**
 * Implement the functions needed to solve the exercise here.
 * Do not forget to export them so they are available for the
 * tests. Here an example of the syntax as reminder:
 *
 * export function yourFunction(...) {
 *   ...
 * }
 */
export function cookingStatus(remainingTime) {
  if (remainingTime === undefined) {
    return 'You forgot to set the timer.';
  } else if (remainingTime === 0) {
    return 'Lasagna is done.';
  }
  return 'Not done, please wait.';
}

export function preparationTime(layers, avgLayerTime = 2) {
  return layers.length * avgLayerTime;
}

export function quantities(layers) {
  let noodles = 0;
  let sauce = 0;
  for (let i = 0; i < layers.length; i++) {
    if (layers[i] === 'sauce') {
      sauce += 0.2;
    } else if (layers[i] === 'noodles') {
      noodles += 50;
    }
  }
  return {
    noodles: noodles,
    sauce: sauce
  };
}

export function addSecretIngredient(friendList, myList) {
  myList.push(friendList[friendList.length-1]);
}

export function scaleRecipe(recipe, portions) {
  let newRecipe = {};
  for (let key in recipe) {
    newRecipe[key] = recipe[key] * (portions / 2);
  }
  return newRecipe;
}