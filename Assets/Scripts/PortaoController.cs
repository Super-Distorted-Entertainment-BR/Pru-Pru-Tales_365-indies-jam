using UnityEngine;
using System.Collections;

public class PortaoController : MonoBehaviour {

	public bool GateClosedOnce = false; 
	public GameObject portao;

	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("Entered Trigger!");
		if (other.gameObject.CompareTag("Player") && !GateClosedOnce)
		{
			portao.SetActive(false);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log("Left Trigger!");
		if (other.gameObject.CompareTag("Player") && other.gameObject.transform.position.x < transform.position.x)
		{
			portao.SetActive(true);
			GateClosedOnce = true;
		}
	}
}
