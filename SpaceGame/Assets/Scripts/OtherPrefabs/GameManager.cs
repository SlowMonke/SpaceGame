using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float cooldownOnPiercing = 0f;
    public static float cooldownOnDelay = 0f;
    public static float cooldownOnDoubleShot = 0f;
    public static int health = 3;
    public static int healthboss = 100;

    void Start()
    {
        health = 3;
        cooldownOnPiercing = 0f;
        cooldownOnDelay = 0f;
        cooldownOnDoubleShot = 0f;
        healthboss = 100;
}

    void Update()
    {
        cooldownOnPiercing -= Time.deltaTime;
        cooldownOnDelay -= Time.deltaTime;
        cooldownOnDoubleShot -= Time.deltaTime;
    }
}
