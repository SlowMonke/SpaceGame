using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float cooldown2 = 2f;

    void Start()
    {
        cooldown2 = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown2 -= Time.deltaTime;
        if (cooldown2 <= 0)
        {
            Destroy(gameObject);
        }
    }
}
