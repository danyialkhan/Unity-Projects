using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DNA
{
    List<int> genes = new List<int>();
    int dnaLength = 0;
    int maxValue = 0;
    public DNA(int l, int v)
    {
        dnaLength = l;
        maxValue = v;
        SetRandom();
    }

    private void SetRandom()
    {
        genes.Clear();
        for(int i = 0; i < dnaLength; i++)
        {
            genes.Add(Random.Range(0, maxValue));
        }
    }

    public void setInt(int pos, int value)
    {
        genes[pos] = value;
    }

    public void combine(DNA d1, DNA d2)
    {
        for(int i = 0; i < dnaLength; i++)
        {
            if (i < dnaLength / 2)
            {
                int c = d1.genes[i];
                genes[i] = c;
            }
            else
            {
                int c = d2.genes[i];
                genes[i] = c;
            }
        }
    }

    public void Mutate()
    {
        genes[Random.Range(0, dnaLength)] = Random.Range(0, maxValue);
    }
    public int GetGenes(int pos)
    {
        return genes[pos];
    }
}
