using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int curHealth { get; private set; }
    public int maxHealth = 100;
    public static Action<int> AtualizarVida;

    // Start is called before the first frame update 
    void Start()
    {
        SetCurrentHealth(maxHealth);
        
    }

    // Update is called once per frame 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DamagePlayer(10);
        }
    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;
        AtualizarVida?.Invoke(this.curHealth);
    }

    public void Increase(int value)
    {
        curHealth += value;
        AtualizarVida?.Invoke(this.curHealth);
    }

    public void SetCurrentHealth(int value)
    {
        curHealth = value;
        AtualizarVida?.Invoke(this.curHealth);
    }
}