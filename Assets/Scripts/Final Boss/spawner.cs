using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public float timer;
    public float maxTimer;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        timer += Time.deltaTime;
        if (timer >= maxTimer)
        {
            GameObject obj;
            switch (Random.Range(1, 4))//me va a dar el numero 1 o 2
            {
                case 1:
                    obj = Instantiate(enemyPrefab1);
                    obj.transform.position = transform.position;
                    timer = 0;
                    break;
                case 2:
                    obj = Instantiate(enemyPrefab2);
                    obj.transform.position = transform.position;
                    timer = 0;
                    break;

                case 3:
                    obj = Instantiate(enemyPrefab3);
                    obj.transform.position = transform.position;
                    timer = 0;
                    break;
            }
        }
    }
}