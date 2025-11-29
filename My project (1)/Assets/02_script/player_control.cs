
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class player_control : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    public Slider HP_slider;
    public GameObject GameOverPannel;

    public float jumpforce = 1.0f; //점프세기
    public float walk = 5.0f;  //걷기 속도
    public float walklimit = 2.5f;  //걷기 속도
    public float M_walk = 80.0f;  //걷기 속도
    public float M_walklimit = 90.0f;  //걷기 속도
    public float start_HP = 100.0f;  //초기 HP

    bool walkStatus = false;

    public Transform groundCheck;  //캐릭터 발끝 위치
    public float groundRadius = 0.15f;  //원 반지름
    public LayerMask groundMask;  //ground 레이어 확인

    bool isGrounded;
    bool isjumping;

    public float moveSpeed = 0f;

    private bool ismovingright = false;
    private bool ismovingleft = false;

    void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        HP_slider.value = start_HP;
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
                rigid2D.linearVelocity = new Vector2 (0,rigid2D.linearVelocity.y);
                rigid2D.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
                isjumping = true;
            }
        }
        else
        {
            isjumping = false;
        }

        float key = 0.0f;

        if (ismovingright == true)
        {
            key = 1.0f;
        }
        else if (ismovingleft == true)
        {
            key = -1.0f;
        }
        else
        {
            key = Input.GetAxisRaw("Horizontal");    //어느쪽 방향키 눌렀는지 확인
        }

        float currentX = rigid2D.linearVelocity.x;

        float target = key * moveSpeed;

        float speedchange = 5.0f;

        float nextX = Mathf.MoveTowards(currentX, target, speedchange*Time.fixedDeltaTime);

        rigid2D.linearVelocity = new Vector2(nextX, rigid2D.linearVelocity.y);

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

        if (HP_slider.value > 0)
        {
            string NowSceneName = SceneManager.GetActiveScene().name;
            Application.LoadLevel(NowSceneName);
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
        if(isGrounded == true)
        {
            if(isjumping == false)
            {
                rigid2D.linearVelocity = new Vector2(0, rigid2D.linearVelocity.y);
                rigid2D.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
                isjumping = true;
            }
        }
    }
    public void BtnrightDown()
    {
        ismovingright = true;
    }

    public void BtnrightUp()
    {
        ismovingright = false;
    }
    public void BtnleftDown()
    {
        ismovingleft = true;
    }
    public void BtnleftUp()
    {
        ismovingleft = false;
    }

    public void HP_valueCHange(int HP)
    {
        if (HP < 0)
        {
            animator.SetTrigger("trigger");
        }
        HP_slider.value += HP;
        Debug.Log(HP_slider.value);
        if (HP_slider.value < 1)
        {
            GameOverPannel.SetActive(true);

        }
    }
}