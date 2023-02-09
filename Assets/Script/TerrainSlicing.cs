using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSlicing : MonoBehaviour
{
    public Transform TerrParent; //Tarrain parent
    public GameObject TerrainObj; //Tarrain prefab
    public GameObject Player; //Player
    public GameObject MainCamera; //Camera

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
                    terr.transform.position = new Vector3(i * 12f, 0f, j * 12f);
                    terr.SetActive(true);
                }
                else
                {
                    if (UnloadTerrCountDown.TryGetValue((i, j), out GameobjAndCoroutine val)) //Check if UnloadTerrCountDown has already stored the game object of the terrain
                    {
                        StopCoroutine(val.Cor);
                        DictTemp.Add((i, j), val.Go);
                        UnloadTerrCountDown.Remove((i, j));
                        val.Go.transform.position = new Vector3(i * 12f, 0f, j * 12f);
                        val.Go.SetActive(true);
                    }
                    else
                    {
                        var newTerr = GetTerrain(); //Generate terrain
                        DictTemp.Add((i, j), newTerr);
                        newTerr.transform.position = new Vector3(i * 12f, 0f, j * 12f);
                        newTerr.SetActive(true);
                    }
                }
            }
        }
        (TerrainLoaded, DictTemp) = (DictTemp, TerrainLoaded);
    }

    private void FixedUpdate()
    {
        if (Player != null)
        {
            //Record player position on the map
            (int x, int y) pos = (Mathf.RoundToInt(Player.transform.position.x / 12f), Mathf.RoundToInt(Player.transform.position.z / 12f));
            if (!(pos == LastPos))//Player get in to a new area when position is changed
            {
                LastPos = pos;
                MainCamera.transform.position = new Vector3(pos.x*12, 12, pos.y*12);
                DictTemp.Clear();
                //Check the matrix of new area around the character
                for (int i = pos.x - 1; i < pos.x + 2; i++)
                {
                    for (int j = pos.y - 1; j < pos.y + 2; j++)
                    {
                        if (TerrainLoaded.TryGetValue((i, j), out GameObject terr))//If TerrainLoaded has already keep the gameobject of current Terrain
                        {
                            DictTemp.Add((i, j), terr);
                            TerrainLoaded.Remove((i, j));
                            terr.transform.position = new Vector3(i * 12f, 0f, j * 12f);
                            terr.SetActive(true);
                        }
                        else
                        {
                            if (UnloadTerrCountDown.TryGetValue((i, j), out GameobjAndCoroutine val))//If UnloadTerrCountDown has already keep the gameobject of current Terrain
                            {
                                StopCoroutine(val.Cor);//Stop the coroutine that hides the plot, when the player leaves the plot at this time but returns to the plot within 3 seconds
                                DictTemp.Add((i, j), val.Go);
                                UnloadTerrCountDown.Remove((i, j));
                                val.Go.transform.position = new Vector3(i * 12f, 0f, j * 12f);
                                val.Go.SetActive(true);
                            }
                            else
                            {
                                var newTerr = GetTerrain();
                                DictTemp.Add((i, j), newTerr);
                                newTerr.transform.position = new Vector3(i * 12f, 0f, j * 12f);
                                newTerr.SetActive(true);
                            }
                        }
                    }
                }
                foreach (var item in TerrainLoaded)//Viewing TerrainLoaded, the objects in TerrainLoaded at this time are not in the character's current nine-square circle, so the view is ready to hide and display
                {
                    UnloadTerrCountDown.Add(item.Key, new GameobjAndCoroutine
                    {
                        Cor = StartCoroutine(RemoveTerrDelay(item.Key)),// Start the progress of floor display
                        Go = item.Value,
                    });
                }
                TerrainLoaded.Clear();
                (TerrainLoaded, DictTemp) = (DictTemp, TerrainLoaded);
            }
        }
    }

    /// <summary>
    /// Cancle display of terrain
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    private IEnumerator RemoveTerrDelay((int x, int y) pos)
    {
        yield return new WaitForSeconds(3f);//Wait for 3 Secends to hide terrain dispaly
        if (UnloadTerrCountDown.TryGetValue(pos, out var v))
        {
            RecycleTerrain(v.Go);
            UnloadTerrCountDown.Remove(pos);
        }
    }

    /// <summary>
    /// Get a Terrain object
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Recycle terrain
    /// </summary>
    /// <param name="t"></param>
    private void RecycleTerrain(GameObject t)
    {
        t.SetActive(false);
        TerrainPool.Push(t);
    }
}
