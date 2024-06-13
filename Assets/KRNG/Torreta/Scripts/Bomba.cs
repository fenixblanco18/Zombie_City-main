using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class Bomba : MonoBehaviour
{
    public float radioExpansion;
    public float fuerzahorizontal;
    public float fuerzaVertical;
    public GameObject explosion;
    [Header("Capa para agurpar a qu objetos ataca")]
    public LayerMask layerMask;

    [Header("Segundos de espera para que explote")]
    public float temporizador;


    void Start()
    {
        Destroy(gameObject, 5);
    }



    void OnCollisionEnter(Collision other)
    {
        print("Collider");
        Explotar();
    }
    public void Explotar()
    {
        print("explotar");
        //Obtiene los colliders afectados por la esplosion
        Collider[] hitCollider = Physics.OverlapSphere(transform.position, radioExpansion, layerMask);
        foreach (var collider in hitCollider)
        {
            if (collider.GetComponent<Rigidbody>() != null)
            {

                collider.GetComponent<Rigidbody>().AddExplosionForce(
                    fuerzahorizontal,
                    transform.position,
                    radioExpansion,
                    fuerzaVertical);
                Instantiate(explosion, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }
}
