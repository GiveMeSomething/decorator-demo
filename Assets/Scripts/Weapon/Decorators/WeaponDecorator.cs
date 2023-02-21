public class WeaponDecorator : Weapon
{
  protected Weapon weapon;

  public WeaponDecorator(Weapon weapon)
  {
    this.weapon = weapon;
  }

  public virtual void Fire()
  {
    weapon.Fire();
  }
}