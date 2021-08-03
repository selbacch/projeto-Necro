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



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("entrou");
            other.GetComponent<SpriteRenderer>().sortingOrder = -1;
            other.GetComponent<SpriteRenderer>().material = alter;

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("saiu");
            other.GetComponent<SpriteRenderer>().sortingOrder = 0;
            other.GetComponent<SpriteRenderer>().material = padrao;
        }
    }



}



