using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public int repticion;
    public float tiempo;
    public bool disparando;

    public AudioClip audioDisparo;
    public GameObject prfabBala;
    public GameObject fxExplosion;
    public Transform transforEmisor;
    public float fuerzaDisparo = 50.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {


            if (!disparando)
            {
                disparando = true;

                StartCoroutine(Repeticiones(repticion, tiempo));


            }

        }

    }

    IEnumerator Repeticiones(int repeticiones, float espera)
    {

        for (int i = 0; i < repeticiones; i++)
        {
            Disparar();
            Instantiate(fxExplosion, transforEmisor.position, transforEmisor.rotation);
            yield return new WaitForSeconds(espera);
        };

        disparando = false;

    }
    public void Disparar()
    {

        GameObject bala = Instantiate(prfabBala, transforEmisor.position, transforEmisor.rotation);
        bala.GetComponent<Rigidbody>().AddForce(bala.transform.forward * fuerzaDisparo);


        if (audioDisparo != null)
        {

            GetComponent<AudioSource>().PlayOneShot(audioDisparo);
        }

    }
}
