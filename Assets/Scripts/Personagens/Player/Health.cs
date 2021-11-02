using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int curHealth;

    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private int vidaPerSec;

    public Action<int, int> AtualizarVida;
    
    public int CurHealth { get => curHealth; }
    public int MaxHealth { get => maxHealth; }
    public int VidaPerSec { get => vidaPerSec; }

    private void Awake()
    {

    }

    // Start is called before the first frame update 
    void Start()
    {
        vidaPerSec = ConstantesPersonagens.BASE_REGENERACAO_VIDA_HIPATIA;
        StartCoroutine(VidaPorSegundo());
    }

    // Update is called once per frame 

    public void DamagePlayer(int value)
    {
        if (value < 0)
        {
            value *= -1;
        }

        int newValue = curHealth - value;
        newValue = newValue < 0 ? 0 : newValue;
        this.curHealth = newValue;


        AtualizarVida?.Invoke(maxHealth, curHealth);
    }

    public void Increase(int value)
    {
        if (value < 0)
        {
            value *= -1;
        }


        int newValue = curHealth + value;
        newValue = newValue > this.maxHealth ? this.maxHealth : newValue;
       
        this.curHealth = newValue;

        AtualizarVida?.Invoke(maxHealth, curHealth);
    }

    public void SetCurrentHealth(int value)
    {
        if (value > this.maxHealth)
        {
            value = maxHealth;
        }

        if (value < 0)
        {
            value = 0;
        }
       
        curHealth = value;

        AtualizarVida?.Invoke(maxHealth, curHealth);

    }

    public void SetMaxHealth(int value)
    {
        this.maxHealth = value;
        if (this.curHealth > this.maxHealth)
        {
            this.curHealth = this.maxHealth;
        }
        AtualizarVida?.Invoke(maxHealth, curHealth);
       
        
    }

    private IEnumerator VidaPorSegundo()
    {
        for (; ; )
        {
            Increase(this.vidaPerSec);
            yield return new WaitForSeconds(1f);
        }
    }
}