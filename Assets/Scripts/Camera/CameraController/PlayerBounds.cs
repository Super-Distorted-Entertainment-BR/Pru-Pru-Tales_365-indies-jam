using UnityEngine;
using System.Collections;
/// <summary>
/// This class handles what happens when the player reaches the level bounds.
/// </summary>
public class PlayerBounds : MonoBehaviour 
{

	public BoxCollider2D _levelLimits;
	private BoxCollider2D _boxCollider;

    private Rigidbody2D _rigidbody2D;

    /// <summary>
    /// Initialization
    /// </summary>
    public void Start () 
	{
		_boxCollider=GetComponent<BoxCollider2D>();
        _levelLimits = GameObject.FindGameObjectWithTag("LevelLimits").GetComponent<BoxCollider2D>();

        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();

    }
	
	/// <summary>
	/// Every frame, we check if the player is colliding with a level bound
	/// </summary>
	public void Update () 
	{	
		
		// we calculate the player's boxcollider size	
		var colliderSize=new Vector2(
			_boxCollider.size.x * Mathf.Abs (transform.localScale.x),
			_boxCollider.size.y * Mathf.Abs (transform.localScale.y));

        Vector2 constrainedPosition = transform.position;

        // when the player reaches a bound, we apply the specified bound behavior
        if (transform.position.y + colliderSize.y > _levelLimits.bounds.max.y)
        {
            constrainedPosition = new Vector2(transform.position.x, _levelLimits.bounds.max.y - colliderSize.y);

           _rigidbody2D.velocity = Vector3.zero;
        }

        if (transform.position.y - colliderSize.y < _levelLimits.bounds.min.y)
        {
            constrainedPosition = new Vector2(transform.position.x, _levelLimits.bounds.min.y + colliderSize.y);

            _rigidbody2D.velocity = Vector3.zero;
        }

        if (transform.position.x + colliderSize.x > _levelLimits.bounds.max.x)
        {
            constrainedPosition = new Vector2(_levelLimits.bounds.max.x - colliderSize.x, transform.position.y);

            _rigidbody2D.velocity = Vector3.zero;
        }

        if (transform.position.x - colliderSize.x < _levelLimits.bounds.min.x)
        {
            constrainedPosition = new Vector2(_levelLimits.bounds.min.x + colliderSize.x, transform.position.y);

            _rigidbody2D.velocity = Vector3.zero;
        }

        transform.position =  new Vector3(constrainedPosition.x,constrainedPosition.y,transform.position.z);	

	}
	
}
