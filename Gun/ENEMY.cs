using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log(gameObject.name + " took damage. Remaining: " + health);

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
