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
    public LanzarDado dado;

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
            dado.LanzaDado();
        }
    }

    public void GameOver(int jugadorGanador, int contadorTurno)
    {
        isGameOver = true;
        mensajeGameOver.text = "Jugador " + jugadorGanador + " ha ganado en " + contadorTurno + " turnos!";
        mensajeGameOver.gameObject.SetActive(true);
    }
}
