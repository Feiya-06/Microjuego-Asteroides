using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed = 2.5f;

    public GameObject smallMeteorPrefab;
    public bool isBigMeteor = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right*speed;
        Destroy(gameObject, 10f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet"))
        {
            if (isBigMeteor && smallMeteorPrefab != null)
            {
                SplitMeteor();
            }
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject); //nave
            GameManager.instance.GameOver();
        }
    }

    void SplitMeteor()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject miniMeteor = Instantiate(smallMeteorPrefab, transform.position, Quaternion.identity);
            float randomAngle = Random.Range(-45f, 45f);
            Vector2 randomDir = Quaternion.Euler(0, 0, randomAngle)*transform.right;

            miniMeteor.transform.right = randomDir;

            Rigidbody2D rbMini = miniMeteor.GetComponent<Rigidbody2D>();
            //Los pequeniosn van mas rapidos
            if (rbMini != null)
            {
                rbMini.linearVelocity = randomDir*(speed * 1.3f);
            }
        }
    }
}
