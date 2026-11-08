using UnityEngine;

abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] int maxHP=10;
    [SerializeField] int HP;
    [SerializeField] string playerTag = "Player";
    [SerializeField] string playerBaseTag = "Player";
    public virtual void Start()
    {
        HP = maxHP;
    }
    public virtual void Move() { }
    public virtual void Shoot() { }
}
