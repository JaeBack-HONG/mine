using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    bool gameOver = GameManager.isGameOver;

    public float MoveSpeed = 10f;
    public float YmoveSpeed = 1f;
        
    Rigidbody2D rigid;
    Animator animator;    

    public GameObject rigid2D;

    [Header("booster")]
    public GameObject booster_panel;

    SpriteRenderer moveFlip;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        moveFlip = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();        
        
        PlayerTag.isdrill = false;        

    }


    
    private void Update()
    {
        
            playerMove();
        
        
    }
    public void playerMove()
    {                
        bool isMoving = false;
        bool isbooster = false;
        bool booster = false;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 move = new Vector3(horizontal * MoveSpeed, rigid.velocity.y, 0);
        rigid.velocity = move;

        isMoving = horizontal != 0;        
        
        if (horizontal > 0)
        {
            moveFlip.flipX = true;
        }
        else if (horizontal < 0)
        {
            moveFlip.flipX = false;
        }      
                
        if (Input.GetKey(KeyCode.UpArrow))
        {
            isbooster = vertical >= 0;
            booster = true;
            booster_panel.SetActive(true);
           
            rigid.AddForce(Vector2.up * YmoveSpeed, ForceMode2D.Force);
        }

        animator.SetBool("is walking", isMoving);
        animator.SetBool("is booster", isbooster);
        animator.SetBool("is drill", PlayerTag.isdrill);

        if (!booster)
        {
            booster_panel.SetActive(false);
        }
        
    }   
}
