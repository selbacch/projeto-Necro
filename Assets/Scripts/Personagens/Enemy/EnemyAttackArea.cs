using System;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    public Action<GameObject> PlayerEmAttack;
    public Action<GameObject> PlayerEntrouAttack;
    public Action<GameObject> PlayerSaiuAttack;

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

            this.PlayerEntrouAttack?.Invoke(collision.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("sumon") || collision.gameObject.tag.Equals("Player"))
        {

            this.PlayerSaiuAttack?.Invoke(collision.gameObject);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("sumon") || collision.gameObject.tag.Equals("Player"))
        {

            this.PlayerEmAttack?.Invoke(collision.gameObject);
        }

    }
}
