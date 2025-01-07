using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombielady4 : MonoBehaviour
{
    public Rigidbody2D rb4d;
    public float life;
    public Vector2 direction;
    public float speed;
    public float timer;
    public float maxTimer;
    public GameObject bulletPrefab;
    public GameObject player;
    private SpriteRenderer sPlayer;
    private Color colororiginal;
    public float timercolor;
    public float maxtimercolor;
    public bool colorchanged;
    // Start is called before the first frame update
    void Start()
    {
        sPlayer = GetComponent<SpriteRenderer>();
        colororiginal = sPlayer.color;
        player = GameObject.Find("aldeano1");
        rb4d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
        if (colorchanged)
        {
            timercolor += Time.deltaTime;
            if (timercolor >= maxtimercolor)
            {
                sPlayer.color = colororiginal;
                colorchanged = false;
            }
        }
        else
        {
            colorchanged = false;
        }
    }

    void Shoot()
    {
        if (player)
        {
            if (Vector2.Distance(player.transform.position, transform.position) > 6)
            {
                timer += Time.deltaTime;
                if (timer >= maxTimer)
                {
                    GameObject obj = Instantiate(bulletPrefab);
                    obj.transform.position = transform.position;
                    if (player.transform.position.x > transform.position.x)
                    {
                        obj.GetComponent<enemybullet>().direction = new Vector2(1, 0);
                    }
                    else
                    {
                        obj.GetComponent<enemybullet>().direction = new Vector2(-1, 0);
                    }
                    timer = 0;
                }
            }

        }
    }

    void Move()
    {
        rb4d.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            colorchanged = true;
            Destroy(collision.gameObject);
            Color newcolor = new Color(255f / 255f, 100f / 255f, 100f / 255f);
            sPlayer.color = newcolor;
            timercolor = 0;
            life -= 0.5f;
            Destroy(collision.gameObject);
            if (life <= 0)
            {
                Destroy(gameObject);
                aldeano1.score += 70;
            }
        }

        if (collision.gameObject.CompareTag("trinche"))
        {
            colorchanged = true;
            Destroy(collision.gameObject);
            Color newcolor = new Color(255f / 255f, 100f / 255f, 100f / 255f);
            sPlayer.color = newcolor;
            timercolor = 0;
            life -= 1;
            Destroy(collision.gameObject);
            if (life <= 0)
            {
                Destroy(gameObject);
                aldeano1.score += 70;
            }
        }

        if (collision.gameObject.CompareTag("antideath"))
        {
            Destroy(gameObject);
        }
    }
}
