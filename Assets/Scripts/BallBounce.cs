using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallBounce : MonoBehaviour
{
    public GameObject hitSFX;

    public BallMovement ballMovement;
    public ScoreManager scoreManager;
    private void Bounce (Collision2D collision) {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;

        float posX;
    
        if(collision.gameObject.name == "P1")
        {
            posX = 1;
        }
        else
        {
            posX = -1;
        }

        float posY = (ballPosition.y - racketPosition.y) / racketHeight;

        ballMovement.IncreaseHitCount();
        ballMovement.MoveBall(new Vector2(posX, posY));
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "P1" || collision.gameObject.name == "P2")
        {
            Bounce(collision);
        }

        else if(collision.gameObject.name == "BorderPointLeft")
        {
            scoreManager.p2Goal();
            ballMovement.player1Start = false;
            StartCoroutine(ballMovement.Launch());
        }
        else if (collision.gameObject.name == "BorderPointRight")
        {
            scoreManager.p1Goal();
            ballMovement.player1Start = true;
            StartCoroutine(ballMovement.Launch());
        }

        Instantiate(hitSFX, transform.position, transform.rotation);
    }
}
