using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public float avoidanceRadius = 2f;
    public Rigidbody2D rb;
    public int damage = 1;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("Player not found. Make sure the player has the 'Player' tag.");
        }
    }

    private void Update()
    {
        if (player != null)
        {

            Vector2 direction = ((Vector2)player.position - (Vector2)transform.position).normalized;


            Collider2D[] nearbyEnemies = Physics2D.OverlapCircleAll(transform.position, avoidanceRadius);

            Vector2 avoidanceDirection = Vector2.zero;

            foreach (Collider2D enemy in nearbyEnemies)
            {
                if (enemy != null && enemy.gameObject != this.gameObject)
                {
                    avoidanceDirection += ((Vector2)transform.position - (Vector2)enemy.transform.position).normalized;
                }
            }


            Vector2 combinedDirection = direction + avoidanceDirection.normalized;


            transform.Translate(combinedDirection * moveSpeed * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth Player = hitInfo.GetComponent<PlayerHealth>();
        if (Player != null)
        {
            Player.TakeDamage(1);
            
        }
        Destroy(gameObject);
    }
}
