using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float thrustForce = 3f;
    public float rotationSpeed = 120f;
    public static int SCORE = 0;

    public GameObject bulletPrefab;
    public Transform firePoint;

    Vector2 thrustDirection;
    Rigidbody2D _rigidbody;

    public float fireRate = 0.1f;
    private float nextFireTime = 0f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        float thrust = Input.GetAxis("Vertical") * thrustForce;

        thrustDirection = transform.right;
        transform.Rotate(Vector3.forward, -rotation);
        _rigidbody.AddForce(thrust*thrustDirection);

        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        // sale por la derecha, aparece por la izquierda
        if (viewportPos.x > 1f) viewportPos.x = 0f;
        else if (viewportPos.x < 0f) viewportPos.x = 1f;

        // Si sale por arriba, aparece por abajo
        if (viewportPos.y > 1f) viewportPos.y = 0f;
        else if (viewportPos.y < 0f) viewportPos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(viewportPos);
   
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime){
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = BulletPool.instance.GetPooledObject();

        if(bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }
    }
}
