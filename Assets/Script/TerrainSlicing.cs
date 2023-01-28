using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSlicing : MonoBehaviour
{
    public Transform TerrParent; //Tarrain parent
    public GameObject TerrainObj; //Tarrain prefab
    public GameObject Player; //Player

    private Dictionary<(int x, int y), GameObject> TerrainLoaded; //Remove already loaded terrain
    private Dictionary<(int x, int y), GameObject> DictTemp; //Record temporarily stored terrain
    private Dictionary<(int x, int y), GameobjAndCoroutine> UnloadTerrCountDown; //Upcoming Terrain Records for Hidden Display
    private Stack<GameObject> TerrainPool;
    private (int x, int y) LastPos = (0, 0); //Player's last position

    struct GameobjAndCoroutine
    {
        public GameObject Go;
        public Coroutine Cor;
    }
    private void Awake()
    {
        TerrainLoaded = new Dictionary<(int x, int y), GameObject>();
        DictTemp = new Dictionary<(int x, int y), GameObject>();
        UnloadTerrCountDown = new Dictionary<(int x, int y), GameobjAndCoroutine>();
        TerrainPool = new Stack<GameObject>();
    }

    void Start()
    {
        //Check the matrix around the character
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if (TerrainLoaded.TryGetValue((i, j), out GameObject terr)) //Check if the terrain at the current location has been loaded
                {
                    DictTemp.Add((i, j), terr);//
                    TerrainLoaded.Remove((i, j));
                    terr.transform.position = new Vector3(i * 10f, 0f, j * 10f);
                    terr.SetActive(true);
                }
                else
                {
                    if (UnloadTerrCountDown.TryGetValue((i, j), out GameobjAndCoroutine val)) //Check if UnloadTerrCountDown has already stored the game object of the terrain
                    {
                        StopCoroutine(val.Cor);
                        DictTemp.Add((i, j), val.Go);
                        UnloadTerrCountDown.Remove((i, j));
                        val.Go.transform.position = new Vector3(i * 10f, 0f, j * 10f);
                        val.Go.SetActive(true);
                    }
                    else
                    {
                        var newTerr = GetTerrain(); //Generate terrain
                        DictTemp.Add((i, j), newTerr);
                        newTerr.transform.position = new Vector3(i * 10f, 0f, j * 10f);
                        newTerr.SetActive(true);
                    }
                }
            }
        }
        (TerrainLoaded, DictTemp) = (DictTemp, TerrainLoaded);
    }

    ///Get a terrain object
    private GameObject GetTerrain()
    {
        if (TerrainPool.Count > 0) //Check if there is terrain in the terrain pool
        {
            return TerrainPool.Pop(); //Remove one of the terrains
        }
        return Instantiate(TerrainObj, TerrParent); //Generate 1 terrain object
    }
    void Update()
    {
        
    }
}
