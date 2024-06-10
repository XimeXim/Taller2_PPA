using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderData;    

public class Manejador_Audio : MonoBehaviour
{
    public static Manejador_Audio instancia;

    public AudioClip musicaDeFondo;
    public AudioClip sonidoDeDado;
    public AudioClip sonidoMoverJugador;
    public AudioClip sonidoGanador;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // comienza musica de fondo
        PlayMusicaDeFondo();
    }
    public void PlayMusicaDeFondo()
    {
        if (musicaDeFondo != null)
        {
            audioSource.clip = musicaDeFondo;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void PlayMusicaDeDado()
    {
        PlaySonido(sonidoDeDado);
    }


    public void PlaySonidoMoverJugador()
    {
        PlaySonido(sonidoMoverJugador);
    }

    public void PlaySonidoGanador()
    {
        PlaySonido(sonidoGanador);
    }

    private void PlaySonido(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

}






