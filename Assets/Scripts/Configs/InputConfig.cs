using UnityEngine;
using System.Collections;

[System.Serializable]
public class InputConfig
{

    public bool walkLeft()
    {
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
        	return true;
        }

        return false;
    }

    public bool walkRight()
    {
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            return true;
        }

        return false;
    }

    public bool walkUp()
    {
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            return true;
        }

        return false;
    }

    public bool walkDown()
    {
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            return true;
        }

        return false;
    }
    
    public bool Left()
    {
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            return true;
        }

        return false;
    }

    public bool Right()
    {
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            return true;
        }

        return false;
    }

    public bool Up()
    {
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            return true;
        }

        return false;
    }

    public bool Down()
    {
		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            return true;
        }

        return false;
    }


    public bool action()
    {
		if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }

        return false;
    }

    public bool jump()
    {
		if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            return true;
        }

        return false;
    }
    

    public bool pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            return true;
        }

        return false;
    }

}
