using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manejador_Juego : MonoBehaviour
{
    // Start is called before the first frame update
    public ControladorJugadores controladorJugadores;
    public Button botonArrojarDado;
    public Text mensajeGameOver;
    public ArrojarDado dado;

    private bool isGameOver = false;
    void Start()
    {
        botonArrojarDado.onClick.AddListener(ArrojaDado);//poner nombre el sonido
        mensajeGameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ArrojaDado()
    {
        if (!isGameOver)
        {
            dado.ArrojaDado();
        }
    }

    public void GameOver(int winningPlayer, int turnCount)
    {
        isGameOver = true;
        mensajeGameOver.text = "Jugador " + winningPlayer + " ha ganado en " + turnCount + " turnos!";
        mensajeGameOver.gameObject.SetActive(true);
    }
}
