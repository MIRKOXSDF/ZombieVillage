using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BulletManager2 : MonoBehaviour
{
    public Text bulletText;
    // Start is called before the first frame update
    void Start()
    {
        bulletText = GetComponent<Text>();
    }

    public void SetBullet(int bullet)
    {
        bulletText.text = " " + bullet;
    }
}