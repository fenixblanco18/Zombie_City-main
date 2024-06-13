using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructorEnemigos : MonoBehaviour
{
    public string etiqueta;

    public void OnCollisionEnter(Collision c){
        if (string.IsNullOrEmpty(etiqueta)){
            Debug.LogWarning("El atributo 'etiqueta' de DestructorEnemigos debería estar relleno");
            return;
        }
        if (c.gameObject.CompareTag(etiqueta)){
            Destroy(c.gameObject);
        }
    }
}
