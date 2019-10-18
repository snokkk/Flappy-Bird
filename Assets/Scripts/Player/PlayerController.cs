using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [Inject]
    private GameConfig gameConfig;
    [Inject]
    private GameController gameController;
    [Inject]
    private ScoreManager scoreManager;
    [Inject]
    private SoundManager soundManager;

    private float jumpForce;
    private Rigidbody2D playerRb;
    public Rect controlOffsetRect;

    private void Awake()
    {
        controlOffsetRect = new Rect(0, 0, Screen.width, Screen.height/1.2f);
        jumpForce = gameConfig.playerJumpForce;
    }

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        jumpForce = gameConfig.playerJumpForce;

        if (gameController.isPlaying)
        {


#if UNITY_EDITOR

            if (Input.GetMouseButtonDown(0))
            {
                if (controlOffsetRect.Contains(Input.mousePosition))
                {
                    soundManager.PlayWing();
                    playerRb.velocity = Vector2.up * jumpForce;
                }
            }

#elif UNITY_ANDROID
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (controlOffsetRect.Contains(Input.GetTouch(0).position))
                    {
                        soundManager.PlayWing();
                        playerRb.velocity = Vector2.up * jumpForce;
                    }
            }
                    
#endif
        }

    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "pipe")
        {
            soundManager.PlayHit();
            gameController.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "pipeScore")
        {
            soundManager.PlayPoint();
            scoreManager.GetScore();
        }
    }
}
