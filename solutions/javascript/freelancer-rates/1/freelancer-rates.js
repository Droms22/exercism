export function dayRate(ratePerHour) {
  return 8 * ratePerHour;
}

export function daysInBudget(budget, ratePerHour) {
  return Math.floor(budget / (8 * ratePerHour));
}

export function priceWithMonthlyDiscount(ratePerHour, numDays, discount) {
    const fullMonths = Math.floor(numDays / 22);
  const remainingDays = numDays % 22;
  const fullMonthPrice = fullMonths * 22 * dayRate(ratePerHour);
  return Math.ceil(fullMonthPrice - discount * fullMonthPrice + remainingDays * dayRate(ratePerHour))
}
