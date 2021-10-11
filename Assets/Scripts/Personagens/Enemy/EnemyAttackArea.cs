using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyAttackArea : MonoBehaviour
{
    public Action<GameObject> PlayerEmAttack;
    public Action<GameObject> PlayerEntrouAttack;
    public Action<GameObject> PlayerSaiuAttack;
    public float Raio { get; private set; }
   

    void Start()
    {
        Raio = this.GetComponent<CircleCollider2D>().radius;
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
