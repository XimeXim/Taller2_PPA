using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Casillas;

public class Casillas : MonoBehaviour
{
    // Start is called before the first frame update
    public enum TileType { Normal, Avanzar, Retirarse, Bonus }
    public TileType tipoCasilla;
    public int posicionTarget;
    public int indexPosicionTablero;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAccionCasilla(ControladorJugadores controladorJugadores, int jugadorActual)
    {
        switch (tipoCasilla)
        {
            case TileType.Avanzar:
                controladorJugadores.MoverJugadorAPosicion(jugadorActual, posicionTarget);
                break;
            case TileType.Retirarse:
                controladorJugadores.MoverJugadorAPosicion(jugadorActual, posicionTarget);
                break;
            case TileType.Bonus:
                controladorJugadores.RepetirTurno(jugadorActual);
                break;
            case TileType.Normal:
            default:
                break;
        }
    }
}
