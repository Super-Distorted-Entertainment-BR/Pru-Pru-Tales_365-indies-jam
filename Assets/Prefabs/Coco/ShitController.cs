using UnityEngine;
using System.Collections;

public class ShitController : MonoBehaviour {

	Animator anim;
	void Awake() {
		anim = GetComponent<Animator>();
	}

	void Start () {
//		GameObject player = GameObject.FindWithTag("Player");
//		if (player.GetComponent<PombaController>().isGround)
//		{
//			Debug.Log("ENTROU NO IF");
//			anim.SetBool("IsInTheGround", true);
////			anim.SetTrigger("StraightToGround");
//		}
	}

	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other) {
		anim.SetBool("IsInTheGround", true);
		if (other.gameObject.tag == "Enemy") {
			Destroy(gameObject, 0.5f);
		}
	}

}
