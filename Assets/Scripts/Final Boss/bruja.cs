using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bruja : MonoBehaviour
{
    public Rigidbody2D rb4d;
    public int life;
    public Vector2 direction;
    public int speed;
    public float timer;
    public float maxTimer; 
    private SpriteRenderer sPlayer;
    private Color colororiginal;
    public float timercolor;
    public float maxtimercolor;
    public bool colorchanged;

    public AudioSource audioSource;
    public AudioClip Brujaclip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb4d = GetComponent<Rigidbody2D>();
        sPlayer = GetComponent<SpriteRenderer>();
        colororiginal = sPlayer.color;
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
        timer += Time.deltaTime;
        if (timer >= maxTimer)
        {
            audioSource.PlayOneShot(Brujaclip);
            timer = 0;
        }
    }
    void ChangeLife(int value)
    {
        life += value;
        if (life <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Ganastes");
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
            Destroy(collision.gameObject);
            ChangeLife(-1);
        }

        if (collision.gameObject.CompareTag("trinche"))
        {
            colorchanged = true;
            Destroy(collision.gameObject);
            Color newcolor = new Color(255f / 255f, 100f / 255f, 100f / 255f);
            sPlayer.color = newcolor;
            timercolor = 0;
            Destroy(collision.gameObject);
            ChangeLife(-1);
        }
    }
}


