using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject deathEffectObject;

    bool playerIsDead = false;

    Rigidbody2D PlayerRigi;

    float angle = 0;

    int xSpeed = 3;

    int ySpeed = 30;

    GameManager gameManagerObject;

   



    void Awake()
    {
        PlayerRigi = GetComponent<Rigidbody2D>();
        gameManagerObject = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

   
    private void FixedUpdate()
    {
        if (playerIsDead == true) return;
        PlayerInput();
        PlayerMovement();
        
    }

    void PlayerMovement()
    {

        Vector2 pos = transform.position;
        pos.x = Mathf.Cos(angle) * 5;
        
        transform.position = pos;
        angle += Time.deltaTime * xSpeed;
    }

    void PlayerInput()
    {
        if (Input.GetMouseButton(0))
        {
            
            PlayerRigi.AddForce(new Vector2(0, ySpeed));
        }
        else
        {
            if(PlayerRigi.velocity.y > 0)
            {
                PlayerRigi.AddForce(new Vector2(0, -ySpeed/2));
            }
            else
            {
                PlayerRigi.velocity = new Vector2(PlayerRigi.velocity.x, 0);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            PlayerDeath();
        }
        else if(other.gameObject.tag == "Item")
        {
            gameManagerObject.ScoreIncrement();
            Destroy(other.gameObject);
        }
               
        
    }

    void PlayerDeath()
    {
        playerIsDead = true;
        Destroy(Instantiate(deathEffectObject, transform.position, Quaternion.identity), 0.5f);
        StopPlayerMovement();
        gameManagerObject.GameOver();
    }

    void StopPlayerMovement()
    {
        PlayerRigi.velocity = new Vector2(0, 0);
        PlayerRigi.isKinematic = true;
    }
}
