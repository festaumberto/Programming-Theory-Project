using System.Collections;
using UnityEngine;
// INHERITANCE
public class HeavyEnemy : Enemy
{
    private bool canAttack = true;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }


    // ABSTRACTION
    protected override void Attack()
    {
        if (canAttack)
        {
            var projectile = Instantiate(projectilePrefab, transform.position + new Vector3(0, 0, -3),
                transform.rotation);
            projectile.transform.LookAt(player.transform);
            projectile.GetComponent<Projectile>().damage = damage;

            StartCoroutine(AttackTimeout());
        }
    }

    private IEnumerator AttackTimeout()
    {
        canAttack = false;
        yield return new WaitForSeconds(2f);
        canAttack = true;
    }
}