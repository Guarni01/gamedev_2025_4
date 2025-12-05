using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public float spawnRange;
    public int waveSize;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }


    void SpawnEnemyWave(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            //spawn enemy
            Instantiate(enemyPrefab, //what
            GetSpawnPoint(), //where
            enemyPrefab.transform.rotation); //how
        }
        //spawn powerup
        Instantiate(powerupPrefab,GetSpawnPoint(),enemyPrefab.transform.rotation);
    }




    public Vector3 GetSpawnPoint()

    {
        float x = Random.Range(-spawnRange, spawnRange);
        float z = Random.Range(-spawnRange, spawnRange);
        return new Vector3(x, 0, z);    
    }
    // Update is called once per frame
    void Update()
    {
        int survivingEnemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if(survivingEnemies == 0)
        {
            SpawnEnemyWave(waveSize);
            waveSize++;
        }
    }
}
