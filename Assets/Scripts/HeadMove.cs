using UnityEngine;

public class HeadMove : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.position = target.position;
    }
}