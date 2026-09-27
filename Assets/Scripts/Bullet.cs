using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public float lifeTime = 3f;

    void OnEnable()
    {
        Invoke("Deactivate", lifeTime);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right*speed;
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            IncreaseScore(); 
            Destroy(other.gameObject);
            gameObject.SetActive(false);
        }
    }

    public void IncreaseScore()
    {
        PlayerMovement.SCORE++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<TextMeshProUGUI>().text = "Score: " + PlayerMovement.SCORE;
    }
}
