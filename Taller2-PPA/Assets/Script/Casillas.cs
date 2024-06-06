using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Casillas;

public class Casillas : MonoBehaviour
{
    // Start is called before the first frame update
    public enum TipoCasilla { Normal, Avanzar, Retirarse, Bonus }
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
            case TipoCasilla.Avanzar:
                controladorJugadores.MoverJugadorAPosicion(jugadorActual, posicionTarget);
                break;
            case TipoCasilla.Retirarse:
                controladorJugadores.MoverJugadorAPosicion(jugadorActual, posicionTarget);
                break;
            case TipoCasilla.Bonus:
                controladorJugadores.RepetirTurno(jugadorActual);
                break;
            case TipoCasilla.Normal:
            default:
                break;
        }
    }
}
