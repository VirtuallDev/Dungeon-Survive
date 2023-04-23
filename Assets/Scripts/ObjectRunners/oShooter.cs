using UnityEngine;
using System.Linq;

public class oShooter : MonoBehaviour
{

    [SerializeField]
    private Transform shooterObject;

    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private LayerMask enemiesMask;

    private float elapsedTime = 0f;

    private void Update()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), 5f, enemiesMask);
        if (enemies.Length == 0) return;

        Transform closestEnemy = enemies.OrderBy(obj => Vector3.Distance(obj.transform.position, transform.position)).FirstOrDefault().transform;


        // calculate shooting point by closest enemy's position
        float angle = AdvMath.AngleBetweenPoints(transform.position, closestEnemy.position);
        shooterObject.rotation = Quaternion.Euler(0, 0, angle + 90f);


        if (elapsedTime >= projectilePrefab.GetComponent<oProjectile>().projectileObj.timeBetweenShots)
        {

            Instantiate(projectilePrefab, shooterObject.position, shooterObject.rotation);
            elapsedTime = 0f;
        }

        elapsedTime += Time.deltaTime;
    }

}
