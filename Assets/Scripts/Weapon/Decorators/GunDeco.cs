using UnityEngine;

public class GunDeco : WeaponDecorator
{
    private float shootDirecitonMultiplier = 1f;

    private readonly GameObject master;

    public GunDeco(Weapon weapon, GameObject master) : base(weapon)
    {
        this.master = master;
    }

    public override void Fire()
    {
        base.Fire();

        Shoot();
    }

    private void Shoot()
    {
        // Shoot additional bullet
        var bulletPrefab = Resources.Load("Prefabs/Bullet") as GameObject;
        Bullet bullet = Object
        .Instantiate(bulletPrefab, master.transform.position, master.transform.rotation)
        .GetComponent<Bullet>();

        bullet.Direction = Vector2.right * shootDirecitonMultiplier;
        shootDirecitonMultiplier *= -1;
    }
}