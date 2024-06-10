using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.UI;

public class ControladorJugadores : MonoBehaviour
{
    // Start is called before the first frame update
    public Manejador_Juego manejador_Juego;
    public Transform[] jugadores; // Array de jugadores
    public Vector3[] posicionTablero; // Posiciones en el tablero
    public Casillas[] casillas; // Array de todas las casillas
    public Text textoTurno;

    private int jugadorActual = 0; // Jugador actual
    private int[] posicionJugador; // Posición de cada jugador en el tablero
    private int contadorTurno = 0;

    void Start()
    {
        posicionJugador = new int[jugadores.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoverJugador(int valorDado)
    {

        int indexJugador = jugadorActual;
        int indexNuevaPosicion = posicionJugador[indexJugador] + valorDado;

        MoverJugadorAPosicion(indexJugador,indexNuevaPosicion);
        
        if (!RepetirTurno(indexJugador))
        {
            // Cambiar al siguiente jugador si no repite turno
            jugadorActual = (jugadorActual + 1) % jugadores.Length;
            contadorTurno++;
            UpdateTextoDeTurno();
        }
    }

    public void UpdateTextoDeTurno()
    {
        textoTurno.text = "Turno: Jugador " + (jugadorActual + 1);
    }
    public void MoverJugadorAPosicion(int indexJugador,int posicionTarget)
    {
        // Limitar a la última posición del tablero
        if (indexJugador >= casillas.Length)
        {
            posicionTarget = casillas.Length - 1;
            manejador_Juego.GameOver(jugadorActual, contadorTurno);
            Manejador_Audio.instancia.PlaySonidoGanador();
        }
        Casillas casillaTarget = casillas[posicionTarget];
        jugadores[indexJugador].position = casillaTarget.transform.position;
        posicionJugador[indexJugador] = posicionTarget;
        Manejador_Audio.instancia.PlaySonidoMoverJugador();

        // Verificar casilla especial y actuar en consecuencia
        manejador_Juego.ManejarCasillasEspeciales(posicionJugador[jugadorActual]);

    }

    public bool RepetirTurno(int jugadorActual)
    {
        return true;

    }
}
