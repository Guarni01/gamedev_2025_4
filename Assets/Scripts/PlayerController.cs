using System.Xml.Serialization;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody body;
    public float force;
    public GameObject focalPoint;
    private bool hasPowerup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
        hasPowerup = false;
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        body.AddForce(focalPoint.transform.forward * verticalInput);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasPowerup && collision.collider.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collision with" +collision.collider.gameObject.name + "while having a powerup");
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
        }
    }
}
