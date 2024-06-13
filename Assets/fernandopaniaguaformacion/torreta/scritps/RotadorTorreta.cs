using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotadorTorreta : MonoBehaviour
{
    private GameObject player;
    private float h;
    [SerializeField]
    private float velocidadGiroHorizontal;

    void Awake(){
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
}
