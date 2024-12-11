const MINUTES_IN_DAY = 60 * 24
const MINUTES_IN_HOUR = 60

export class Clock {
  private readonly _minutes: number
  
  constructor(hour: number, minute: number = 0) {
    const minutes = (hour * MINUTES_IN_HOUR + minute) % MINUTES_IN_DAY
    this._minutes = minutes < 0 ? MINUTES_IN_DAY + minutes : minutes
  }

  private hours = () =>
    `${String(Math.trunc(this._minutes / MINUTES_IN_HOUR)).padStart(2, '0')}`

  private minutes = () => 
    `${String(this._minutes % MINUTES_IN_HOUR).padStart(2, '0')}`
  
  public toString = () =>
    `${this.hours()}:${this.minutes()}`

  public plus = (minutes: number): Clock =>
    new Clock(0, this._minutes + minutes)

  public minus = (minutes: number): Clock =>
    new Clock(0, this._minutes - minutes)

  public equals = (other: Clock): boolean =>
    this.toString() === other.toString()
}
