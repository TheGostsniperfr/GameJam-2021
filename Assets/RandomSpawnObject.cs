using UnityEngine;

public class RandomSpawnObject : MonoBehaviour
{
    public Vector2[] positions;

    void Start()
    {
        int randomNumber = Random.Range(0, positions.Length);
        Debug.Log(randomNumber);
        Debug.Log(positions.Length);

        transform.position = positions[randomNumber];
    }
}
