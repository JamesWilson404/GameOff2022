using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] int WorldWidth;
    [SerializeField] GameObject ChunkPrefab;
    

    private void Start()
    {

        //  Spawn Chunks
        for (int i = 0; i < WorldWidth; i++)
        {
            GameObject WestChunk = Instantiate(ChunkPrefab, new Vector3(-10 - (10 * (i + 1)), 0), Quaternion.identity, this.transform);
            WestChunk.name = "Chunk W" + (i + 1).ToString();
            GameObject EastChunk = Instantiate(ChunkPrefab, new Vector3(10 + (10 * (i + 1)), 0), Quaternion.identity, this.transform);
            EastChunk.name = "Chunk E" + (i + 1).ToString();

            EastChunk.GetComponent<Chunk>().Initialize((i + 1));
            WestChunk.GetComponent<Chunk>().Initialize((i + 1)*-1);


        }


    }


}
