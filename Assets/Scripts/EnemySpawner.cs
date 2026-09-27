using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] meteorPrefab;
    public float spawnRate = 30;
    public float spawnRateIncrement = 1f;

    public float xBorderLimit, yBorderLimit;

    private float spawnNext = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*void Start()
    {
        InvokeRepeating(nameof(Update), 1f, spawnRate);
    }*/

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + 60 / spawnRate;
            spawnRate += spawnRateIncrement;

            var x = Random.Range(-xBorderLimit, xBorderLimit);
            var spawnPos = new Vector2(x, yBorderLimit);

            int randomSpawn = Random.Range(0, meteorPrefab.Length);
            GameObject meteorSpawn = meteorPrefab[randomSpawn];

            GameObject meteor = Instantiate(meteorSpawn, spawnPos, Quaternion.identity);
           
            Vector2 direction = -spawnPos;
            meteor.transform.right = direction;
        }
       
    }
}
