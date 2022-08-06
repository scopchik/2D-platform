using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int Height, Width;
    public Transform Zero;
    public GameObject Cell;

    void Start()
    {
        Generate();
    }
    public void Generate()
    {
        int groundHeight = 3;
        for (int x = 0; x < Width; x++)
        {
            if (x % 2 == 0)
            {
                groundHeight += Random.Range(-1,2);
            }
            for (int y = groundHeight; y > 0; y--)
            {
                GameObject cell = Instantiate(Cell,Zero);
                cell.transform.localPosition = new Vector3(x, y, 0);
            }
        }
    }
}
