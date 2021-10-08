using UnityEngine;

public class OrderControler : MonoBehaviour
{
    // Start is called before the first frame update

    public SpriteRenderer renderSprite;
    public Material padrao;
    public Material alter;

    void Start()
    {
        renderSprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }



    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
        
            other.GetComponent<SpriteRenderer>().sortingOrder = -2;
            other.GetComponent<SpriteRenderer>().material = alter;

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            other.GetComponent<SpriteRenderer>().sortingOrder = 0;
            other.GetComponent<SpriteRenderer>().material = padrao;
        }
    }



}



