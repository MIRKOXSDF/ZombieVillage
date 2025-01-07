using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meele: MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Vector2 direction;
    public int speed;
    public float timer;
    public float MaxTimer;
    // Start is called before the first frame update
    void Start()
    {
        if(direction.x <0)
        {
            transform.localScale = new Vector2(-0.5875226f, 1);
        }
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



