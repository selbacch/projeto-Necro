using UnityEngine;
using UnityEngine.UI;

public class Lifebar : MonoBehaviour
{
    public Slider healthBar;
    Health playerHealth;

    private void Start()
    {
     
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        playerHealth.AtualizarVida += SetHealth;
        playerHealth.AtualizarVidaMaxima += AtualizarVidaMaxima;

        healthBar = GetComponent<Slider>();
        healthBar.maxValue = 100;
    }
    private void OnDestroy()
    {
        playerHealth.AtualizarVida -= SetHealth;
        playerHealth.AtualizarVidaMaxima -= AtualizarVidaMaxima;
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }

    public void AtualizarVidaMaxima(int vidaMax, int vidaAtual)
    {
        healthBar.value = vidaAtual;
        healthBar.maxValue = vidaMax;
    }
}