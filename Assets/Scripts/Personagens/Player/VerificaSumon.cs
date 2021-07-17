using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificaSumon : MonoBehaviour
{

    public bool sumon;
    public GameObject SEnemy;
    public Collider2D coll;
    public GameObject Corpi;
    public GameObject Zombi;
    // public GameObject 
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        OnTriggerStay2D(coll);
        if (sumon == false)
        {
            gameObject.GetComponent<Player>().Zombi = Zombi;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "body")
        {
            Debug.Log(collision.tag);
            sumon = true;
            Corpi = collision.gameObject;
            SEnemy = collision.gameObject.GetComponent<Corpinho>().SumonMorto;
            gameObject.GetComponent<Player>().Zombi = SEnemy;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "body")
        {
            {
                SEnemy = null;
                sumon = false;
                gameObject.GetComponent<Player>().Zombi = Zombi;
            }
        }
    }
}
    

