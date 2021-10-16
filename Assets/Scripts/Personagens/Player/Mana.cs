using System;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public float count;
   private int curMana;
    private  int maxMana;
    public Action<int> AtualizarMana;
    public Action<int, int> AtualizarManaMaxima;

    public int CurMana { get => curMana;}
    public int MaxMana { get => maxMana;}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curMana < maxMana)
        {
            count += Time.deltaTime;
            if (count >= 5f)
            {
                Increase(1);
                count = 0;
            }
        }
    


    }
  
    public void Increase(int mana)
    {
        int novoValor = curMana + mana;

        curMana = novoValor > maxMana ? maxMana : novoValor;

        AtualizarMana?.Invoke(curMana);
    }

    public void LostMana(int mana)
    {
        int novoValor = curMana - mana;
        curMana = novoValor < 0 ? 0 : novoValor;

        AtualizarMana?.Invoke(curMana);
    }

    public void SetMaxMana(int value)
    {
        this.maxMana = value;
        if (this.curMana > this.maxMana)
        {
            this.curMana = this.maxMana;
        }
        AtualizarManaMaxima?.Invoke(maxMana, curMana);
    }

    public void SetCurrMana(int value)
    {
        this.maxMana = value;
        if (this.curMana > this.maxMana)
        {
            this.curMana = this.maxMana;
        }
        AtualizarMana?.Invoke(curMana);
    }



}


