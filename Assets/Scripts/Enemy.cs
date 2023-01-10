using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// INHERITANCE
public abstract class Enemy : Health
{
    [SerializeField]
    protected int points;
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected GameObject projectilePrefab;
    [SerializeField]
    private float verticalBoundaries = 40f;

    // ABSTRACTION
    protected abstract void Attack();

    // POLYMORPHISM
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (health <= 0)
        {
            GameManager.Instance.AddScore(points);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
        CheckPosition();
    }
    
    private void CheckPosition()
    {
        if (transform.position.z > verticalBoundaries || transform.position.z < -verticalBoundaries)
        {
            Destroy(gameObject);
        }
    }
    
    
    public virtual void Move()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }
}
