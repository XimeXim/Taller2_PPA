using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ControladorJugadores : MonoBehaviour
{
    // Start is called before the first frame update
    public Manejador_Juego manejador_Juego;
    public Transform[] jugadores; // Array de jugadores
    public Vector3[] posicionTablero; // Posiciones en el tablero
    public Casillas[] casillas; // Array de todas las casillas

    private int jugadorActual = 0; // Jugador actual
    private int[] posicionJugador; // Posici�n de cada jugador en el tablero
    private int contadorTurno = 0;
    private bool repetirTurno = false; // Variable para manejar si un jugador repite su turno

    void Start()
    {
        posicionJugador = new int[jugadores.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoverJugador(int pasos)
    {
        posicionJugador[jugadorActual] += pasos;
        if (posicionJugador[jugadorActual] >= posicionTablero.Length)
        {
            // Gan� el juego
            posicionJugador[jugadorActual] = posicionTablero.Length - 1;
            Debug.Log("Jugador " + (jugadorActual + 1) + " ha ganado!");
            manejador_Juego.GameOver(jugadorActual + 1, contadorTurno);
            return;
        }

        jugadores[jugadorActual].position = posicionTablero[posicionJugador[jugadorActual]];
        // Verificar casilla especial y actuar en consecuencia
        ManejarCasillasEspeciales(posicionJugador[jugadorActual]);
        

        if (!repetirTurno)
        {
            // Cambiar al siguiente jugador si no repite turno
            jugadorActual = (jugadorActual + 1) % jugadores.Length;
            contadorTurno++;
        }
        
    }

    public void MoverJugadorAPosicion(int indexJugador,int posicionTarget)
    {
        if (posicionTarget >= posicionTablero.Length)
        {
            posicionTarget = posicionTablero.Length - 1;
        }

        posicionJugador[indexJugador] = posicionTarget;
        jugadores[indexJugador].position = posicionTablero[posicionTarget];
    }

    public void RepetirTurno(int jugadorActual)
    {
        repetirTurno = true;
    }

    private void ManejarCasillasEspeciales(int posicionJugador)
    {
        Casillas casillaActual = GetCasillaEnPosicion(posicionJugador);
        if (casillaActual != null)
        {
            casillaActual.PlayAccionCasilla(this, jugadorActual);
        }
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
}
