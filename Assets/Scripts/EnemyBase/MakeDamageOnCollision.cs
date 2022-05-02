using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
    public int damageValue = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody) {
            HeroHealth heroHealth = collision.rigidbody.GetComponent<HeroHealth>();
            if (heroHealth) {
                heroHealth.TakeDamage(damageValue);
            }
        }
    }
}
