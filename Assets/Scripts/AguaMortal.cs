using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaMortal : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo){
        if (collisionInfo.gameObject.CompareTag("Zombies")){
            Destroy(collisionInfo.gameObject);
        }
    }
}
