using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspecialNoMask : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D coll;
    public ParticleSystem smoke;
    public float temp;
    public GameObject enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnTriggerEnter2D(coll);
        temp += Time.deltaTime;
        if (temp >= 3.258669f)
        {
            smoke.Stop();
        }
        if (temp >= 5.258669f)
        {

            //this.transform.Find("EspecialnoMask").gameObject.SetActive(false);
            // gameObject.SetActive(false);
            this.transform.Find("EspecialnoMask").GetComponent<SpriteRenderer>().gameObject.SetActive(false);
            temp = 0;
        }
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            Debug.Log("entrou");
             collider.gameObject.GetComponent<Enemy>().Poisoned(1, 4);

        }
    }



}