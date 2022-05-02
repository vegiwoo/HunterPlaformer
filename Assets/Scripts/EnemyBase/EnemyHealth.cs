using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int hp;

    public void TakeDamage(int damageValue) {
        hp -= damageValue;

        if (hp <= 0) {
            Die();
        }
    }

    public void Die() {
        Destroy(gameObject);
    }


}