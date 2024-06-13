using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevadorTorreta : MonoBehaviour
{
    public float v;
    public float velocidadVertical;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        v = Input.GetAxis("Vertical");
        transform.Rotate(0, 0, -v * Time.deltaTime * velocidadVertical);
    }
}
