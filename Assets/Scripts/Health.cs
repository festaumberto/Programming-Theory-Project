using UnityEngine;
// INHERITANCE
public class Health : MonoBehaviour
{
    [SerializeField]
    protected int health = 10;

    public virtual void TakeDamage(int damage)
    {
        Debug.Log(gameObject.name + " taking damage " + damage);
        health -= damage;
    }

    public int GetHealth()
    {
        return health;
    }
}