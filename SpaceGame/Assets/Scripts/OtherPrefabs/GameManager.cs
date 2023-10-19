using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float cooldownOnPiercing = 0f;
    public static float cooldownOnDelay = 0f;
    public static float cooldownOnDoubleShot = 0f;
    public static int health = 3;
    public static int healthboss = 100;
    public static float particleHealth1 = 0f;
    public static float particleHealth2 = 0f;
    public static float particleHealth3 = 0f;
    public static float particleHealth4 = 0f;

    void Start()
    {
        health = 3;
        cooldownOnPiercing = 0f;
        cooldownOnDelay = 0f;
        cooldownOnDoubleShot = 0f;
        particleHealth1 = 0f;
        particleHealth2 = 0f;
        particleHealth3 = 0f;
        particleHealth4 = 0f;
        healthboss = 100;
}

    void Update()
    {
        cooldownOnPiercing -= Time.deltaTime;
        cooldownOnDelay -= Time.deltaTime;
        cooldownOnDoubleShot -= Time.deltaTime;
    }
}
