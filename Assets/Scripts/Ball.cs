using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    public float spd = 30;
    private Rigidbody2D rigidBody;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {

        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * spd;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        //left paddle or right paddle
        if ((col.gameObject.name == "p1") || (col.gameObject.name == "p2"))
        {

            AnguloPaddle(col);

        }
        //wall bottom or wall top
        if ((col.gameObject.name == "WallBottom") || (col.gameObject.name == "WallTop"))
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.wallBloop);
        }
        //left goal or right goal
        if ((col.gameObject.name == "LeftGoal") || (col.gameObject.name == "RightGoal"))
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.goalBloop);

            transform.position = new Vector2(-43, -24);

            if (col.gameObject.name == "LeftGoal")
            {
                AumentarScore("P2Score");
            }
            if (col.gameObject.name == "RightGoal")
            {
                AumentarScore("P1Score");
            } 
        }
    }
    void AnguloPaddle(Collision2D col)
    {
        float y = OndeAcertou(transform.position, col.transform.position, col.collider.bounds.size.y);

        Vector2 dir = new Vector2();

        if (col.gameObject.name == "p1")
        {
            dir = new Vector2(1, y).normalized;
        }
        if (col.gameObject.name == "p2")
        {
            dir = new Vector2(-1, y).normalized;
        }

        rigidBody.velocity = dir * spd;

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.hitPaddleBloop);
    }

    float OndeAcertou(Vector2 ball, Vector2 paddle, float paddleAltura)
    {
        return (ball.y - paddle.y) / paddleAltura;
    }

    void AumentarScore(string nomeTexto)
    {

        var textoComp = GameObject.Find(nomeTexto).GetComponent<Text>();

        int score = int.Parse(textoComp.text);
        score++;

        textoComp.text = score.ToString();
    }
}

