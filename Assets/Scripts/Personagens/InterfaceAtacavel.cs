using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InterfaceAtacavel: MonoBehaviour
{
    public abstract void Atacar(int danoInflingido);
    public abstract void SofrerDano(int danoRecebido);

    public abstract int Dano();
}
