using UnityEngine;

public class Demonatack : MonoBehaviour
{

    public Collider2D coll;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OnTriggerEnter2D(coll);
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyAI>().LevaDano(15);


        }

    }

    void OnTriggerExit2D(Collider2D collider)
    {


        if (collider.gameObject.tag == "Enemy")
        {
            target = null;
        }

    }

}
