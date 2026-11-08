using UnityEngine;

public class SniperTower : MonoBehaviour
{
    [SerializeField] private int cooldown = 8;
    [SerializeField] private Transform shootPos;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int CritReq = 15;
    [SerializeField] private float flatDamage = 30;

    private int numRandom;

    private float nextShot;

    private void Update()
    {
        if (Time.time >= nextShot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, shootPos.position, shootPos.rotation);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        numRandom = Random.Range(0, 21);
        if(numRandom==CritReq)
        {
            bullet.Initialize(shootPos.forward, flatDamage*2);
            nextShot = Time.time + cooldown;
        }
        else
        {
            bullet.Initialize(shootPos.forward, flatDamage);
            nextShot = Time.time + cooldown;
        }
    }
}
