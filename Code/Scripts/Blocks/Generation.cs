using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public int sizex;
    public int sizez;
    int seed;
    public int GroundHeight;
    public float Detail;
    public float terainHeight;

    public GameObject player;
    public GameObject[] blocks;
    // Start is called before the first frame update
    void Start()
    {
        seed = Random.Range(100, 100000);
        GenerateTerrain();
    }
    // Update is called once per frame
    void Update()
    {
    }
    void GenerateTerrain()
    {
        for (int x = 0; x < sizex; x++)
        {
            for (int z = 0; z < sizez; z++)
            {

                int maxY = (int)(Mathf.PerlinNoise((z / 2 + seed) / Detail, (x / 2 + seed) / Detail) * terainHeight);
                maxY += GroundHeight;
                Instantiate(blocks[0], new Vector3(x, maxY, z), Quaternion.identity, transform);
                for (int y = 0; y < maxY; y++)
                {
                    int dirtLayer = Random.Range(1, 4);
                    if (y >= maxY - dirtLayer)
                    {
                        Instantiate(blocks[1], new Vector3(x, y, z), Quaternion.identity, transform);
                    }
                    else
                    {
                        Instantiate(blocks[2], new Vector3(x, y, z), Quaternion.identity, transform);
                    }
                    if (!GameObject.FindWithTag("Player"))
                        Instantiate(player, new Vector3(x, maxY + 3, z), Quaternion.identity);
                }
            }
        }
    }
}