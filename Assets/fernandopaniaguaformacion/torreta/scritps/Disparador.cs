using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparadorAutomatico : MonoBehaviour
{
    public GameObject prefabProyectil;
    public float fuerza;
    public Transform posicion;

    public float distanciaAlPlayer;

    public float cadenciaDisparo;

    private Transform playerTransform;

    private bool disparando = false;

    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (!disparando)
        {
            if ((playerTransform.position - transform.position).magnitude < distanciaAlPlayer)
            {
                Disparar();
            }
        }
    }
    void Disparar()
    {
        disparando = true;
        //1. Crear el objeto
        GameObject go = Instantiate(
            prefabProyectil, posicion.position, posicion.rotation);
        //2. Aplicación de la fuerza
        go.GetComponent<Rigidbody>().AddForce(
            posicion.forward * fuerza
        );
        Invoke("DesactivarDisparo", cadenciaDisparo);
    }

    void DesactivarDisparo(){
        disparando=false;
    }
}
