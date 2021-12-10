using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CircleCollider2D))]
public class CheckpointController : MonoBehaviour
{

    public string idCheckPoint;
    public string cena;


    private void Awake()
    {
        this.gameObject.name = idCheckPoint;
    }

    public static CheckpointController EncontrarUltimoCheckpointAtivo()
    {
        string cp = CenaController.Instance.infoSessao.ultimoCheckPoint;

        if (String.IsNullOrEmpty(cp))
        {
            return null;
        }

        string[] infos = cp.Split('#');
        if(!infos[0].Equals(SceneManager.GetActiveScene().name ))
        {
            return null;
        }

        GameObject ck= GameObject.Find(infos[1]);
        return ck.GetComponent<CheckpointController>();

    }

    public void PosicionaPlayer()
    {
        GameObject ob = GameObject.FindGameObjectWithTag("Player");
        ob.transform.position = this.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CenaController.Instance.infoSessao.ultimoCheckPoint = CaminhoCheckPoint();
        CenaController.Instance.SalvarJogo();
    }

    public string CaminhoCheckPoint()
    {
        return this.cena + '#' + this.idCheckPoint;
    }

}
