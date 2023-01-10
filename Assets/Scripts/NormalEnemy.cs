using System.Collections;
using UnityEngine;
// INHERITANCE
public class NormalEnemy : Enemy
{
    private bool canAttack = true;
    // ABSTRACTION
    protected override void Attack()
    {
        if (canAttack)
        {
            var projectile = Instantiate(projectilePrefab, transform.position + Vector3.back, transform.rotation);
            projectile.GetComponent<Projectile>().damage = damage;
            StartCoroutine(AttackTimeout());
        }
    }

    private IEnumerator AttackTimeout()
    {
        canAttack = false;
        yield return new WaitForSeconds(1f);
        canAttack = true;
    }
}