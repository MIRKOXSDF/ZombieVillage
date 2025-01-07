using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoButton : MonoBehaviour
{
    public AudioSource Sonido;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        Sonido.clip = clip;
    }
    public void Reproducir()
    {
        Sonido.Play();
    }
}
