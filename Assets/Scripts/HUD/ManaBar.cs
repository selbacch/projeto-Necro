using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{

    public Slider ManasBar;
    public int maxValue;
    


    // Start is called before the first frame update
    void Start()
    {
        Mana.AtualizarMana += SetMana;
        Mana playermana = GameObject.FindGameObjectWithTag("Player").GetComponent<Mana>();
        ManasBar = GetComponent<Slider>();
        maxValue = playermana.maxMana;
        ManasBar.maxValue = playermana.maxMana;

    }
    private void OnDestroy()
    {
        Mana.AtualizarMana -= SetMana;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMana(int hp)
    {
        ManasBar.value = hp;
    }
}
