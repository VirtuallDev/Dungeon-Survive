using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileObject", menuName = "Scripts/ScriptableObjects/Weapons/ProjectileObject", order = 1)]
public class ProjectileObject : ScriptableObject
{
    public string projectileHashName;
    public float timerExpire = 1f;
    public float projectionSpeed = 10f;

    public float timeBetweenShots = 2f;

}
