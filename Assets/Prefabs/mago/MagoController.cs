using UnityEngine;
using System.Collections;


public class MagoController : MonoBehaviour {

	public bool wake = false;
	public GameObject fireBall;
	public GameObject attack;
	public GameObject player;
	public Vector3 playerPosition;
	public GameObject FireBallSpawner;
	public Animator _animator;

	public float fireRate = 2.0f;
	private float nextFire = 0.0f;

    public float fireForce = 2;


    void Start () {
		_animator = GetComponent<Animator>();
	}

	void Update () {
		if (!wake) {
			return;
		}

		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			playerPosition = player.transform.position;
			attack = (GameObject)Instantiate(fireBall, FireBallSpawner.transform.position, Quaternion.identity);
			attack.GetComponent<Rigidbody2D>().AddForce(new Vector2(fireForce, 0));
			attack.GetComponent<Rigidbody2D>().velocity = new Vector3(fireForce, 0, 0);

			Debug.Log("FIRING BALL!");
		}

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Coco")
		{
			wake = false;
			_animator.SetTrigger("Morreu");
		}

	}
}
