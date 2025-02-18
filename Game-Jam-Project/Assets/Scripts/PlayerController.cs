using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BaseState;

public class PlayerController : MonoBehaviour
{

    [Header("Player")]
    [SerializeField] public float moveSpeed;
    [SerializeField] public float jumpForce;


    private Rigidbody2D rb2d;
    private Animator animator;
    private BaseState currentState;
    private bool isGrounded;
    public int jumpCount = 1; //跳躍次數 1次

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        SetCurrentState(new Idle(this)); 
    }
     
    void Update()
    {
        currentState.Update();
        Face();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        var v = rb2d.velocity;
        v.x = 0;
        rb2d.velocity = v; 

        // 重置 isGrounded 狀態
        isGrounded = false;

        if(rb2d.velocity.y <= 0)
        {
            Debug.DrawLine(this.transform.position, this.transform.position + new Vector3(0,-1.2f,0),Color.red);
            var hits = Physics2D.RaycastAll(this.transform.position, Vector2.down, 1.2f);
            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.tag == "Ground")
                {
                    isGrounded = true;
                    jumpCount = 1;
                    break;  // 找到地面就可以跳出循環
                }
            }
        }
    }

    void FixedUpdate()
    {
        currentState.FixedUpdate(); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentState.OnTriggerEnter2D(collision);
    }
     
    
     
    public bool PressArrowKey()
    {
        return Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.1 ;
    }

    public void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(horizontalInput * moveSpeed, rb2d.velocity.y);
    }
        
    public void Stop()
    { 
        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
    }  
    public void Face()
    {
        bool flipped = GetComponentInChildren<SpriteRenderer>().flipX;
        if (Input.GetAxis("Horizontal") < 0 && !flipped)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        if (Input.GetAxis("Horizontal") > 0 && flipped)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        } 
    }

    public void Jump()
    {
        if (jumpCount > 0)
        {
            rb2d.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            jumpCount -= 1; 
        }
        
    }

    public bool PressedJumpKey()
    {
        return Input.GetButtonDown("Jump");
    }

    public void PlayAnimation(string clip)
    {
        animator.Play(clip);
    }

    public bool IsAnimationDone(string _aniName)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return (stateInfo.IsName(_aniName) && stateInfo.normalizedTime >= 1.0);
    }
     
    public void SetCurrentState(BaseState state)
    {
        currentState = state;
    }

     

}
