using UnityEngine;


[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class SO_Stats : ScriptableObject
{
    [Header("Movement")]
    public float movementVelocity;

    [Header("Life")]
    public float maxLife;
    public float currentLife;

    [Header("Combat")]
    public float maxDistanceRayDamage;
    public float timeBetweenHit;
    public float lastTimeShoot;

}
