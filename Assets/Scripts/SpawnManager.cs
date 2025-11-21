using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
        Instantiate(enemyPrefab, //what
            GetSpawnPoint(), //where
            enemyPrefab.transform.rotation); //how
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
        
    }
}
