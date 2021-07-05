using System;
using UnityEngine;

public class EnemyAggroArea : MonoBehaviour
{

    public Action<GameObject> PlayerEmAggro;
    public Action<GameObject> PlayerEntrouAggro;
    public Action<GameObject> PlayerSaiuAggro;

    void Start()
    {

    }

    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("sumon") || collision.gameObject.tag.Equals("Player"))
        {
            PlayerEntrouAggro?.Invoke(collision.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("sumon") || collision.gameObject.tag.Equals("Player"))
        {
            this.PlayerSaiuAggro?.Invoke(collision.gameObject);
        }

    }

}
