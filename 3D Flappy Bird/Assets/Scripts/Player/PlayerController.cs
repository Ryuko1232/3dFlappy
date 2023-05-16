using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public KeyCode jumpKey = KeyCode.Space;
    [SerializeField] float jumpVelocity = 5f;
    [SerializeField] AudioSource jumpAudio;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI gameOverScore;
    [SerializeField] TextMeshProUGUI highscoreText;

    Rigidbody rb;
    Animator animator;
    bool hasLost;
    int score;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Time.timeScale == 0f)
        {
            return;
        }
        if (hasLost)
        {
            return;
        }

        if(Input.GetKeyDown(jumpKey))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        jumpAudio.Play();
    }

    private void FixedUpdate()
    {
        animator.SetFloat("yVelocity",rb.velocity.y * 1000f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Pipe")
        {
            if (!hasLost)
            {
                GameOver();
            }
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.SetText(score.ToString());
    }

    private void GameOver()
    {
        hasLost = true;

        if(score > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", score);
        }

        gameOverScore.SetText("Score: " + score);
        highscoreText.SetText("Highscore: " + PlayerPrefs.GetInt("highscore", 0));
        gameOverScreen.SetActive(true);

        Debug.Log("Game Over");
    }
}
