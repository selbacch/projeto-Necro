using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public string ProximaCena;


    private void OnTriggerEnter2D(Collider2D other)
    {



        if (other.tag == "Player")
        {
            if (!String.IsNullOrEmpty(ProximaCena))
                CenaController.Instance.PlayerEntrouPortal(other.gameObject, ProximaCena);

        }
    }
}
