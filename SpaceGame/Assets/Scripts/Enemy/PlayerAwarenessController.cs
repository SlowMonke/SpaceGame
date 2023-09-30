using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set;  }
    public float avoidanceRadius = 2f;
    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float _playerAwarenessDistance;

    private Transform _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        if (_player != null)
        {
            Vector2 enemyToPlayerVector = _player.position - transform.position;
            

            if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance)
            {
                AwareOfPlayer = true;
            }
            else
            {
                AwareOfPlayer = false;
            }
        }

        if (_player != null)
        {
            // Calculate the direction towards the player
            Vector2 direction = ((Vector2)_player.position - (Vector2)transform.position).normalized;

            // Check for nearby enemies to avoid
            Collider2D[] nearbyEnemies = Physics2D.OverlapCircleAll(transform.position, avoidanceRadius);

            Vector2 avoidanceDirection = Vector2.zero;

            foreach (Collider2D enemy in nearbyEnemies)
            {
                if (enemy != null && enemy.gameObject != this.gameObject)
                {
                    avoidanceDirection += ((Vector2)transform.position - (Vector2)enemy.transform.position).normalized;
                }
            }

            // Combine the direction towards the player and the avoidance direction
            Vector2 combinedDirection = direction + avoidanceDirection.normalized;
            DirectionToPlayer = direction + avoidanceDirection.normalized;
        }
    }
}
