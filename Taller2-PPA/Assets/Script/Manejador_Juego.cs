using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manejador_Juego : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerPrefab;
    public Transform[] jugadores; // Array de jugadores
    public Casillas[] casillas; // Array de todas las casillas
    public ControladorJugadores controladorJugadores; // Referencia al controlador de jugadores
    public Button botonArrojarDado;
    public Text mensajeGameOver;
    public Text resultadoDado; // Referencia al texto del resultado del dado

    private int jugadorActual = 0; // Jugador actual
    private int[] posicionJugador;
    private int numeroDeJugadores = 4;
    private bool isGameOver = false;

    void Start()
    {
        posicionJugador = new int[numeroDeJugadores];
        
        for (int i = 0; i < numeroDeJugadores; i++)
        {
            posicionJugador[i] = 0;
        }
        botonArrojarDado.onClick.AddListener(ArrojaDado);
        controladorJugadores.UpdateTextoDeTurno();
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
            LanzaDadoOnClick();
        }
    }

    public void GameOver(int jugadorGanador, int contadorTurno)
    {
        isGameOver = true;
        Manejador_Audio.instancia.PlaySonidoGanador();
        mensajeGameOver.text = "El Jugador " + jugadorGanador + " ha ganado en " + contadorTurno + " turnos!";
        mensajeGameOver.gameObject.SetActive(true);
    }

    public void LanzaDadoOnClick()
    {
        if (isGameOver) return;

        Manejador_Audio.instancia.PlayMusicaDeDado();
        int resultado = Random.Range(1, 7); // Genera un número aleatorio entre 1 y 6
        resultadoDado.text = "Resultado: Avanza " + resultado.ToString() + " posiciones!"; // Actualiza el texto del resultado
        controladorJugadores.MoverJugador(resultado); // Mueve al jugador actual


    }

    
    private Casillas GetCasillaEnPosicion(int posicion)
    {
        foreach (Casillas casilla in casillas)
        {
            if (casilla.indexPosicionTablero == posicion)
            {
                return casilla;
            }
        }
        return null;
    }
    public void ManejarCasillasEspeciales(int posicionJugador)
    {
        Casillas casillaActual = GetCasillaEnPosicion(posicionJugador);
        if (casillaActual != null)
        {
            casillaActual.PlayAccionCasilla(controladorJugadores, jugadorActual);
        }
    }

}
