export const colorCode = (color:Color): number =>
  COLORS.indexOf(color);

type Color = typeof COLORS[number]

export const COLORS =
  [ 'black', 'brown', 'red', 'orange', 'yellow', 'green', 'blue', 'violet', 'grey', 'white' ] as const

export const decodedResistorValue = (colors: Color[]): string => {
  const number = (10 * colorCode(colors[0]) + colorCode(colors[1]))
  const zeros = colorCode(colors[2])

  switch(zeros) {
    case 2: case 3: case 4:
      return `${number * (10 ** (zeros-3))} kiloohms`
    case 5: case 6: case 7:
      return `${number * (10 ** (zeros-6))} megaohms`
    case 8: case 9:
      return `${number * (10 ** (zeros-9))} gigaohms`
    default:
      return `${number * (10 ** zeros)} ohms`;
  };
}
