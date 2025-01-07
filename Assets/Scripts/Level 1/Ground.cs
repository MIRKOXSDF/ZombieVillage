using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("enemybullet"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("enemybullet"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Ammo"))
        {
            Destroy(collision.gameObject);
        }

    }
}

       