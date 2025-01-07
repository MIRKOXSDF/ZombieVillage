using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBarManager : MonoBehaviour
{
    public Image lifeBar;
    public float maxLife;

    // Start is called before the first frame update
    void Awake()
    {
        lifeBar = GetComponent<Image>();
    }

    public void SetUp(float life)
    {
        maxLife = life;
        lifeBar.fillAmount = life / maxLife;
    }

    public void ChangeLife(float life)
    {
        lifeBar.fillAmount = life / maxLife;
    }
}