using UnityEngine;
using UnityEngine.UI;

public class Lifebar : MonoBehaviour
{
    public Slider healthBar;
    Health playerHealth;

    private void Start()
    {

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        playerHealth.AtualizarVida += AtualizarVidaMaxima;

        healthBar = GetComponent<Slider>();
        healthBar.maxValue = 100;
    }
    private void OnDestroy()
    {
        if (playerHealth)
        {
            playerHealth.AtualizarVida -= AtualizarVidaMaxima;
        }

    }

    public void AtualizarVidaMaxima(int vidaMax, int vidaAtual)
    {
        healthBar.value = vidaAtual;
        healthBar.maxValue = vidaMax;
    }
}