using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBonusAutoSpawn : MonoBehaviour
{
    public Transform Player;
    public GameObject PrefabToSpawn;
    public float SpawnRate = 1f;
    public int MaxSpawn = 1;
    public bool Respawn;

    private int NbIsSpawn;
    private float NextSpawn;
    private int Nb;

    private void Update()
    {
        if(Time.time > NextSpawn && Nb < MaxSpawn)
        {
            NextSpawn = Time.time + SpawnRate;
            GameObject GO = Instantiate(PrefabToSpawn, transform.position, Quaternion.identity) as GameObject;
            GO.name = "Heal_Bonus";
            Nb++;
        }
        if (Respawn)
        {
            NbIsSpawn = 0;

            foreach (GameObject En in FindObjectsOfType(typeof(GameObject)) as GameObject[])
            {
                if (En.name == "Heal_Bonus")
                {
                    NbIsSpawn++;
                }
            }

            if (NbIsSpawn < MaxSpawn)
            {
                Nb = NbIsSpawn;
            }
        }
    }
}
