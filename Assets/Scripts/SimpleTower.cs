namespace AFSInterview
{
    using System.Collections.Generic;
    using UnityEngine;

    public class SimpleTower : Tower
    {
        protected override void Shoot(Enemy targetEnemy)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity).GetComponent<Bullet>();
            bullet.Initialize(targetEnemy.gameObject);
        }
    }
}
