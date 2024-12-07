export const isPangram = (input: string) =>
  new Set(Array.from(input.toLowerCase().matchAll(/[a-z]/g), m => m[0])).size === 26;
