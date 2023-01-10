using System.Collections;
using UnityEngine;
using UnityEngine.UI;
// INHERITANCE
public class PlayerController : Health
{
    // Start is called before the first frame update


    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private Slider playerHealth;

    [SerializeField] private float speed = 20f;
    [SerializeField] private float xBoundaries = 10;
    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private float shootDelay = 0.2f;

    private bool canShoot = true;

    void Start()
    {
        playerHealth.maxValue = health;
        playerHealth.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsAlive())
        {
            return;
        }

        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Move()
    {
        if (transform.position.x > xBoundaries)
        {
            transform.position = new Vector3(xBoundaries, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xBoundaries)
        {
            transform.position = new Vector3(-xBoundaries, transform.position.y, transform.position.z);
        }

        float input = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * (speed * input * Time.deltaTime));
    }

    private void Shoot()
    {
        if (canShoot)
        {
            var projectileGameObjet =
                Instantiate(projectilePrefab, transform.position + Vector3.forward,
                    projectilePrefab.transform.rotation);
            projectileGameObjet.GetComponent<Projectile>().damage = damage;
            StartCoroutine(DelayShooting());
        }
    }

    IEnumerator DelayShooting()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }

    public bool IsAlive()
    {
        return health > 0;
    }

    // POLYMORPHISM
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        playerHealth.value = health;
        if (!IsAlive())
        {
            GameManager.Instance.GameOver();
        }
    }
}