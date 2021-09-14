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
      
        temp += Time.deltaTime;
        if (temp >= 3.258669f)
        {
            smoke.Stop();
        }
        if (temp >= 5.258669f)
        {

            //this.transform.Find("EspecialnoMask").gameObject.SetActive(false);
            // gameObject.SetActive(false);
            this.transform.gameObject.SetActive(false);
            
            temp = 0;
        }
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            Debug.Log("entrou");
            Enemy enemy = null;
           

            if (collider.gameObject.TryGetComponent<Enemy> (out enemy))
            {
                enemy.Poisoned(1,4);
            }
            
            //collider.gameObject.GetComponent<Enemy2>().Poisoned(1, 4);

        }
    }



}
