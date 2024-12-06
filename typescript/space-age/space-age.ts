const EARTH_YEAR_SECONDS = 31_557_600

interface IPlanetMap {
  [key: string]: number
}

const PlanetMap: IPlanetMap = {
  mercury: EARTH_YEAR_SECONDS * 0.2408467,
  venus: EARTH_YEAR_SECONDS * 0.61519726,
  earth: EARTH_YEAR_SECONDS,
  mars: EARTH_YEAR_SECONDS * 1.8808158,
  jupiter: EARTH_YEAR_SECONDS * 11.862615,
  saturn: EARTH_YEAR_SECONDS * 29.447498,
  uranus: EARTH_YEAR_SECONDS * 84.016846,
  neptune: EARTH_YEAR_SECONDS * 164.79132,
};

export type Planet = keyof typeof PlanetMap;

export const age = (planet: Planet, seconds: number): number =>
  Number((seconds / PlanetMap[planet]).toFixed(2));
