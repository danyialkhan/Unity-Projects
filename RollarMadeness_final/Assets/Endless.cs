using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endless : MonoBehaviour
{
    public GameObject currentTile;
    public GameObject Tile1;
    public GameObject Tile2;
    public int noOfBlocks;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < noOfBlocks; i++)
        {
            generateTile(i);
        }
    }

    void generateTile(int i)
    {
        if(i%2==0)
            currentTile = (GameObject)Instantiate(Tile1, currentTile.transform.GetChild(0).position, Quaternion.identity);
          else
            currentTile = (GameObject)Instantiate(Tile2, currentTile.transform.GetChild(0).position, Quaternion.identity);
            
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
