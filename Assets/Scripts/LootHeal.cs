using UnityEngine;

public class LootHeal : MonoBehaviour
{
    public int hpValue = 1;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        HeroHealth heroHealth = other.attachedRigidbody.GetComponent<HeroHealth>();
        if (heroHealth) {
            heroHealth.AddHealth(hpValue);
            Destroy(gameObject);
        }
    }
}
