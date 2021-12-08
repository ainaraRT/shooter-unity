using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPatrulla : MonoBehaviour
{
    //Puntos de patrulla
    public GameObject p1;
    public GameObject p2;

    public int destActual;

    public UnityEngine.AI.NavMeshAgent miAgente;

    public float margen = 1;

    public GameObject jugador;
    public float rango = 4;

    public float anguloVista = 45;

    //Referencia del objeto a clonar
    public GameObject efectoOriginal;

    // Start is called before the first frame update
    void Start()
    {
        miAgente = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //DETECTAR PLAYER
        DetectarAlPlayer();

        Patrulla();
    }

    void DetectarAlPlayer()
    {
        //DETECTAR PLAYER
        Vector3 distPlayer = jugador.transform.position - miAgente.destination; //Vector de jugador a la IA
        //Condición de distancia
        if (distPlayer.magnitude < rango)
        {
            //Mirar la línea de visión
            RaycastHit resultadoRay;
            if (Physics.Raycast(this.transform.position, distPlayer, out resultadoRay, 20))
            {
                //Rayo colisiona con algo
                if (resultadoRay.transform.tag == "MainCamera")  //Que tiene línea de visión
                {
                    //Mirar el angulo
                    float angulo = Vector3.Angle(this.transform.forward, distPlayer);
                    //Mirar si estamos dentro del angulo del cono
                    if (angulo < anguloVista)
                    {
                        DispararConRayo();
                    }
                }
            }
        }
    }

    void Patrulla()
    {
        //Detectar la distancia que falta al destino
        //Distancia al destino
        Vector3 dist = this.transform.position - miAgente.destination;
        if (dist.magnitude < margen)
        {
            //Llegamos al destino
            if (destActual == 1)
            {
                //Actualizar destino
                destActual = 2;
                //Mandar al punto 2
                miAgente.SetDestination(p2.transform.position);
            }
            else
            {
                destActual = 1;
                //Mandar al punto 1
                miAgente.SetDestination(p1.transform.position);
            }
        }
    }

    void DispararConRayo()
    {
        RaycastHit resultRayo;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out resultRayo, 100))
        {
            Debug.Log(resultRayo.transform.name);

            //Sacamos efecto partícula
            Instantiate(efectoOriginal, resultRayo.point, this.transform.rotation);

        }
    }
}