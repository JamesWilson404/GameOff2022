using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public static Game instance;
    public System.Random Rand;
    public float MapSeed;

    private void Awake()
    {
        if (Game.instance != null)
        {
            Destroy(this.gameObject);
        }

        Game.instance = this;

        Rand = new System.Random((int)System.DateTime.Now.TimeOfDay.TotalSeconds);
        MapSeed = (float)(Rand.NextDouble() * Rand.Next(-1000, 1000));

    }

}
