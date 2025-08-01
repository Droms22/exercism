// @ts-check
//
// The line above enables type checking for this file. Various IDEs interpret
// the @ts-check directive. It will give you helpful autocompletion when
// implementing this exercise.

/**
 * Calculates the total bird count.
 *
 * @param {number[]} birdsPerDay
 * @returns {number} total bird count
 */
export function totalBirdCount(birdsPerDay) {
  let c = 0;
  for (let i = 0; i < birdsPerDay.length; i++ ) {
      c += birdsPerDay[i];
  } 
  return c;
}

/**
 * Calculates the total number of birds seen in a specific week.
 *
 * @param {number[]} birdsPerDay
 * @param {number} week
 * @returns {number} birds counted in the given week
 */
export function birdsInWeek(birdsPerDay, week) {
  return totalBirdCount(birdsPerDay.splice((week - 1) * 7, 7));
}

/**
 * Fixes the counting mistake by increasing the bird count
 * by one for every second day.
 *
 * @param {number[]} birdsPerDay
 * @returns {number[]} corrected bird count data
 */
export function fixBirdCountLog(birdsPerDay) {
  birdsPerDay.forEach((value, index, arr) => {
    arr[index] = index % 2 === 0 ? value + 1 : value
  });
  return birdsPerDay;
}
