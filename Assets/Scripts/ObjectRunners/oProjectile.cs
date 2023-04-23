using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oProjectile : MonoBehaviour
{

    Rigidbody2D rb;

    public ProjectileObject projectileObj;
    private float elapsedTime = 0;

    private bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = transform.up * projectileObj.projectionSpeed * (canMove ? 1 : 0);

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= projectileObj.timerExpire)
        {
            DestroyObj();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == gameObject.tag) return;
        DestroyObj();
    }

    void DestroyObj()
    {
        canMove = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject, 5000f);
    }
}
