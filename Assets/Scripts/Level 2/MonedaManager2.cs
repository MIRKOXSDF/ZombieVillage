using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonedaManager2 : MonoBehaviour
{
    public Text monedaText;
    // Start is called before the first frame update
    void Start()
    {
        monedaText = GetComponent<Text>();
    }

    public void SetMoneda(int moneda)
    {
        monedaText.text = "  " + moneda;
    }
}
