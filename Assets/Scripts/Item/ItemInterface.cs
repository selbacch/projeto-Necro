using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ItemInterface : MonoBehaviour
{
    public string Nome;
    public string Descricao;
    public Item tipoTipo;
    public AudioSource audioColetarUtilizar;
    public GameObject item;

    public enum Item { PocaoMP = 1001, PocaoHP = 1002,MascaraZero = 2000, MascaraUm = 2001, MascaraDois = 2002, MascaraTres = 2003, None = -1 }
    public virtual void Utilizar()
    {
        //InventarioController.Instance.RemoverDoInventario(this.tipoTipo);


    }

    public virtual void Coletar()
    {
        PlayAudio();
        InventarioController.Instance.AdicionarAoInventario(this.tipoTipo);
        DestruirObjeto();
    }

    public virtual void PlayAudio()
    {
        if (audioColetarUtilizar != null)
        {
            audioColetarUtilizar.pitch = 0.5f;
            audioColetarUtilizar.Play();
        }

    }

    private void DestruirObjeto()
    {
        float duracao = 0;
        audioColetarUtilizar.pitch = 1f;
        audioColetarUtilizar.Play();
        Destroy(item,0.07f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {

            Coletar();
        }

    }



}
