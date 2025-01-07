using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class aldeano1 : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed;
    public int coin;
    public int ammo;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public int life;
    public bool ground;
    public float jumpforce;
    public float direction;
    public static int score;
    public AudioSource audioSource;
    public AudioClip jumpClip;
    public AudioClip Ataque_distanciaClip;
    public AudioClip coinClip;
    public AudioClip Ataque_MeleeClip;
    public AudioClip AmmoClip;
    public BulletManager bulletManager;
    public MonedaManager monedaManager;
    public float timer;
    public float maxTimer;
    public ClockManager clockManager;
    public CoinManager coinManager;
    public static float time;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        bulletManager = GameObject.Find("BulletText").GetComponent<BulletManager>();
        bulletManager.SetBullet(ammo);
        monedaManager = GameObject.Find("MonedaText").GetComponent<MonedaManager>();
        monedaManager.SetMoneda(coin);
        coinManager = GameObject.Find("CoinText").GetComponent<CoinManager>();
        coinManager.SetCoin(coin);
        //score = 0;
        //time = 0; 
    }

    void Update()
    {
        Shoot();
        Move();
        Jump();
        aldeano1.time += Time.deltaTime;
    }

    void Jump()
    {
        if (ground && Input.GetKeyDown(KeyCode.Space) && Time.timeScale>0)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, jumpforce));
            audioSource.PlayOneShot(jumpClip);
        }
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0)
        {
            direction = 1;
        }

        else if (horizontal < 0)
        {
            direction = -1;
        }

        Vector3 scale = transform.localScale;
        if (direction < 0)
        {
            scale.x = -2;
        }
        else
        {
            scale.x = 2;
        }
        transform.localScale = scale;

        rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);
    }

    void ChangeCoin(int value)
    {
        coin += value;
        monedaManager.SetMoneda(coin);
    }
 
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.X) && ammo >= 1 && Time.timeScale > 0)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.transform.position = transform.position;
            Vector2 d = obj.GetComponent<bala>().direction;
            d.x = direction;
            obj.GetComponent<bala>().direction = d;   
            ammo--;
            bulletManager.SetBullet(ammo);
            audioSource.PlayOneShot(Ataque_distanciaClip);
        }

        if (Input.GetKeyDown(KeyCode.Z) && Time.timeScale > 0)
        {
            GameObject obj = Instantiate(bulletPrefab2);
            obj.transform.position = transform.position;
            Vector2 d = obj.GetComponent<meele>().direction;
            d.x = direction;
            obj.GetComponent<meele>().direction = d;
            audioSource.PlayOneShot(Ataque_MeleeClip);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            ChangeCoin(1);
            audioSource.PlayOneShot(coinClip);
        }

        if (collision.gameObject.CompareTag("Ammo"))
        {
            ammo++;
            bulletManager.SetBullet(ammo);
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(AmmoClip);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            life--;
            if (life <= 0)
            {
                SceneManager.LoadScene("Derrota");
            }
        }

        if (collision.gameObject.CompareTag("Enemy2"))
        {
            life--;
            if (life <= 0)
            {
                SceneManager.LoadScene("Derrota");
            }
        }

        if (collision.gameObject.CompareTag("Enemy3"))
        {
            life--;
            if (life <= 0)
            {
                SceneManager.LoadScene("Derrota");
            }
        }

        if (collision.gameObject.CompareTag("door"))
        {
            if (coin >= 5)
            {
                SceneManager.LoadScene("nivel2");
            }
        }

        if (collision.gameObject.CompareTag("blockdeath"))
        {
            life--;
            if (life <= 0)
            {
                time++;
                SceneManager.LoadScene("Derrota");
            }
        }

        if (collision.gameObject.CompareTag("enemybullet"))
        {
            life--;
            Destroy(collision.gameObject);
            if (life <= 0)
            {
                SceneManager.LoadScene("Derrota");
            }
        }
        if (collision.gameObject.CompareTag("Bruja"))
        {
            life--;
            if (life <= 0)
            {
                SceneManager.LoadScene("Derrota");
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ground = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ground = false;
        }
    }
}
