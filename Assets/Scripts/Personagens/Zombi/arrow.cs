using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public Vector3 direct;
    public GameObject aljava;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // direct = aljava.GetComponent<Zarcher>().Direct;
        transform.Translate(direct * 5f * Time.deltaTime);
    }
}
