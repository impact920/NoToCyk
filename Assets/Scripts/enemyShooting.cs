using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet; // Prefab pocisku
    public Transform firePoint; // Punkt, z kt�rego b�dzie strzela� gracz
    public float bulletSpeed = 10f; // Pr�dko�� pocisku

    void Update()
    {
        // Strzelanie po wci�ni�ciu klawisza (np. spacja lub lewy przycisk myszy)
        if (Input.GetKeyDown(KeyCode.Space)) // Mo�esz zmieni� klucz na inny
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (bullet != null && firePoint != null)
        {
            // Tworzymy pocisk w pozycji gracza
            GameObject spawnedBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);

            // Dodajemy si�� pociskowi (je�li ma Rigidbody2D)
            Rigidbody2D rb = spawnedBullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.left * bulletSpeed; // Pocisk porusza si� w prawo
            }
        }
    }
}
