//
// This is only a SKELETON file for the 'Two fer' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

// initial solution
//export const twoFer = (input) => `One for ${input ?? "you"}, one for me.`;

// final solution
export const twoFer = (input = "you") =>
    `One for ${input}, one for me.`;
