using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float cooldown2 = 2f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        cooldown2 -= Time.deltaTime;
        if (cooldown2 <= 0)
        {
            GameManager.particleHealth1 = 0f;
            GameManager.particleHealth2 = 0f;
            GameManager.particleHealth3 = 0f;
            GameManager.particleHealth4 = 0f;
            Destroy(gameObject);
        }
    }
}
