using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject effectPrefab;

    private void Start()
    {
        Destroy(gameObject, 4);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(effectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
