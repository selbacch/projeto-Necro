using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificaSumon : MonoBehaviour
{

    public bool sumon ;
    public GameObject SEnemy;
    public Collider2D coll;
    public GameObject Zombi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnTriggerStay2D(coll);
        if(sumon == false)
        {
            gameObject.GetComponent<Player>().Zombi = Zombi;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
      
        if(collision.gameObject.tag == "body"){
            Debug.Log(collision.tag);
            sumon = true;
            SEnemy = collision.gameObject.GetComponent<Corpinho>().SumonMorto;
           gameObject.GetComponent<Player>().Zombi = SEnemy;
        }
        if (collision.gameObject.tag != "body")
        {
            
            sumon = false;
            
        }
    }
}
