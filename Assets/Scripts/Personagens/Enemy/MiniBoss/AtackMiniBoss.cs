using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackMiniBoss : MonoBehaviour
{

    public Action<GameObject> Atacke;
    public Action<GameObject> AtackeOut;


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
            Atacke?.Invoke(collision.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("sumon") || collision.gameObject.tag.Equals("Player"))
        {
            this.AtackeOut?.Invoke(collision.gameObject);
        }

    }

}

