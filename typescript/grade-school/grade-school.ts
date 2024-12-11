export class GradeSchool {
  private readonly _roster: Map<number, string[]> = new Map()

  roster = () => Object.fromEntries(structuredClone(this._roster))
  grade = (num: number) => [...this._roster.get(num) ?? []]

  add = (name: string, grade: number) => {
    for (const [_, students] of this._roster) {
      if (students.includes(name)) students.splice(students.indexOf(name), 1)
    }

    const students = this._roster.get(grade) ?? []
    students.push(name)
    this._roster.set(grade, students.sort())
  }
}
