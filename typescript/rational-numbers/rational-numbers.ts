// adapted from https://www.geeksforgeeks.org/program-to-find-gcd-or-hcf-of-two-numbers/
function getGCD(a: number, b: number): number {
  a = Math.abs(a)
  b = Math.abs(b)

  if (a === 0) return b
  if (b === 0) return a
  if (a === b) return a

  return (a > b)
      ? getGCD(a - b, b)
      : getGCD(a, b - a)
}

export class Rational {
  private readonly _numerator: number
  private readonly _denominator: number

  constructor(a: number, b: number) {
    if (b === 0) throw new Error("cannot have a denominator of 0") 
    if (b < 0) { a = a * -1; b = b * -1 }

    const gcd = getGCD(a, b)
    this._numerator = a / gcd
    this._denominator = b / gcd
  }
  
  public get numerator(): number { return this._numerator }
  public get denominator(): number { return this._denominator }

  add(other: Rational): Rational {
    return new Rational(
        this.numerator * other.denominator + other.numerator * this.denominator,
        this.denominator * other.denominator
    )
  }

  sub(other: Rational): Rational {
    return new Rational(
        this.numerator * other.denominator - other.numerator * this.denominator,
        this.denominator * other.denominator
    )
  }

  mul(other: Rational): Rational {
    return new Rational(
        this.numerator * other.numerator,
        this.denominator * other.denominator
    )
  }

  div(other: Rational): Rational {
    if (other.numerator === 0 ) throw new Error("cannot divide if numerator is zero") 
    return new Rational(
        this.numerator * other.denominator,
        this.denominator * other.numerator
    )
  }

  abs(): Rational  {
    return new Rational(Math.abs(this.numerator), Math.abs(this.denominator))
  }

  exprational(n: number): Rational {
    return n >= 0
      ? new Rational(this.numerator ** n, this.denominator ** n)
      : new Rational(this.denominator ** Math.abs(n), this.numerator ** Math.abs(n))
  }

  expreal(n: number): number {
    return n ** (this.numerator / this.denominator)
  }

  reduce(): Rational {
    return this
  }
}
