using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class aldeano4 : MonoBehaviour
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
    public AudioClip Ataque_MeleeClip;
    public AudioClip AmmoClip;
    public BulletManager4 bulletManager4;
    public float timer;
    public float maxTimer;
    public static float time;
    public ClockManager clockManager;
    public CoinManager4 coinManager4;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        bulletManager4 = GameObject.Find("BulletText4").GetComponent<BulletManager4>();
        bulletManager4.SetBullet(ammo);
        coinManager4 = GameObject.Find("CoinText4").GetComponent<CoinManager4>();
        coinManager4.SetCoin(coin);
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
        if (ground && Input.GetKeyDown(KeyCode.Space) && Time.timeScale > 0)
        {
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
            bulletManager4.SetBullet(ammo);
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

        if (collision.gameObject.CompareTag("Ammo"))
        {
            ammo++;
            bulletManager4.SetBullet(ammo);
            Destroy(collision.gameObject);
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
