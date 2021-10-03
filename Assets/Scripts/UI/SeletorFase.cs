using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeletorFase : MonoBehaviour
{
    public string FASE_UM, FASE_DOIS, FASE_TRES, FASE_QUATRO, FASE_CINCO;

    public string MENU_INICIAL;

    public void MenuInicial()
    {
        SceneManager.LoadScene(MENU_INICIAL);
    }

    public void CarregarFaseUm()
    {
        SceneManager.LoadScene(FASE_UM);
    }
    public void CarregarFaseDois()
    {
        SceneManager.LoadScene(FASE_DOIS);
    }
    public void CarregarFaseTres()
    {
        SceneManager.LoadScene(FASE_TRES);
    }
    public void CarregarFaseQuatro()
    {
        SceneManager.LoadScene(FASE_QUATRO);
    }
    public void CarregarFaseCinco()
    {
        SceneManager.LoadScene(FASE_CINCO);
    }
}
