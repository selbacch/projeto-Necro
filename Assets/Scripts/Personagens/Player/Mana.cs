using System;
using System.Collections;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public float count;

    [SerializeField]
    private int curMana;

    [SerializeField]
    private int maxMana;

    [SerializeField]
    private int manaPerSec;

    public Action<int,int> AtualizarMana;

    public int CurMana { get => curMana; }
    public int MaxMana { get => maxMana; }

    public int ManaPerSec { get => manaPerSec; }

    // Start is called before the first frame update
    void Start()
    {
        manaPerSec = ConstantesPersonagens.BASE_REGENERACAO_MANA_HIPATIA;
        StartCoroutine(ManaPorSegundo());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Increase(int mana)
    {
        int novoValor = curMana + mana;

        curMana = novoValor > maxMana ? maxMana : novoValor;

        AtualizarMana?.Invoke(maxMana, curMana);
    }

    public void LostMana(int mana)
    {
        int novoValor = curMana - mana;
        curMana = novoValor < 0 ? 0 : novoValor;

        AtualizarMana?.Invoke(maxMana, curMana);
    }

    public void SetMaxMana(int value)
    {
        this.maxMana = value;
        if (this.curMana > this.maxMana)
        {
            this.curMana = this.maxMana;
        }
        AtualizarMana?.Invoke(maxMana, curMana);
        
    }

    public void SetCurrMana(int value)
    {
        this.curMana = value;
        if (this.curMana > this.maxMana)
        {
            this.curMana = this.maxMana;
        }
        AtualizarMana?.Invoke(maxMana, curMana);
    }

    private IEnumerator ManaPorSegundo()
    {
        for (; ; )
        {
            if (this.curMana > this.maxMana)
            {
                Increase(manaPerSec);
            }
            yield return new WaitForSeconds(1f);
        }

    }

}


