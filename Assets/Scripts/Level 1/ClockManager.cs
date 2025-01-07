using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockManager : MonoBehaviour
{
    public Text ClockText;
    // Start is called before the first frame update
    void Start()
    {
        ClockText = GetComponent<Text>();
    }
    void Update()
    {
        CountDown();
    }
    void CountDown()
    {
        ClockText.text = "" + Mathf.FloorToInt(aldeano1.time);
    }
}
  