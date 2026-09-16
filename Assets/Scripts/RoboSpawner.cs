using UnityEngine;

public class RoboSpawner : MonoBehaviour
{
    public float globalTimer;
    public float roboTimer;
    public bool roboSpawn;
    public float roboBetween;
    public GameObject robo;
    
    void Start()
    {
        globalTimer = 0f;
        roboTimer = 0f;
        roboSpawn = true;
    }

    void Update()
    {
        globalTimer += Time.deltaTime;

        if(globalTimer < 15f)
        {
            roboBetween = 4f;
        }
        if(globalTimer >= 15f && globalTimer < 30f)
        {
            roboBetween = 3.6f;
        }
        if(globalTimer >= 30f && globalTimer < 45f)
        {
            roboBetween = 3.3f;
        }
        if (globalTimer >= 45f)
        {
            roboBetween = 2f;
        }

        if(!roboSpawn)
        {
            roboTimer += Time.deltaTime;
            if(roboTimer > roboBetween)
            {
                roboSpawn = true;
                roboTimer = 0f;
            }
        }
        if(roboSpawn)
        {
            Instantiate(robo, new Vector3(-10, Random.Range(-5, 5), 0), Quaternion.identity);
            Instantiate(robo, new Vector3(10, Random.Range(-5, 5), 0), Quaternion.identity);
            roboSpawn = false;

        }
    }
}
