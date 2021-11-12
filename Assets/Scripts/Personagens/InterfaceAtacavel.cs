using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class InterfaceAtacavel: MonoBehaviour
{
    public bool Death;
    public Action DeathEvent;
    public TMP_Text FeedbackText;

    public Material MaterialDano;
    public Material MaterialInfo;
    public Material MaterialRecuperacao;

    public abstract void Atacar(int danoInflingido);
    public abstract void SofrerDano(int danoRecebido);

    public abstract int Dano();

    public IEnumerator FeedbackDano(int danoRecebido)
    {
        FeedbackText.text = danoRecebido.ToString();
        FeedbackText.material = MaterialDano;
        FeedbackText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.20f);
        FeedbackText.gameObject.SetActive(false);
    }

    public IEnumerator FeedbackInfo(string textoInfo)
    {
        FeedbackText.text = textoInfo.ToString();
        FeedbackText.material = MaterialInfo;
        FeedbackText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.10f);
        FeedbackText.gameObject.SetActive(false);
    }

    public IEnumerator FeedbackRecuperacao(int recuperado)
    {
        FeedbackText.text = recuperado.ToString();
        FeedbackText.material = MaterialRecuperacao;
        FeedbackText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.10f);
        FeedbackText.gameObject.SetActive(false);
    }

}
