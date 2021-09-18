using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{

    public Slider ManasBar;
    private Mana playermana;


    // Start is called before the first frame update
    void Start()
    {


        Mana playermana = GameObject.FindGameObjectWithTag("Player").GetComponent<Mana>();
        playermana.AtualizarMana += SetMana;
        playermana.AtualizarManaMaxima += AtualizarManaMaxima;
        ManasBar = GetComponent<Slider>();

    }
    private void OnDestroy()
    {
        if (playermana)
        {
            playermana.AtualizarMana -= SetMana;
            playermana.AtualizarManaMaxima -= AtualizarManaMaxima;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMana(int hp)
    {
        ManasBar.value = hp;
    }

    public void AtualizarManaMaxima(int manaMax, int manaAtual)
    {
        ManasBar.value = manaAtual;
        ManasBar.maxValue = manaMax;
    }
}
