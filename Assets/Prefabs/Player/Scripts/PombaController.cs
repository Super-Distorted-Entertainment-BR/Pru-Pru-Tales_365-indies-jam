using UnityEngine;
using System.Collections;

public class PombaController : MonoBehaviour
{
    //public enum State
    //{
    //    Idle,
    //    Walking,
    //    Jumping,
    //    Falling,
    //    Death,
    //    Dying
    //}

	// Player Attributes
	public int maxStamina = 100;
	public int currentStamina = 100;
	public int staminaRecoveryRate = 1;

	public int maxAmmo = 5;
	public int currentAmmo = 5;
	public int ammoRecoveryPerFood = 1;

    public int lives = 3;

    //public State state;

    public float gravity = 0.3f;
    public float jumpForce = 1;
    public float walkSpeed = 1;

    public bool isGround = false;
    public bool isDamaged = false;
    public float invulnerabilityTime = 1;

    private float damagedTime = 0;
	private float blinkTime = 0;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private InputConfig _inputConfig;

    private SpriteRenderer _spriteRenderer;

    private float horizontalForce = 0;
    private float verticalForce = 0;

    public AudioClip _jumpClip;

    void Start()
    {
         //state = State.Idle;
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();

        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        _inputConfig = new InputConfig();
    }


    void OnCollisionEnter2D(Collision2D other)
    {
//		Debug.Log("OnCollisionEnter2D: " + other.gameObject.tag);
        if (other.gameObject.tag != "Enemy")
        {
            isGround = true;
        }

        if (isDamaged == false && other.gameObject.tag == "Enemy")
        {
            _animator.SetTrigger("IsDamaged"); 
            
            lives--;
			if (lives == 0) {
				Debug.Log("Player died!");
				GameConfig.playerIsDead = true;
			}

            damagedTime = invulnerabilityTime;
            isDamaged = true;
            
            _rigidbody.AddForce(new Vector2(-(gameObject.transform.localScale.x * jumpForce/2), jumpForce/4));
        }

		if (other.gameObject.tag == "ComidaPao")
		{
			currentAmmo = Mathf.Min(currentAmmo + ammoRecoveryPerFood, maxAmmo);
			Destroy(other.gameObject);
			Debug.Log("Recovered ammo: " + currentAmmo);
		}
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag != "Enemy")
        {
            isGround = true;
        }
    }
    

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            isGround = false;
        }
    }


    void Update()
    {
         Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), isDamaged);
      
		if (_inputConfig.jump() && currentStamina >= 20)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce));
            //  Debug.Log("Jump");

            _animator.SetTrigger("Jump");

            GameConfig.soundManager.PlaySound(_jumpClip, gameObject.transform.position);
			currentStamina -= 20;
			Debug.Log("Jumped, stamina: " + currentStamina);
        }

		if (_inputConfig.action() && currentAmmo > 0)
        {
			currentAmmo -= 1;
			Debug.Log("Shitting, ammo:" + currentAmmo);
        }

        if (_inputConfig.walkLeft())
        {
            horizontalForce += walkSpeed;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (_inputConfig.walkRight())
        {
            horizontalForce += walkSpeed;
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (damagedTime > 0)
        {
            damagedTime = damagedTime - Time.deltaTime;

            if (damagedTime <= 0)
            {
                isDamaged = false;
            }

            blink();
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }

        _animator.SetBool("Walk", isGround && horizontalForce != 0);

        _animator.SetBool("IsGround", isGround);


		if (isGround && (currentStamina < maxStamina)) {
			currentStamina = Mathf.Min(currentStamina + staminaRecoveryRate, maxStamina);

			Debug.Log("Recovering stamina... " + currentStamina);
		}

        horizontalForce = horizontalForce * Time.deltaTime;
 
        transform.Translate(new Vector3(horizontalForce, 0, transform.position.z));
    }

    void blink()
    {
        if (blinkTime >= 0.1f)
        {
            blinkTime = 0;
            //Debug.Log("B");
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            //Debug.Log("A");
            GetComponent<SpriteRenderer>().enabled = false;
        }

        blinkTime = blinkTime + Time.deltaTime;
    }

}
