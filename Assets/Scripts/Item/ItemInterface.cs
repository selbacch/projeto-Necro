using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ItemInterface : MonoBehaviour
{
    public string Nome;
    public string Descricao;
    public Item tipoTipo;
    public AudioSource audioColetarUtilizar;

    public enum Item { PocaoMP = 1001, PocaoHP = 1002, MascaraUm = 2001, MascaraDois = 2002, MascaraTres = 2003, None = -1 }
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
            audioColetarUtilizar.Play();
        }

    }

    private void DestruirObjeto()
    {
        float duracao = 0;
        if (audioColetarUtilizar != null)
        {
            duracao = audioColetarUtilizar.clip.length;
        }
        Destroy(this.gameObject,duracao);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {

            Coletar();
        }

    }



}
