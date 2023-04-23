using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvMath : MonoBehaviour
{
    public static float AngleBetweenPoints(Vector3 a, Vector3 b) { return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg; }
    public static float PythegoreanMagnitude(float a, float b) { return Mathf.Sqrt(a * a + b * b); }

}
