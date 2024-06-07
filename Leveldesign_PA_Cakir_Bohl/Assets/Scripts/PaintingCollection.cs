using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingCollection : MonoBehaviour
{
    public int pieces;

    public bool isPaintingWhole;
    
    // Start is called before the first frame update
    void Start()
    {
        isPaintingWhole = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pieces == 3)
        {
            print("alles gefunden");
            isPaintingWhole = true;
        }
    }

    private void PieceCollected()
    {
        pieces++;
    }
}
