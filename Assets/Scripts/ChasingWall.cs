using UnityEngine;

public class ChasingWall : MonoBehaviour
{
    public Transform player; // Referencja do gracza
    public float moveSpeed = 2f; // Prêdkoœæ poruszania siê œciany
    public float stopDistance = 0.5f; // Odleg³oœæ, przy której œciana przestaje siê ruszaæ (opcja)

    void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player is not assigned to the Chasing Wall!");
            return;
        }

        // Oblicz odleg³oœæ do gracza
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Jeœli gracz jest poza dystansem stopDistance, poruszaj siê w jego kierunku
        if (distanceToPlayer > stopDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerAttacking>().TakeDamagePlayer(200);

        }
    }
}
