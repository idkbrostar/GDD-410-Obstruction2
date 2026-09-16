using UnityEngine;

public class RoboMovement : MonoBehaviour
{
    public float roboSpeed;
    public int roboHealth;
    public GameObject realExplosion;
    public GameObject scooter;
    
    void Start()
    {
        roboHealth = 6;
        scooter = GameObject.Find("Scooter");
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, scooter.transform.position, roboSpeed * Time.deltaTime);
        if(roboHealth <= 0)
        {
            Instantiate(realExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            roboHealth -= 2;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Bomb"))
        {
            roboHealth -= 6;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Spreadshot"))
        {
            roboHealth -= 6;
            Destroy(other.gameObject);
        }
    }
}
