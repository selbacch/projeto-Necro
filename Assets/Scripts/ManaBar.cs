using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour
{
    public Mana playermana;
    public Animator anim;
    public int maxValue;
    public int manaCount;

    // Start is called before the first frame update
    void Start()
    {
        playermana = GameObject.FindGameObjectWithTag("Player").GetComponent<Mana>();
        maxValue = playermana.maxMana;
       

        anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        manaCount = playermana.curMana;
        if (manaCount == 3)

        {   
            anim.SetInteger("cheio",3);
        }
        if(manaCount == 2)
        {
            anim.SetInteger("cheio", 2);
        }
        if(manaCount== 1)
        {
            anim.SetInteger("cheio", 1);

        }
        if(manaCount <= 0)
        {
            anim.SetInteger("cheio", 0);
        }

    }

    public void SetMana(int hp)
    {
       manaCount = hp;
    }
}
