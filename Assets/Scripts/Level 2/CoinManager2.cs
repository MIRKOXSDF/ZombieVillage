using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager2 : MonoBehaviour
{
    public Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        coinText = GetComponent<Text>();
    }

    void Update()
    {
        coinText.text = " " + aldeano1.score;

    }

    public void SetCoin(int coin)
    {
        coinText.text = " " + coin;
        aldeano2.score++;
    }
}
