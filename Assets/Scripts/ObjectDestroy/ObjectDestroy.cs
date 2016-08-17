using UnityEngine;
using System.Collections;

public class ObjectDestroy : MonoBehaviour
{
    public float destroyTime;
    public Color allertColor = Color.gray + new Color(0f, 0f, 0f, 0.9f);
    private float time;
    private bool c = false;

    void Start()
    {
        time = 0;
    }

    void OnTriggerEnter2D(Collider2D Obj)
    {
        c = true;
    }

    void OnTriggerStay2D(Collider2D Obj)
    {
        c = true;
    }


    void Update()
    {

        if (c)
            time = time + 1 * Time.deltaTime;

        if (time > 0 && time < destroyTime)
        {
            GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
        }

        if (time > 0.01f)
        {
            GetComponent<Renderer>().material.color = allertColor; 
        }

        if (time > destroyTime)
        {
            Destroy(this.gameObject);
        }

    }
}