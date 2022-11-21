using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] int chunkIndex;

    [SerializeField] GameObject MineParent;
    [SerializeField] GameObject MinePrefab;

    [SerializeField] float PerlinXScale;
    [SerializeField] float PerlinYScale;
    [SerializeField] float Threshold;

    [SerializeField] GameObject DebugTile;

    public void Initialize(int chunkIndex)
    {
        this.chunkIndex = chunkIndex;
        var offset = 0;
        if (chunkIndex < 0)
        {
            offset = -9;
        }
        else if (chunkIndex > 0)
        {
            offset = 11;
        }

        for (int j = 0; j < 6; j++)
        {
            float perlinVal;
            for (int i = 0; i < 10; i++)
            {
                float x = (chunkIndex * (10*PerlinXScale)) + i;
                float y = 4 + (j * PerlinYScale);
                perlinVal = getPerlinValue(x, y);
                if (perlinVal >= Threshold)
                {
                    //dbg.GetComponentInChildren<TMP_Text>().color = Color.green;
                    GameObject newTile = MinePrefab;
                    if (newTile != null)
                    {
                         Instantiate(newTile, new Vector3(4 - i + (chunkIndex * 10) + offset, 0, 4.5f + j), Quaternion.identity, MineParent.transform).GetComponent<MineTile>().Init(perlinVal, Mathf.Abs(chunkIndex)+i);
                    }
                }

                y = -4 - (j* PerlinYScale);
                perlinVal = getPerlinValue(x, y);
                if (perlinVal >= Threshold)
                {
                    //dbg.GetComponentInChildren<TMP_Text>().color = Color.green;
                    GameObject newTile = MinePrefab;
                    if (newTile != null)
                    {
                        Instantiate(newTile, new Vector3(4 - i + (chunkIndex * 10) + offset, 0, -4.5f - j), Quaternion.identity, MineParent.transform).GetComponent<MineTile>().Init(perlinVal, Mathf.Abs(chunkIndex) + i);
                    }
                }

            }
        }
    }



    private float getPerlinValue(float x, float y)
    {
        return Mathf.PerlinNoise(
            Game.instance.MapSeed + (x*PerlinXScale),
            Game.instance.MapSeed + (y *PerlinYScale)
            ) + Mathf.Abs(chunkIndex)/10;
    }




}
