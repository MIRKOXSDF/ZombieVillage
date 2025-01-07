using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDialogo : MonoBehaviour
{
    public GameObject TextoAdvertenciaPrefab;
    public int coin;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D cl)
    {
        if (cl.tag == "Player")
        {
            if (coin < 5)
            {
                GameObject texto = Instantiate(TextoAdvertenciaPrefab);
                texto.transform.position = new Vector3(this.gameObject.transform.position.x-6.3f,
                this.gameObject.transform.position.y+5.5f,
                this.gameObject.transform.position.z);
            }
            if (coin > 5)
            {
                Destroy(TextoAdvertenciaPrefab);
            }
        }
    }
}