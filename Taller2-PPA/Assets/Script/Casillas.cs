using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Casillas;

public class Casillas : MonoBehaviour
{
    // Start is called before the first frame update
    public enum TipoCasilla { Azul, Verde, Negra, Amarilla }
    public TipoCasilla tipoCasilla;
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
            case TipoCasilla.Verde:
                controladorJugadores.MoverJugadorAPosicion(jugadorActual, posicionTarget);
                break;
            case TipoCasilla.Negra:
                controladorJugadores.MoverJugadorAPosicion(jugadorActual, posicionTarget);
                break;
            case TipoCasilla.Amarilla:
                controladorJugadores.RepetirTurno(jugadorActual);
                break;
            case TipoCasilla.Azul:
            default:
                break;
        }
    }

}
