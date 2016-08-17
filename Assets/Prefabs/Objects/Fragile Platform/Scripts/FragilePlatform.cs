using UnityEngine;
using System.Collections;

public class FragilePlatform : MonoBehaviour {

    private Animator _animator;
    private bool start;
    private float time;

    public float retunTime = 8;

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _animator.SetBool("Destroy",true);
            start = true;
        }
    }

	void Update () {

        if (start)
        {
            time += Time.deltaTime;
        }

        if (time > retunTime && start)
        {
        _animator.SetBool("Destroy",false);
        start = false;
        time = 0;
        }
	}

}
