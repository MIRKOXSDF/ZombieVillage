using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textoadvertencia : MonoBehaviour
{
    public float TiempoDeVida;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TiempoDeVida -= Time.deltaTime;
        if (TiempoDeVida <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}