using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;
    private Camera _camera;
    public GameObject deathEffect;
    public bool piercingActivated = false;
    public Weapon cooldownOnPiercing;

    private void Update()
    {
        DestroyWhenOffScreen();
        if (GameManager.cooldownOnPiercing >= 1)
        {
            piercingActivated = true;
        }
        else
        {
            piercingActivated = false;
        }
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
        if (piercingActivated == true)
        {
            if (hitInfo.GetType() == typeof(PolygonCollider2D))
            {
                EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
                if (enemy != null)
                {
                    enemy.TakeDamage(1);
                }
                //Destroy(gameObject);
                Instantiate(deathEffect, transform.position, transform.rotation);
                //Destroy(gameObject);
            }
            if (hitInfo.GetType() == typeof(PolygonCollider2D))
            {
                EnemyScore1 enemy = hitInfo.GetComponent<EnemyScore1>();
                if (enemy != null)
                {
                    enemy.TakeDamage(1);
                }
                //Destroy(gameObject);
                Instantiate(deathEffect, transform.position, transform.rotation);
                //Destroy(gameObject);
            }
            if (hitInfo.GetType() == typeof(PolygonCollider2D))
            {
                EnemyScore2 enemy = hitInfo.GetComponent<EnemyScore2>();
                if (enemy != null)
                {
                    enemy.TakeDamage(1);
                }
                //Destroy(gameObject);
                Instantiate(deathEffect, transform.position, transform.rotation);
                //Destroy(gameObject);
            }
            if (hitInfo.GetType() == typeof(PolygonCollider2D))
            {
                EnemyScore3 enemy = hitInfo.GetComponent<EnemyScore3>();
                if (enemy != null)
                {
                    enemy.TakeDamage(1);
                }
                //Destroy(gameObject);
                Instantiate(deathEffect, transform.position, transform.rotation);
                //Destroy(gameObject);
            }
            if (hitInfo.GetType() == typeof(PolygonCollider2D))
            {
                EnemyScore4 enemy = hitInfo.GetComponent<EnemyScore4>();
                if (enemy != null)
                {
                    enemy.TakeDamage(1);
                }
                //Destroy(gameObject);
                Instantiate(deathEffect, transform.position, transform.rotation);
                //Destroy(gameObject);
            }
        }
        else
        {
            if (hitInfo.GetType() == typeof(PolygonCollider2D))
            {
                EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
                if (enemy != null)
                {
                    enemy.TakeDamage(1);
                }
                Destroy(gameObject);
                Instantiate(deathEffect, transform.position, transform.rotation);
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
                Instantiate(deathEffect, transform.position, transform.rotation);
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
                Instantiate(deathEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            if (hitInfo.GetType() == typeof(PolygonCollider2D))
            {
                EnemyScore3 enemy = hitInfo.GetComponent<EnemyScore3>();
                if (enemy != null)
                {
                    enemy.TakeDamage(1);
                }
                Destroy(gameObject);
                Instantiate(deathEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            if (hitInfo.GetType() == typeof(PolygonCollider2D))
            {
                EnemyScore4 enemy = hitInfo.GetComponent<EnemyScore4>();
                if (enemy != null)
                {
                    enemy.TakeDamage(1);
                }
                Destroy(gameObject);
                Instantiate(deathEffect, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }

        if (hitInfo.CompareTag("PowerUp"))
        {
            GameManager.cooldownOnPiercing = 10;
        }

        if (hitInfo.CompareTag("PowerUp2"))
        {
            GameManager.cooldownOnDelay = 10;
        }

        if (hitInfo.CompareTag("PowerUp3"))
        {
            GameManager.cooldownOnDoubleShot = 10;
        }

        if (hitInfo.CompareTag("Heart"))
        {
            GameManager.health += 1;
        }
    }

    private void DestroyWhenOffScreen()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if(screenPosition.x < 0 ||
           screenPosition.x > _camera.pixelWidth ||
           screenPosition.y < 0 ||
           screenPosition.y > _camera.pixelHeight)
        {
            Destroy(gameObject);
        }
    }

}