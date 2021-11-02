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
        playermana.AtualizarMana += AtualizarManaMaxima;
        ManasBar = GetComponent<Slider>();

    }
    private void OnDestroy()
    {
        if (playermana)
        {
            playermana.AtualizarMana -= AtualizarManaMaxima;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AtualizarManaMaxima(int manaMax, int manaAtual)
    {
        Debug.Log("manaAtual " + manaAtual + " manaMax" + manaMax);
        ManasBar.value = manaAtual;
        ManasBar.maxValue = manaMax;
    }
}
