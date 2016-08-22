using UnityEngine;
using System.Collections;

public class MagoSensorController : MonoBehaviour {

	public GameObject mago;
	public GameObject magoWaked;

	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (!magoWaked && other.gameObject.CompareTag("Player"))
		{
			mago.GetComponent<MagoController>().wake = true;
		}
	}
}
