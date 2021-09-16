using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int curHealth;
    public int maxHealth;
    public Action<int> AtualizarVida;
    public Action<int,int> AtualizarVidaMaxima;

    // Start is called before the first frame update 
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame 

    public void DamagePlayer(int value)
    {
        if (value < 0)
        {
            value *= -1;
        }

        int newValue = curHealth - value;
        newValue = newValue<0 ? 0 : newValue;
        this.curHealth = newValue;

        Debug.Log("Diminui vida em " + value +" atual: "+this.curHealth + " novo: " + newValue);
        AtualizarVida?.Invoke(this.curHealth);
    }

    public void Increase(int value)
    {
        if (value < 0)
        {
            value *= -1;
        }

        
        int newValue = curHealth + value;
        newValue = newValue > this.maxHealth ? this.maxHealth : newValue;
        Debug.Log("Aumenta vida em " + value + " atual: " + this.curHealth +" novo: "+newValue);
        this.curHealth = newValue;
        
        AtualizarVida?.Invoke(this.curHealth);
    }

    public void SetCurrentHealth(int value)
    {
        if(value > this.maxHealth)
        {
            value = maxHealth;
        }

        if(value< 0)
        {
            value = 0;
        }
 Debug.Log("Muda vida para: " + value + "atual: " + this.curHealth);
        curHealth = value;
       
        AtualizarVida?.Invoke(this.curHealth);
       
    }

    public void SetMaxHealth(int value)
    {
        this.maxHealth = value;
        if (this.curHealth> this.maxHealth)
        {
            this.curHealth = this.maxHealth;
        }
        AtualizarVidaMaxima?.Invoke(maxHealth, curHealth);
        Debug.Log("Muda vida maxima para: " + value + "atual: " + this.curHealth);

    }
}