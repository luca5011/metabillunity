using UnityEngine;
public class player_control : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;

    public float jumpforce = 1.0f; //점프세기
    public float walk = 5.0f;  //걷기 속도
    public float walklimit = 2.5f;  //걷기 속도
    public float M_walk = 80.0f;  //걷기 속도
    public float M_walklimit = 90.0f;  //걷기 속도

    bool walkStatus = false;

    public Transform groundCheck;  //캐릭터 발끝 위치
    public float groundRadius = 0.15f;  //원 반지름
    public LayerMask groundMask;  //ground 레이어 확인

    bool isGrounded;
    bool isjumping;

    void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }
    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundRadius,groundMask);    //땅에 닿았는지 확인
        Debug.Log(isGrounded);

        if (Input.GetKey(KeyCode.Space) && isGrounded == true)    //점프
        {
            if (isjumping == false)
            {
                rigid2D.AddForce(jumpforce * transform.up);
                isjumping = true;
            }
        }
        else
        {
            isjumping = false;
        }

        float key = Input.GetAxisRaw("Horizontal");    //어느쪽 방향키 눌렀는지 확인

        float Speed = Mathf.Abs(rigid2D.linearVelocity.x);
        if (Speed<=walklimit)     //속도 제한 초과하면 이동 X
        {
            rigid2D.AddForce(transform.right * key * walk);  // 이동
        }
        Debug.Log(key);
        if(key == 0)
        {
            if(walkStatus == true)
            {
                animator.SetBool("Run", false);
                walkStatus = false;
            }
        }
        else
        {
            if(walkStatus == false)
            {
                animator.SetBool("Run", true);
                walkStatus = true;
            }
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key,1,1);   // 방향 대칭
        }




    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
        {
            return;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);

        if (Application.isPlaying)
        {
            if (isGrounded)
            {
                Gizmos.color = Color.green;
            }
            else
            {
                Gizmos.color = Color.yellow;
            }

            Gizmos.DrawSphere(groundCheck.position, 0.03f);   
        }
    }

    public void Btnjump()
    {
        if (isjumping == false)
        {
            rigid2D.AddForce(jumpforce * transform.up);
            isjumping = true;
        }
    }
    public void Btnright()
    {
        float key = 1;

        float Speed = Mathf.Abs(rigid2D.linearVelocity.x);
        if (Speed <= M_walklimit)     //속도 제한 초과하면 이동 X
        {
            rigid2D.AddForce(transform.right * key * M_walk);  // 이동
        }

        transform.localScale = new Vector3(key, 1, 1);
    }
    public void Btnleft()
    {
        float key = -1;

        float Speed = Mathf.Abs(rigid2D.linearVelocity.x);
        if (Speed <= M_walklimit)     //속도 제한 초과하면 이동 X
        {
            rigid2D.AddForce(transform.right * key * M_walk);  // 이동
        }
        
        transform.localScale = new Vector3(key, 1, 1);
    }
}