using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBall : MonoBehaviour
{
    public float speed;
    public Text scoreText;

    private Rigidbody rbody;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        score = 0;
        scoreText.text = "Score: ";
    }

    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveH, 0.0f, moveV);

        rbody.AddForce(move * speed);
    }

    void OnTriggerEnter(Collider cube)
    {
       cube.gameObject.SetActive(false);
            if (cube.CompareTag("Blue"))
            {
                score += 10;
            }
            else if (cube.CompareTag("Green"))
            {
                score += 20;
            }
            if (cube.CompareTag("Yellow"))
            {
                score += 30;
            }
            SetScore();
    }

    // Set score function to update score when ball collides. Also tells user when they win
    void SetScore()
    {
        scoreText.text = "Score: " + score.ToString();

        if (score >= 190)
        {
            scoreText.text = "You Win!";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}