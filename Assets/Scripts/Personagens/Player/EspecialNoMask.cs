using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspecialNoMask : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D coll;
    public ParticleSystem smoke;
    public float temp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        temp += Time.deltaTime;
        if (temp >= 3.258669f)
        {
            //this.transform.Find("EspecialnoMask").gameObject.SetActive(false);
            gameObject.SetActive(false);
            temp = 0;
        }
    }






}
