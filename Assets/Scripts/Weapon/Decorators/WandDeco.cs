using UnityEngine;

public class WandDeco : WeaponDecorator
{
    private float shootDirecitonMultiplier = 1f;
    private readonly GameObject master;

    public WandDeco(Weapon weapon, GameObject master) : base(weapon)
    {
        this.master = master;
    }

    public override void Fire()
    {
        base.Fire();

        CastSpell();
    }

    private void CastSpell()
    {
        // Shoot additional bullet
        var magicPrefab = Resources.Load("Prefabs/Magic") as GameObject;

        // Shoot 3 with random angle
        for (int i = 0; i < 3; i++)
        {
            Vector3 offset = new(1, 0, 0);
            Bullet magic = Object
            .Instantiate(
                magicPrefab,
                master.transform.position + offset * shootDirecitonMultiplier,
                master.transform.rotation)
            .GetComponent<Bullet>();

            magic.Direction = Quaternion.AngleAxis(Random.Range(-10, 10), Vector3.forward) *
              Vector2.right *
              shootDirecitonMultiplier;
        }

        shootDirecitonMultiplier *= -1;
    }
}