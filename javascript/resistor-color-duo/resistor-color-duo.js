//
// This is only a SKELETON file for the 'Resistor Color Duo' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export const colorCode = (color) => {
    return COLORS.indexOf(color);
};

export const COLORS = [
    "black",
    "brown",
    "red",
    "orange",
    "yellow",
    "green",
    "blue",
    "violet",
    "grey",
    "white"
];

export const decodedValue = (input) =>
    input.slice(0,2)
         .map(colorCode)
         .reduce((state, value) => (state * 10) + value);
