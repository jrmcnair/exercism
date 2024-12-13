export function commands(code: number) : string[] {
  let result =
      ['wink', 'double blink', 'close your eyes', 'jump']
          .reduce((acc: string[], action: string, i) =>
              ((2 ** i) & code) > 0 ? acc.concat(action) : acc, [])

  return (code & 16) > 0 ? result.reverse() : result
}
