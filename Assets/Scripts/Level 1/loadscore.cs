using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class loadscore : MonoBehaviour
{
    public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        scoretext = GetComponent<Text>();
        scoretext.text = " " +aldeano1.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
