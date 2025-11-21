using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float forceIntensity;
    private GameObject player;
    private Rigidbody body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 enemyToPlayerDistance = player.transform.position - transform.position;
        Vector3 direction = enemyToPlayerDistance.normalized;
        Vector3 force = direction * forceIntensity;
        body.AddForce(force);
    }
}
