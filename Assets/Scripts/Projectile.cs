using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int m_Damage;
    private float speed = 30f;
    private float verticalBoundaries = 50f;

    // ENCAPSULATION
    public int damage
    {
        get { return m_Damage; }
        set
        {
            if (value < 1)
            {
                Debug.LogError("You can't set a negative damage!");
            }
            else
            {
                m_Damage = value; // original setter now in if/else statement
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckPosition();
    }

    private void CheckPosition()
    {
        if (transform.position.z > verticalBoundaries || transform.position.z < -verticalBoundaries)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        var health = other.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(m_Damage);
            Destroy(gameObject);
        }
    }
}