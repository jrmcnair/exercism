
export function find(haystack: number[], needle: number): number {
  let min = 0
  let max = haystack.length - 1
  let i: number

  while (min <= max) {
    i = Math.floor((max + min) / 2)

    if (haystack[i] === needle) return i
      if (haystack[i] > needle) {
        max = i - 1
      } else {
        min = i + 1
      }
  }

  throw new Error('Value not in array')
}
