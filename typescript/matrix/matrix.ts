export class Matrix {

  private readonly _rows: number[][];
  private readonly _cols: number[][];

  constructor(input: string) {
    this._rows = input.split('\n').map(row => row.split(' ').map(Number));
    this._cols = this._rows[0].map((_, col) =>
        this.rows.map(row => row[col]))
  }

  get rows(): number[][] {
    return this._rows;
  }

  get columns(): number[][] {
    return this._cols;
  }
}
