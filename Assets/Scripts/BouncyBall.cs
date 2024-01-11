using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BouncyBall : MonoBehaviour
{
    public float minY = -5.5f;
    public float maxVelocity = 15f;
   
    Rigidbody2D rb;

    byte lives = 5;
    float score;

    public TextMeshProUGUI scoreText;
    public GameObject[] liveImage;

    public GameObject gameOverPanel;
    public GameObject youWinPanel;
    int brickCount;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        brickCount = FindObjectOfType<LevelGenrator>().transform.childCount;
        rb.velocity = Vector2.down * 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY)
        {
            if(lives <= 0)
            {
                GameOver();
            }
            else
            {
                transform.position = Vector2.zero;
                rb.velocity = Vector2.down * 10f;
                lives--;
                liveImage[lives].SetActive(false);
            }
           

        }

        if(rb.velocity.magnitude > maxVelocity)
        {

            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            score += 10;
            scoreText.text = score.ToString("00000");
            brickCount--;
            if(brickCount <= 0)
            {
                youWinPanel.SetActive(true);
                Time.timeScale = 0;
            }
        
        }
    }

    void GameOver()
    {
       gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);
    }
}
