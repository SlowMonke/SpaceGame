using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float cooldownOnPiercing = 0f;
    public static float cooldownOnDelay = 0f;
    public static float cooldownOnDoubleShot = 0f;


    void Update()
    {
        cooldownOnPiercing -= Time.deltaTime;
        cooldownOnDelay -= Time.deltaTime;
        cooldownOnDoubleShot -= Time.deltaTime;
    }
}
