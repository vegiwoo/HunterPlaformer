using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    private EnemyHealth enemyHealth;

    private void Awake()
    {
        enemyHealth = gameObject.GetComponent<EnemyHealth>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();

        if (rigidbody && rigidbody.GetComponent<Bullet>()) {
            enemyHealth.TakeDamage(1);
        }
    }
}
