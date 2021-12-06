using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{

    private string CENA_NOVO_JOGO = "CS_HistoryOfSword";
    private string CENA_CONTINUAR = "IN_selecao_fase";

    public void CriarNovoJogo()
    {
        SceneManager.LoadScene(CENA_NOVO_JOGO);
    }

    public void ContinuarJogoAnterior()
    {
        CenaController.Instance.CarregarJogoSalvo();
        SceneManager.LoadScene(CENA_CONTINUAR);
    }

    public void SairJogo()
    {
        Application.Quit();
    }

}
