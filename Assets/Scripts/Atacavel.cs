using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Atacavel 
{
    public void CausarDano(Atacavel atacado);
    public void SofrerDano(Atacavel atacante);
    public int DanoCausado();


}
