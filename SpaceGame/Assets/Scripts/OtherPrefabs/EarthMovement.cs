using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthMovement : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;
    public Rigidbody2D rb;
    private Camera _camera;

    private void Update()
    {
        DestroyWhenOffScreen();
    }

    private void Awake()
    {
        _camera = Camera.main;
    }

    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.GetType() == typeof(PolygonCollider2D))
        {
            EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Score.scoreValue += 5;
            }
            Destroy(gameObject);
        }
        if (hitInfo.CompareTag("Player"))
        {
            PlayerHealth Player = hitInfo.GetComponent<PlayerHealth>();

            if (Player != null)
            {
                Player.TakeDamage(1);

            }
            Destroy(gameObject);
        }
        if (hitInfo.GetType() == typeof(PolygonCollider2D))
        {
            EnemyScore1 enemy = hitInfo.GetComponent<EnemyScore1>();
            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }
            Destroy(gameObject);
        }
        if (hitInfo.GetType() == typeof(PolygonCollider2D))
        {
            EnemyScore2 enemy = hitInfo.GetComponent<EnemyScore2>();
            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }
            Destroy(gameObject);
        }
    }

    private void DestroyWhenOffScreen()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0 ||
           screenPosition.x > _camera.pixelWidth ||
           screenPosition.y < 0 ||
           screenPosition.y > _camera.pixelHeight)
        {
            Destroy(gameObject);
        }
    }

}