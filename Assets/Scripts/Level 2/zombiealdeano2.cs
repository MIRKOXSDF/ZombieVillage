using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiealdeano2 : MonoBehaviour
{
    public Rigidbody2D rb4d;
    public float life;
    public Vector2 direction;
    public float speed;
    public float directionTimer;
    public float maxDirectionTimer;
    public AudioSource audioSource;
    public AudioClip zombieClip;
    public GameObject player;
    public float timer;
    public float maxTimer;
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
        player = GameObject.Find("aldeano2");
        audioSource = GetComponent<AudioSource>();
        rb4d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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

    void Move()
    {
        rb4d.velocity = direction * speed;

        directionTimer += Time.deltaTime;

        if (directionTimer >= maxDirectionTimer)
        {
            direction *= -1;
            directionTimer = 0;
        }
        if (player)
        {
            if (Vector2.Distance(player.transform.position, transform.position) < 9)
            {
                timer += Time.deltaTime;
                if (timer >= maxTimer)
                {
                    if (!audioSource.isPlaying)
                    {
                        audioSource.clip = zombieClip;
                        audioSource.loop = true;
                        audioSource.Play();
                    }
                }
            }
            else
            {
                audioSource.Stop();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && Time.timeScale > 0)
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
                aldeano1.score += 50;
            }
        }
        if (collision.gameObject.CompareTag("trinche") && Time.timeScale > 0)
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
                aldeano1.score += 50;
            }
        }
    }
}





