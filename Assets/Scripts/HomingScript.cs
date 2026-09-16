using UnityEngine;

public class HomingScript : MonoBehaviour
{
    public float bulletTime;
    public GameObject robo;
    public float bulletSpeed;

    void Start()
    {
        robo = GameObject.Find("Robo");
        bulletTime = 0;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, robo.transform.position, bulletSpeed * Time.deltaTime);

        bulletTime += Time.deltaTime;
        if (bulletTime >= 3)
        {
            Destroy(gameObject);
        }
    }
}
