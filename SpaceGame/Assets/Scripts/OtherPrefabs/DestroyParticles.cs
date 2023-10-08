using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour
{
    void Start()
    {
        Invoke("Destroy", 2f);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
