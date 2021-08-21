using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    private Vector3 direct;
    public GameObject aljava;
    // Start is called before the first frame update
    void Start()
    {
        direct = aljava.GetComponent<Zarcher>().Direct;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direct * 10 * Time.deltaTime);
    }
}
