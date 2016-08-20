using UnityEngine;
using System.Collections;

public class esqueletoController : MonoBehaviour {


    public Transform _target;
    public float rangeOfVision = 1;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    public float walkSpeed = 1;

    private float horizontalForce = 0;
    private float verticalForce = 0;


    public bool isGround = false;
    public bool isDeath = false;

    public bool stop = false;

    void Start () {

        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();

        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (_target == null)
        {
            _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        walkSpeed = Random.Range(walkSpeed / 2, walkSpeed);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Enemy" && other.gameObject.tag != "Player")
        {
            isGround = true;
        }


        if (other.gameObject.tag == "Coco")
        {
            isDeath = true;
            _animator.SetBool("IsDeath", true);
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


    void Update () {
        
           

        if (_target != null && isDeath == false && stop==false)
        {

            if (Mathf.Abs(transform.position.x - _target.transform.position.x) <= rangeOfVision && isGround && transform.position.y - rangeOfVision / 4 <= _target.transform.position.y && transform.position.y + rangeOfVision / 4 >= _target.transform.position.y)
            {
                if (transform.position.x > _target.transform.position.x-0.2 && transform.position.x < _target.transform.position.x + 0.2)
                {
                    StartCoroutine(Atack());
                }
                else
                if (transform.position.x > _target.transform.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);

                    horizontalForce += walkSpeed;
                    // Debug.Log("Jump...Left");
                }
                else
                       if (transform.position.x < _target.transform.position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);

                    horizontalForce += walkSpeed;
                    // Debug.Log("Jump...Rigth");
                }

            }

            _animator.SetBool("Walk", isGround && horizontalForce != 0);

            _animator.SetBool("IsGround", isGround);
            
    }


    horizontalForce = horizontalForce* Time.deltaTime;

    transform.Translate(new Vector3(horizontalForce, 0, transform.position.z));
	
	}

    IEnumerator Atack()
    {
        _animator.SetTrigger("Atack");
        stop = true;
        yield return new WaitForSeconds(1);
        stop = false;
        
    }

    void disable()
    {
        this.gameObject.SetActive(false);
    }
}
