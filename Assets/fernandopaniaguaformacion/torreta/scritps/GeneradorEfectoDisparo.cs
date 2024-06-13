using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEfectoDisparo : MonoBehaviour
{
    public GameObject prefabEfecto;
    public Transform posicion;
    void Update(){
        if (Input.GetButtonDown("Fire1")){
            Disparar();
        }
    }
    void Disparar(){
        //1. Crear el objeto
        GameObject go = Instantiate(
            prefabEfecto, posicion.position, posicion.rotation);
    }
}
