using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadtime : MonoBehaviour
{
    public Text timetext;
    // Start is called before the first frame update
    void Start()
    {
        timetext = GetComponent<Text>();
        timetext.text = " " +Mathf.FloorToInt(aldeano1.time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
