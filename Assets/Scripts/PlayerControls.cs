using UnityEngine;
using TMPro;

public class PlayerControls : MonoBehaviour
{
    public TextMeshProUGUI controlText;
    public TextMeshProUGUI healthText;
    public float speed;
    private Camera cam;
    private Vector3 mousePos;
    public float weaponTime;
    public int scootHealth;
    public GameObject realExplosion;

    public bool stateOne;
    public bool stateTwo;
    public bool stateThree;
    public GameObject bullet;
    public GameObject bomb;
    public GameObject spreadshot;
    public Transform bulletTrans;
    public int weaponState;
    
    public bool canFireOne;
    public bool canFireTwo;
    private float timerOne;
    private float timerTwo;
    public float timeBetweenOne;
    public float timeBetweenTwo;


    void Start()
    {
        cam = Camera.main;
        weaponState = 0;
        scootHealth = 10;
    }

    void Update()
    {
        healthText.text = "Health: " + scootHealth;

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0f, -speed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }

        mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        float angleRad = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad - 90;
        transform.rotation = Quaternion.Euler(0f, 0f, angleDeg);

        weaponTime += Time.deltaTime;

        if(weaponTime >= 10)
        {
            weaponState = Random.Range(0, 3);
            weaponTime = 0;
        }
        
        if (weaponState == 0)
        {
            stateOne = true;
            stateTwo = false;
            stateThree = false;
            controlText.text = "LMB to Shoot";
        }
        else if (weaponState == 1)
        {
            stateTwo = true;
            stateOne = false;
            stateThree = false;
            controlText.text = "RMB to Fire Bombs";
        }
        else if (weaponState == 2)
        {
            stateThree = true;
            stateTwo = false;
            stateOne = false;
            controlText.text = "E to Plant Bombs";
        }

        if (!canFireOne)
        {
            timerOne += Time.deltaTime;
            if(timerOne > timeBetweenOne)
            {
                canFireOne = true;
                timerOne = 0;
            }
        }
        if (!canFireTwo)
        {
            timerTwo += Time.deltaTime;
            if (timerTwo > timeBetweenTwo)
            {
                canFireTwo = true;
                timerTwo = 0;
            }
        }

        if (stateOne && Input.GetMouseButton(0) && canFireOne)
        {
            canFireOne = false;
            Instantiate(bullet, bulletTrans.position, Quaternion.identity);
        }
        if (stateTwo && Input.GetMouseButton(1) && canFireTwo)
        {
            canFireTwo = false;
            Instantiate(bomb, bulletTrans.position, Quaternion.identity);
        }
        if (stateThree && Input.GetKey(KeyCode.E) && canFireTwo)
        {
            canFireTwo = false;
            Instantiate(spreadshot, bulletTrans.position, Quaternion.identity);
        }

        if(scootHealth <= 0)
        {
            Instantiate(realExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D robo)
    {
        if (robo.CompareTag("Robo"))
        {
            scootHealth -= 2;
        }
    }
}
