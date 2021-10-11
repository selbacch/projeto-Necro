using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyAggroArea : MonoBehaviour
{

    public Action<GameObject> PlayerEmAggro;
    public Action<GameObject> PlayerEntrouAggro;
    public Action<GameObject> PlayerSaiuAggro;
    private List<GameObject> ObjColisao;

    void Start()
    {
        ObjColisao = new List<GameObject>();
    }

    void Update()
    {

    }

    public GameObject ObterProximoTarget()
    {
        foreach(GameObject g in this.ObjColisao)
        {
            if (g != null && !g.GetComponent<InterfaceAtacavel>().Death)
            {
                return g;
            }
        }
        return null;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("sumon") || collision.gameObject.tag.Equals("Player"))
        {
            PlayerEntrouAggro?.Invoke(collision.gameObject);
            this.ObjColisao.Add(collision.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("sumon") || collision.gameObject.tag.Equals("Player"))
        {
            this.PlayerSaiuAggro?.Invoke(collision.gameObject);
            this.ObjColisao.Remove(collision.gameObject);
        }

    }

    

}
