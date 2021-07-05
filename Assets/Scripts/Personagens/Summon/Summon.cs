using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Summon : InterfaceAtacavel
{
    public int Vida;
    public int DanoAtual;

    public  override void Atacar(int danoInflingido)
    {
        throw new System.NotImplementedException();
    }

    public override int Dano()
    {
        throw new System.NotImplementedException();
    }

    public override void SofrerDano(int danoRecebido)
    {
        throw new System.NotImplementedException();
    }
}
