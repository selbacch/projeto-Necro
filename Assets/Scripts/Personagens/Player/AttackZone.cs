using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public List<GameObject> targets;
    // Start is called before the first frame update

    private void Awake()
    {
        targets = new List<GameObject>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player>().move.x > 0)
        {

            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 88));
        }
        if (player.GetComponent<Player>().move.x < 0)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -88));
        }
        if (player.GetComponent<Player>().move.y > 0)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 179));
        }
        if (player.GetComponent<Player>().move.y < 0)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    public List<GameObject> ObterTargetsValidos()
    {

        List<GameObject> novosTargets = new List<GameObject>();
        foreach (GameObject go in targets)
        {
            if (go != null)
            {
                Enemy en = go.GetComponent<Enemy>();
                if (!en.Death)
                {
                    novosTargets.Add(go);
                }

            }
        }

        return novosTargets;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            target = collision.gameObject;
            targets.Add(collision.gameObject);
        }


        if (collision.gameObject.tag == "Opn")
        {
            target = collision.gameObject;

        }
        if (collision.gameObject.tag == "Leitura")
        {
            target = collision.gameObject;

        }
        if (collision.gameObject.tag == "Conversa")
        {
            target = collision.gameObject;

        }



    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            target = null;
            targets.Remove(collision.gameObject);

        }

        if (collision.gameObject.tag == "Opn")
        {
            target = null;

        }
        if (collision.gameObject.tag == "Leitura")
        {
            target = null;

        }
        if (collision.gameObject.tag == "Conversa")
        {
            target = null;

        }



    }




}
