using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner2 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float timer;
    public float maxTimer;
    // Start is called before the first frame update
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        timer += Time.deltaTime;
        if (timer >= maxTimer)
        {
            GameObject obj = Instantiate(enemyPrefab);
            obj.transform.position = transform.position;
            timer = 0;
        }
    }
}