using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //Referencia del objeto a clonar
    public GameObject efectoOriginal;

    //Referencia del enemigo que nos sigue
    public GameObject enemigoSigue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Disparar
            DispararConRayo();
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

            //Destruir enemigos
            if (resultRayo.transform.tag == "Enemy")
            {
                Destroy(resultRayo.transform.gameObject);
            }
            //Destruir
            if (resultRayo.transform.tag == "Final")
            {
                Destroy(enemigoSigue.gameObject);
            }
        }
        else
        {
            Debug.Log("Rayo no colisiona");
        }
    }
}
