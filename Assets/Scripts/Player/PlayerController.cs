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
    

    private void Awake()
    {
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
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            RaycastHit[] _hit = Physics.RaycastAll(ray, Mathf.Infinity);
            foreach (var hit in _hit)
            {
                if (hit.transform.tag == "controlOffset")
                {
//#if UNITY_ANDROID
//                    if (Input.touchCount == 1) 
//                    {
//                        soundManager.PlayWing();
//                        playerRb.velocity = Vector2.up * jumpForce;
//                    }
//#else
                    if (Input.GetMouseButtonDown(0))
                    {
                        soundManager.PlayWing();
                        playerRb.velocity = Vector2.up * jumpForce;
                    }
//#endif
                }
            }

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
