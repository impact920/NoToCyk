using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet; // Prefab pocisku
    public Transform firePoint; // Punkt, z którego bêdzie strzela³ gracz
    public float bulletSpeed = 10f; // Prêdkoœæ pocisku

    void Update()
    {
        // Strzelanie po wciœniêciu klawisza (np. spacja lub lewy przycisk myszy)
        if (Input.GetKeyDown(KeyCode.Space)) // Mo¿esz zmieniæ klucz na inny
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

            // Dodajemy si³ê pociskowi (jeœli ma Rigidbody2D)
            Rigidbody2D rb = spawnedBullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.left * bulletSpeed; // Pocisk porusza siê w prawo
            }
        }
    }
}
