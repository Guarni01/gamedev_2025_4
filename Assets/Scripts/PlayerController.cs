using System.Collections;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody body;
    public float force;
    public GameObject focalPoint;
    private bool hasPowerup;
    public float powerupStrenght;
    public GameObject indicator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void SwitchoffPowerUp()
    {
        hasPowerup = false;
        indicator.SetActive(false);
    }


    void SwitchOnPowerUp()
    {
        hasPowerup = true;
        indicator.SetActive(true);
    }
   
    
    void SetPowerup(bool active)
    {
        hasPowerup = active;
        indicator.SetActive(active);
    }



    void Start()
    {
        body = GetComponent<Rigidbody>();
        SetPowerup(false);

    }

    // Update is called once per frame
    void Update()
    {
        indicator.transform.position = transform.position + (Vector3.down * 0.45f);

        float verticalInput = Input.GetAxis("Vertical");
        body.AddForce(focalPoint.transform.forward * verticalInput);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasPowerup && collision.collider.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collision with" +collision.collider.gameObject.name + "while having a powerup");

            Rigidbody enemyBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;
            enemyBody.AddForce(powerupStrenght * awayFromPlayer, ForceMode.Impulse);
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            SetPowerup(true);
            Destroy(other.gameObject);

            StopAllCoroutines();
            StartCoroutine(PowerupCountDown());
        }
    }

    IEnumerator PowerupCountDown()
    {
        yield return new WaitForSeconds(6);
        Debug.Log("Powerup almost depleted");
        yield return new WaitForSeconds(2);
        Debug.Log("Powerup DEPLETED");
        SetPowerup(false); 
    }

}
         