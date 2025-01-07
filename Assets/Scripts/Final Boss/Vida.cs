using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    public float vida;
    public Slider BarraVida;
    public Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        BarraVida.value = vida;
        if (vida <= 0)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            vida--;
            BarraVida.value = vida;
            if (vida <= 0)
                Destroy(gameObject);
            Color newcolor = new Color(255f / 255f, 100f / 255f, 100f / 255f);
        }

        if (collision.gameObject.CompareTag("trinche"))
        {
            vida--;
            BarraVida.value = vida;
            if (vida <= 0)
                Destroy(gameObject);
            Color newcolor = new Color(255f / 255f, 100f / 255f, 100f / 255f);
        }
    }
}