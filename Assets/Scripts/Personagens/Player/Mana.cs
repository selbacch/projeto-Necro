using System;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public int curMana { get; private set; }
    public int maxMana = 3;
    public static Action<int> AtualizarMana;
    // Start is called before the first frame update
    void Start()
    {
        curMana = maxMana;
        AtualizarMana?.Invoke(curMana);
    }

    // Update is called once per frame
    void Update()
    {


    }


    public void LostMana(int mana)
    {
        curMana -= mana;

        AtualizarMana?.Invoke(curMana);
    }


}
