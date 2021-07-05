using UnityEngine;
using UnityEngine.UI;

public class Lifebar : MonoBehaviour
{
    public Slider healthBar;
    public int maxValue;

    private void Start()
    {
        Health.AtualizarVida += SetHealth;
        Health playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        healthBar = GetComponent<Slider>();
        maxValue = playerHealth.maxHealth;
        healthBar.maxValue = playerHealth.maxHealth;
    }
    private void OnDestroy()
    {
        Health.AtualizarVida -= SetHealth;
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}