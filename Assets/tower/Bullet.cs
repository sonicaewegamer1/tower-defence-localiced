
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 5f;

    private float damage;
    private Vector3 direction;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void Initialize(Vector3 shootDirection, float bulletDamage)
    {
        direction = shootDirection.normalized;
        damage = bulletDamage;
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable target = other.GetComponentInParent<IDamageable>();

        if (target != null)
        {
            target.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
