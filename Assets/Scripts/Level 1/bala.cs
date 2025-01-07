using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Vector2 direction;
    public int speed;
    public float timer;
    public float MaxTimer;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        rb2d.velocity = direction * speed;
        timer += Time.deltaTime;
        if (timer >= MaxTimer)
        {
            Destroy(gameObject);
            timer = 0;
        }
    }
}

   
