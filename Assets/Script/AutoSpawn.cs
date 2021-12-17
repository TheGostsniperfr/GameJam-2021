using System.Collections;

using UnityEngine;

public class AutoSpawn : MonoBehaviour
{
    public Transform Player;
    public int SpawnRange;
    public GameObject PrefabToSpawn;
    public float SpawnRate = 3f;
    public int MaxSpawn = 3;
    public bool Respawn;

    private int NbIsSpawn;
    private float Range;
    private float NextSpawn;
    private int Nb;


    void Update()
    {
        Range = Vector3.Distance(transform.position, Player.position);

        if(Range < SpawnRange)
        {
            if (Time.time > NextSpawn && Nb < MaxSpawn)
            {
                NextSpawn = Time.time + SpawnRate;
                GameObject GO= Instantiate(PrefabToSpawn, transform.position, Quaternion.identity) as GameObject;
                GO.name = "E" + this.name;
                Nb++;
                
            }

        }
        if (Respawn)
        {
            NbIsSpawn = 0;

            foreach (GameObject En in FindObjectsOfType(typeof(GameObject)) as GameObject[])
            {
                if(En.name == "E" + this.name)
                {
                    NbIsSpawn++;
                }
            } 

            if(NbIsSpawn< MaxSpawn)
            {
                Nb = NbIsSpawn;
            }
        }
    }
}
