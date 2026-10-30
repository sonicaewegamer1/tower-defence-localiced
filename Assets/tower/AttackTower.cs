
using UnityEngine;

public class AttackTower : Tower
{
    [Header("Attack Settings")]
    [SerializeField] private float damage = 10f;
    [SerializeField] private float attackRate = 3f;

    [Header("Bullet Settings")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    private float nextAttackTime;

    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (firePoint == null || bulletPrefab == null) return;

        GameObject bulletObject = Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation
        );

        Bullet bullet = bulletObject.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Initialize(firePoint.forward, damage);
        }

        nextAttackTime = Time.time + attackRate;

        Debug.Log("Tower fired a bullet!");
    }
}
