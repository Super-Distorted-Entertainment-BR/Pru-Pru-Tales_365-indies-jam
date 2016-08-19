using UnityEngine;
using System.Collections;

public class slimeController : MonoBehaviour
{

    public Transform _target;
    public float rangeOfVision = 1;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    public float jumpForce = 1;
    public float walkSpeed = 1;

    private float horizontalForce = 0;
    private float verticalForce = 0;

    public bool isGround = false;
    public bool isDamaged = false;
    public bool isDeath = false;

    public AudioClip _jumpClip;

    void Start()
    {

        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();

        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (_target == null)
        {
            _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Enemy" && other.gameObject.tag != "Player")
        {
            isGround = true;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag != "Enemy" && other.gameObject.tag != "Player")
        {
            isGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        isGround = false;
    }
    
    void Update()
    {
        if (_target != null && isDeath == false)
        {
            
            if (Mathf.Abs(transform.position.x - _target.transform.position.x) <= rangeOfVision && Mathf.Abs(transform.position.y - _target.transform.position.y) < rangeOfVision / 2)
            {
                
                //jump
                if (Mathf.Abs(transform.position.x - _target.transform.position.x) <= rangeOfVision/2 && isGround)
                {
                    if (transform.position.x > _target.transform.position.x )
                    {
                        _rigidbody.AddForce(new Vector2(-Random.Range(jumpForce / 4, jumpForce/3), Random.Range(jumpForce / 3, jumpForce)));
                        // Debug.Log("Jump...Left");
                    }
                    else
                        if (transform.position.x < _target.transform.position.x )
                    {
                        _rigidbody.AddForce(new Vector2(Random.Range(jumpForce /4, jumpForce/3), Random.Range(jumpForce / 3, jumpForce)));
                        // Debug.Log("Jump...Rigth");
                    }

                    _animator.SetTrigger("Jump");

                    GameConfig.soundManager.PlaySound(_jumpClip, gameObject.transform.position);

                }
                else
                { // walk
                    horizontalForce += walkSpeed;
                }


            }
           

        }

        _animator.SetBool("Walk", isGround && horizontalForce != 0);

        _animator.SetBool("IsGround", isGround);

        _animator.SetBool("IsDeath", isDeath);

        

        horizontalForce = horizontalForce * Time.deltaTime;

        transform.Translate(new Vector3(horizontalForce, 0, transform.position.z));
    }
}
