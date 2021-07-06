using UnityEngine;

public class ManaBar : MonoBehaviour
{
 
    public Animator anim;
    public int maxValue;
    public int manaCount;


    // Start is called before the first frame update
    void Start()
    {
        Mana.AtualizarMana += SetMana;
        Mana playermana = GameObject.FindGameObjectWithTag("Player").GetComponent<Mana>();
        maxValue = playermana.maxMana;


        anim.GetComponent<Animator>();
    }
    private void OnDestroy()
    {
        Mana.AtualizarMana -= SetMana;
    }

    // Update is called once per frame
    void Update()
    {
        if (manaCount == 3)

        {
            anim.SetInteger("cheio", 3);
        }
        if (manaCount == 2)
        {
            anim.SetInteger("cheio", 2);
        }
        if (manaCount == 1)
        {
            anim.SetInteger("cheio", 1);

        }
        if (manaCount <= 0)
        {
            anim.SetInteger("cheio", 0);
        }

    }

    public void SetMana(int hp)
    {
        manaCount = hp;
    }
}
