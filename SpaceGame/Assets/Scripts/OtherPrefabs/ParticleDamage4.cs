using UnityEngine;

public class ParticleDamage4 : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage to apply on contact
    public Transform Hitbox;


    void Start()
    {
        Instantiate(Hitbox, Hitbox.position, Hitbox.rotation);
    }

    void Update()
    {
        if (GameManager.particleHealth4 >= 1)
        {
            Destroy(gameObject);
        }
    }
}
