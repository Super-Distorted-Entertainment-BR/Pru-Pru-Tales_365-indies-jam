using UnityEngine;
using System.Collections;

public class ShitController : MonoBehaviour {

	Animator anim;
	void Awake() {
		anim = GetComponent<Animator>();
	}

	void Start () {
		GameObject player = GameObject.FindWithTag("Player");
		if (player.GetComponent<PombaController>().isGround)
		{
			Debug.Log("ENTROU NO IF");
			anim.SetBool("IsInTheGround", true);
//			anim.SetTrigger("StraightToGround");
		}
	}

//		if (HasLight) {
//			anim.SetTrigger ("ShortcutLit");
//			anim.SetBool ("Lit", true);
//		}



	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag != "Enemy") {
			Debug.Log("Shit fell in the floor");
			anim.SetBool("IsInTheGround", true);
		}
	}

}
