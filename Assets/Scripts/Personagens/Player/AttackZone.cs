using UnityEngine;

public class AttackZone : MonoBehaviour
{
    public GameObject atackzone;
    public Collider2D coll;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Player>().move.x > 0)
        {

            atackzone.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 88));
        }
        if (gameObject.GetComponent<Player>().move.x < 0)
        {
            atackzone.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -88));
        }
        if (gameObject.GetComponent<Player>().move.y > 0)
        {
            atackzone.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 179));
        }
        if (gameObject.GetComponent<Player>().move.y < 0)
        {
            atackzone.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        OnTriggerStay2D(coll);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy = collision.gameObject;

        }
    }






}
