using UnityEngine;

public class AimPointer : MonoBehaviour
{
    public Transform aim;
    public Camera gameCamera;
    GameObject hero;

    float yEuler;

    private void Awake()
    {
        hero = transform.parent.gameObject;
    }

    private void LateUpdate()
    {
        // Поворот оружия
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);

        Plane plane = new Plane(-Vector3.forward, Vector3.zero);

        float distance;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);

        aim.position = point;

        Vector3 toAim = aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);

        // Поворот персонажа
        yEuler = Mathf.Lerp(yEuler, toAim.x < 0 ? 45f : -45f, Time.deltaTime * 8);
        hero.transform.localEulerAngles = new Vector3(0, yEuler, 0);
    }
}