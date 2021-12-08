using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvionEsferas : MonoBehaviour
{
    //Velocidad y rotacion del avión
    public float speed;
    public float rotation;

    //Referencia de la bala
    public GameObject originalBala;

    //Referencias de los cañones por donde se van a disparar las balas
    public GameObject canon1;
    public GameObject canon2;

    //Contador de las esferas
    public int contador;

    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime, Space.Self);
        MovimientoAvion();
        Shoot();

    }

    void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject nuevaBala1;
            GameObject nuevaBala2;
            nuevaBala1 = (GameObject)Instantiate(originalBala, canon1.transform.position, this.transform.rotation);
            nuevaBala2 = (GameObject)Instantiate(originalBala, canon2.transform.position, this.transform.rotation);
            nuevaBala1.GetComponent<Rigidbody>().AddForce(nuevaBala1.transform.forward * 2000);
            nuevaBala2.GetComponent<Rigidbody>().AddForce(nuevaBala2.transform.forward * 2000);
        }
    }

    void MovimientoAvion()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(new Vector3(-rotation, 0, 0) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(new Vector3(rotation, 0, 0) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, rotation, 0) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -rotation, 0) * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Esfera")
        {
            contador++;
            Debug.Log("ContadorEsferas: " + contador);
            Destroy(other.transform.gameObject);
        }
    }
}
