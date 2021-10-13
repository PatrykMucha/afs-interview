namespace AFSInterview
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BurstTower : Tower
    {
        [SerializeField] protected float _bulletsPerShoot = 3f;
        [SerializeField] protected float _timeBetweenBullet = 0.25f;

        protected override void Shoot(Enemy targetEnemy)
        {
            StartCoroutine(FireBullets(targetEnemy));
        }

        private IEnumerator FireBullets(Enemy targetEnemy)
        {
            Vector3 enemyposition = targetEnemy.transform.position;
            for (int i = 0; i < _bulletsPerShoot; i++)
            {
                if (targetEnemy != null)
                    enemyposition = targetEnemy.transform.position;

                FireBullet(enemyposition);
                yield return new WaitForSeconds(_timeBetweenBullet);
            }
        }

        private void FireBullet(Vector3 position)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation).GetComponent<RigibodyBullet>();
            var launchData = Utility.CalculateLaunchData(position, bulletSpawnPoint.position, 1.5f);
            bullet.Initialize(launchData.initialVelocity);
        }
    }
}
