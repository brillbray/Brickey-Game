using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float startSpeed;
    public float extraSpeed;
    public float maxExtraSpeed;

    public bool player1Start = true;

    private int hitCount = 0;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Launch());
    }

    private void RestartRound()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
    }
    public IEnumerator Launch(){
        RestartRound();
        hitCount = 0;
        yield return new WaitForSeconds(1);
        if(player1Start == true)
        {
            MoveBall(new Vector2(-1, 0));
        }
        else
        {
            MoveBall(new Vector2(1, 0));
        }    
    }
    public void MoveBall(Vector2 direction){
        direction = direction.normalized;

        float ballSpeed = startSpeed + hitCount * extraSpeed;

        rb.velocity = direction * ballSpeed;
    }

    public void IncreaseHitCount(){
        if(hitCount * extraSpeed < maxExtraSpeed){
            hitCount++;
        }
    }
    
}
