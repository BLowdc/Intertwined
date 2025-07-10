using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject[] projectile;
    private GameObject proj;
    private float cooldown = 0.5f;
    private float lastShot;

    void Start()
    {
        lastShot = Time.time;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && lastShot >= cooldown)
        {
            Shoot();
            lastShot = 0f;
        }
        lastShot += Time.deltaTime;
        // Debug.Log(lastShot);
    }

    private void Shoot()
    {
        proj = Instantiate(projectile[0], transform.position, Quaternion.identity);
    }
}
