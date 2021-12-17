
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MonsterWave : MonoBehaviour
{
    public Transform Player;
    public PlayerMouvement playerMouvement;
    public GameObject PrefabToSpawn;
    public float SpawnRate = 3f;
    public int MaxSpawn = 3;

    //score displayer :
    public Text ScoreCountDisplay;
    public Text GMScoreCountDisplay;

    public int Score;
    public int ScorePerWave;

    //temps avant le prochain spawn
    private float NextSpawn;
    //nombre de mob a spawn dans la vague
    private int Nb;
    //nombre de mob en vie
    private int NbIsLife;
    

    void Update()
    {
           //spawn un mob si le spawn rate dépasser et nombre de mob
        if (Time.time > NextSpawn && Nb < MaxSpawn)
        {
            NextSpawn = Time.time + SpawnRate;
            GameObject GO = Instantiate(PrefabToSpawn, transform.position, Quaternion.identity) as GameObject;
            GO.name = "Enemy";
            //nombre de monstre spawn
            Nb++;
        }

        //compte le nombre de mob qui y'a en vie
        foreach ( GameObject Enemy in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if(Enemy.name == "Enemy")
            {
                NbIsLife++;
                //Debug.Log("NbIsLife" + NbIsLife);
            }

        }

        //dès que tous les mobs de la vague sont morts, start le prochaine vague après x temps
        if (NbIsLife == 0 && Nb == MaxSpawn)
        {


            //s'execute lors du début de la nouvelle vague
            if (Time.time > NextSpawn + 5 && Nb == MaxSpawn)
            {
                Nb = 0;
                MaxSpawn += 2;

                //augmente la stat de saut
                playerMouvement.addJump(50);

                NextSpawn = Time.time + SpawnRate;

                Score += ScorePerWave;
                ScoreCountDisplay.text = Score.ToString();
                GMScoreCountDisplay.text = Score.ToString();


            }
        }
        NbIsLife = 0;

    }
}
