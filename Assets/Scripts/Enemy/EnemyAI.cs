using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyAI : MonoBehaviour
{
    public Grid gridGeral;
    public Tilemap colisores;
    public Tilemap terreno;

    List<Cell> abertos;
    List<Cell> fechados;


    private void Start()
    {

    }

    public List<Cell> AStar(Vector3 inicial, Vector3 alvo)
    {

        abertos = new List<Cell>();
        fechados = new List<Cell>();

        Vector3Int celulaInicial = gridGeral.LocalToCell(inicial);
        Vector3Int celulaAlvo = gridGeral.LocalToCell(alvo);

        Cell cellAlvo = new Cell(celulaAlvo);

        Cell celula = new Cell(celulaInicial);
        celula.parent = null;
        abertos.Add(celula);

        Cell iterador = null;
        int nivel = 0;
        while (abertos.Count > 0)
        {
            nivel++;
            iterador = ObterCelulaMelhor(abertos);
            if (iterador.position.x == celulaAlvo.x && iterador.position.y == celulaAlvo.y)
            {
                return ReconstruirCaminho(iterador);
            }

            abertos.Remove(iterador);
            fechados.Add(iterador);

            List<Cell> vizinhos = ObterVizinhos(iterador, cellAlvo);

            foreach (Cell viz in vizinhos)
            {
                Cell find = abertos.Find(p => p.position.Equals(viz.position));

                if (find == null || find.cost > viz.cost)
                {
                    abertos.Add(viz);
                    if (find != null)
                    {
                        abertos.Remove(find);
                    }

                }

            }

        }

        return new List<Cell>();
    }

    public List<Vector3> CaminhoGridToLocal(List<Cell> caminho)
    {
        List<Vector3> list = new List<Vector3>();
        Vector3 pos;
        foreach (Cell c in caminho)
        {
            pos = gridGeral.CellToLocal(c.position);
            list.Add(pos);
        }

        return list;
    }

    private double heuristicaAStar(Vector3Int avaliado, Vector3Int alvo)
    {
        double heu = (alvo.x * 2 - avaliado.x * 2) + (alvo.y * 2 - avaliado.y * 2);
        return Math.Sqrt(heu);
    }

    private Cell ObterCelulaMelhor(List<Cell> abertos)
    {
        Cell result = new Cell();
        result.heuristic = float.PositiveInfinity;
        foreach (Cell celula in abertos)
        {
            if (celula.f < result.f)
            {
                result = celula;
            }
        }

        return result;
    }

    private List<Cell> ObterVizinhos(Cell atual, Cell alvo)
    {
        List<Cell> vizinhos = new List<Cell>();

        Vector3Int posCell = atual.position;
        double g = atual.cost;

        Vector3Int vizinho;
        Cell novo;

        // x - 1 e y -1
        vizinho = new Vector3Int(posCell.x - 1, posCell.y - 1, posCell.z);
        novo = new Cell(vizinho);
        novo.cost = g + 1;
        novo.heuristic = this.heuristicaAStar(vizinho, alvo.position);
        novo.parent = atual;
        if (this.colisores.HasTile(vizinho))
        {
            vizinhos.Add(novo);
        }


        // x - 1 e y 
        vizinho = new Vector3Int(posCell.x - 1, posCell.y, posCell.z);
        novo = new Cell(vizinho);
        novo.cost = g + 1;
        novo.heuristic = this.heuristicaAStar(vizinho, alvo.position);
        novo.parent = atual;
        if (this.colisores.HasTile(vizinho))
        {
            vizinhos.Add(novo);
        }

        // x - 1 e y +1
        vizinho = new Vector3Int(posCell.x - 1, posCell.y + 1, posCell.z);
        novo = new Cell(vizinho);
        novo.cost = g + 1;
        novo.heuristic = this.heuristicaAStar(vizinho, alvo.position);
        novo.parent = atual;
        if (this.colisores.HasTile(vizinho))
        {
            vizinhos.Add(novo);
        }

        // x e y-1
        vizinho = new Vector3Int(posCell.x, posCell.y - 1, posCell.z);
        novo = new Cell(vizinho);
        novo.cost = g + 1;
        novo.heuristic = this.heuristicaAStar(vizinho, alvo.position);
        novo.parent = atual;
        if (this.colisores.HasTile(vizinho))
        {
            vizinhos.Add(novo);
        }

        // x e y+1
        vizinho = new Vector3Int(posCell.x, posCell.y + 1, posCell.z);
        novo = new Cell(vizinho);
        novo.cost = g + 1;
        novo.heuristic = this.heuristicaAStar(vizinho, alvo.position);
        novo.parent = atual;
        if (this.colisores.HasTile(vizinho))
        {
            vizinhos.Add(novo);
        }

        // x+1 e y-1
        vizinho = new Vector3Int(posCell.x + 1, posCell.y - 1, posCell.z);
        novo = new Cell(vizinho);
        novo.cost = g + 1;
        novo.heuristic = this.heuristicaAStar(vizinho, alvo.position);
        novo.parent = atual;
        if (this.colisores.HasTile(vizinho))
        {
            vizinhos.Add(novo);
        }

        // x+1 e y
        vizinho = new Vector3Int(posCell.x + 1, posCell.y, posCell.z);
        novo = new Cell(vizinho);
        novo.cost = g + 1;
        novo.heuristic = this.heuristicaAStar(vizinho, alvo.position);
        novo.parent = atual;
        if (this.colisores.HasTile(vizinho))
        {
            vizinhos.Add(novo);
        }

        // x+1 e y+1
        vizinho = new Vector3Int(posCell.x + 1, posCell.y + 1, posCell.z);
        novo = new Cell(vizinho);
        novo.cost = g + 1;
        novo.heuristic = this.heuristicaAStar(vizinho, alvo.position);
        novo.parent = atual;
        if (this.colisores.HasTile(vizinho))
        {
            vizinhos.Add(novo);
        }

        return vizinhos;
    }

    private List<Cell> ReconstruirCaminho(Cell atual)
    {
        List<Cell> caminho = new List<Cell>();

        Cell iterador = atual;
        while (iterador.parent != null)
        {
            caminho.Add(iterador);
            iterador = iterador.parent;
        }

        caminho.Reverse();
        return caminho;
    }

}

