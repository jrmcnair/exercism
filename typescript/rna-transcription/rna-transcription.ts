export const RNAI_MAP = new Map([
  ['G', 'C'],
  ['C', 'G'],
  ['T', 'A'],
  ['A', 'U'],
]);

export const toRna = (dna:string): string =>
  dna.split('').map(x => {
    if (!RNAI_MAP.has(x)) throw 'Invalid input DNA.';
    return RNAI_MAP.get(x);
  }).join('');
