export class DnDCharacter {
  public static generateAbilityScore(): number {
    return [...Array(4)].map(this.roll)
      .sort().slice(1).reduce((sum, x) => sum + x, 0);
  }

  public static getModifierFor(abilityValue: number): number {
    return Math.floor((abilityValue - 10) / 2)
  }

  private static roll (): number {
    return Math.floor(Math.random() * 6) + 1;
  }

  readonly strength: number = DnDCharacter.generateAbilityScore()
  readonly dexterity: number = DnDCharacter.generateAbilityScore()
  readonly constitution: number = DnDCharacter.generateAbilityScore()
  readonly intelligence: number = DnDCharacter.generateAbilityScore()
  readonly wisdom: number = DnDCharacter.generateAbilityScore()
  readonly charisma: number = DnDCharacter.generateAbilityScore()
  readonly hitpoints: number = 10 + DnDCharacter.getModifierFor(this.constitution)
}
