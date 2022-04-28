using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    [Tooltip("Скорость следования"), Range(1,10)]
    public float followSpeed;

    private void Start() {
        followSpeed = 5;
    }

    void Update() {
        transform.position = Vector3.Lerp(transform.position, target.position, followSpeed * Time.deltaTime);
    }
}
