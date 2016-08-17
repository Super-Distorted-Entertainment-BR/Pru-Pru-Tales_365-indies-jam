using UnityEngine;
using System.Collections;

public class Area2D : MonoBehaviour {

    public enum Type { yellow = 0, blue, red, green, grey };
    public Type type;

    void Start()
    {

    }

    void OnDrawGizmos()
    {

        switch (type)
        {
            case Type.yellow:
                Gizmos.color = Color.yellow;
                break;
            case Type.blue:
                Gizmos.color = Color.blue;
                break;
            case Type.red:
                Gizmos.color = Color.red;
                break;
            case Type.green:
                Gizmos.color = Color.green;
                break;
            case Type.grey:
                Gizmos.color = Color.grey;
                break;
        }

        Gizmos.DrawWireCube(gameObject.transform.position + new Vector3(gameObject.GetComponent<BoxCollider2D>().offset.x, gameObject.GetComponent<BoxCollider2D>().offset.y, 0), new Vector3(gameObject.transform.localScale.x * gameObject.GetComponent<BoxCollider2D>().size.x,
     gameObject.transform.localScale.y * gameObject.GetComponent<BoxCollider2D>().size.y, gameObject.transform.localScale.z));

    }


}
