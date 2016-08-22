using UnityEngine;
using System.Collections;

public class MagoController : MonoBehaviour {

	public bool wake = false;
	public GameObject fireBall;
	public GameObject attack;
	public GameObject player;
	public Vector3 playerPosition;

	public float fireRate = 2.0f;
	private float nextFire = 0.0f;

	void Start () {
		
	}

	void Update () {
		if (!wake) {
			return;
		}

		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			playerPosition = player.transform.position;
			attack = (GameObject)Instantiate(fireBall, transform.position, Quaternion.identity);
			attack.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0));

			Debug.Log("FIRING BALL!");
		}

	}

}
