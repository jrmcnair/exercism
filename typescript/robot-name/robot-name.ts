export class Robot {
  private static _allRobots: Set<string> = new Set()
  private _name: string

  constructor() {
    this._name = Robot.generateName()
  }

  public get name(): string {
    return this._name
  }

  public resetName(): void {
    this._name = Robot.generateName()
  }

  private static generateName () {
    const getNumber = (max: number) =>
        Math.floor(Math.random() * (max + 1));

    const getLetter = () =>
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ".charAt(getNumber(25))

    let name: string
    do {
      name = `${getLetter()}${getLetter()}${getNumber(9)}${getNumber(9)}${getNumber(9)}`;
    } while (Robot._allRobots.has(name))

    Robot._allRobots.add(name)
    return name
  }

  public static releaseNames(): void {
    this._allRobots.clear()
  }
}
