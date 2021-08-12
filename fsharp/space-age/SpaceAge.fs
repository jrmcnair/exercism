module SpaceAge

type Planet =
    | Mercury
    | Venus
    | Earth
    | Mars
    | Jupiter
    | Saturn
    | Uranus
    | Neptune

let earthSeconds = float 31557600

let computeAge (seconds: int64) (factor: float) =
    let earthYears = (float seconds) / earthSeconds
    earthYears / factor

let age (planet: Planet) (seconds: int64): float =
    match planet with
    | Mercury -> computeAge seconds 0.2408467
    | Venus -> computeAge seconds 0.61519726
    | Earth -> computeAge seconds 1.
    | Mars -> computeAge seconds 1.8808158
    | Jupiter -> computeAge seconds 11.862615
    | Saturn -> computeAge seconds 29.447498
    | Uranus -> computeAge seconds 84.016846
    | Neptune -> computeAge seconds 164.79132
