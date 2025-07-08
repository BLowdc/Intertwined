using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject[] projectile;
    private GameObject proj;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        proj = Instantiate(projectile[0], transform.position, Quaternion.identity);
    }
}
