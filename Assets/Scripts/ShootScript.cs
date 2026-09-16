using UnityEngine;

public class ShootScript : MonoBehaviour
{
    private Camera cam;
    private Vector3 mousePos;
    private Rigidbody2D rb;
    public float force;
    public float bulletTime;

    void Start()
    {
        bulletTime = 0;
        cam = Camera.main;
        mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        rb = GetComponent<Rigidbody2D>();
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    void Update()
    {
        bulletTime += Time.deltaTime;
        if(bulletTime >= 3)
        {
            Destroy(gameObject);
        }
    }
}
