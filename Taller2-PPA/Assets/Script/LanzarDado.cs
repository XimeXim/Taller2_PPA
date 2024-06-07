using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanzarDado : MonoBehaviour
{
    // Start is called before the first frame update
    public Text resultadoDado; // Referencia al texto del resultado del dado
    public ControladorJugadores controladorJugadores; // Referencia al controlador de jugadores
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LanzaDado()
    {
        int resultado = Random.Range(1, 7); // Genera un número aleatorio entre 1 y 6
        resultadoDado.text = "Resultado: " + resultado.ToString(); // Actualiza el texto del resultado
        controladorJugadores.MoverJugador(resultado); // Mueve al jugador actual
    }
}