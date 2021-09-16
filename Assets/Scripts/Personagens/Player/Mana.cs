using System;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public float count;
    public int curMana { get; set; }
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
        if (curMana < 3)
        {
            count += Time.deltaTime;
            if (count >= 5f) {
                PlusMana(1);
                count = 0;
            }
        }
        if (curMana > maxMana)
        {
            curMana = maxMana;
        }



    }

        void EncheMana()
        {


            if (count >= 3f)
            {
                curMana = +1;
                count = 0;
            }



        }

    public void PlusMana(int mana)
    {
       
            curMana += mana;

            AtualizarMana?.Invoke(curMana);
        }


    public void LostMana(int mana)
        {
            curMana -= mana;

            AtualizarMana?.Invoke(curMana);
        }
    
}


