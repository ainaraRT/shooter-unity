using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSigue : MonoBehaviour
{
    //Referencia del jugador
    public GameObject jugador;

    //public GameObject salida;
    public GameObject salida;

    //Distancia de detección
    public float distDeteccion;

    //Referencia del componente NavMesh
    public UnityEngine.AI.NavMeshAgent miAgente;

    // Start is called before the first frame update
    void Start()
    {
        //Obtenemos la referencia del componente
        miAgente = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direccion = jugador.transform.position - this.transform.position;

        //Condición de distancia
        if (direccion.magnitude < distDeteccion)
        {
            //Seguir al jugador
            miAgente.SetDestination(jugador.transform.position);
        }
    }
}
