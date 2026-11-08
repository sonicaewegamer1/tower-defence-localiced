
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider healthBar;

    private void Awake()
    {
        if (healthBar == null)
            healthBar = GetComponent<Slider>();
    }

    public void UpdateHealthBar(float currentHp, float maxHp)
    {
        if (maxHp <= 0 || healthBar == null) return;

        healthBar.value = currentHp / maxHp;
    }
}
