using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletCreator;
    public AudioSource shotSound;
    private GameObject shotFlash;

    public float bulletSpeed = 10f;
    public float shotPeriod = 0.2f;

    private float timer = default;

    private void Start() {
        shotSound.volume = 0.3f;

        shotFlash = bulletCreator.transform.GetChild(0).gameObject;
        shotFlash.SetActive(false);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > shotPeriod && Input.GetMouseButton(0))
        {
            timer = 0;
            GetShot();
        }
    }

    private void GetShot()
    {
        shotSound.pitch = Random.Range(0.8f, 1.2f);
        shotFlash.SetActive(true);
        shotSound.Play();
        GameObject newBullet = Instantiate(bulletPrefab, bulletCreator.position, bulletCreator.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = bulletCreator.forward * bulletSpeed;

        Invoke("HideFlash", 0.12f);
    }

    public void HideFlash() {
        shotFlash.SetActive(false);
    }
}
