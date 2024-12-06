export const colorCode = (color:Color): number =>
  COLORS.indexOf(color);

type Color = typeof COLORS[number]

export const COLORS =
  [ 'black', 'brown', 'red', 'orange', 'yellow', 'green', 'blue', 'violet', 'grey', 'white' ] as const

