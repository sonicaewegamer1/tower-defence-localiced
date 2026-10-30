
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [Header("Tower Stats")]
    [SerializeField] protected float maxHealth = 100f;

    [Header("Health UI")]
    [SerializeField] private Healthbar healthBar;
    [SerializeField] private Barhold barhold;

    protected float currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log(gameObject.name + " received " + damage + " damage.");

        if (healthBar != null)
            healthBar.UpdateHealthBar(currentHealth, maxHealth);

        if (barhold != null)
            barhold.Show();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log(gameObject.name + " has been destroyed.");

        Destroy(gameObject);
    }
}
