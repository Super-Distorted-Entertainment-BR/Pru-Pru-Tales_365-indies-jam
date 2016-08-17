using UnityEngine;
using System.Collections;

[System.Serializable]
public class InputConfig
{

    public bool walkLeft()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
        return true;
        }

        return false;
    }

    public bool walkRight()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            return true;
        }

        return false;
    }

    public bool walkUp()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            return true;
        }

        return false;
    }

    public bool walkDown()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            return true;
        }

        return false;
    }
    
    public bool Left()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return true;
        }

        return false;
    }

    public bool Right()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            return true;
        }

        return false;
    }

    public bool Up()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return true;
        }

        return false;
    }

    public bool Down()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return true;
        }

        return false;
    }


    public bool action()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            return true;
        }

        return false;
    }

    public bool jump()
    {
        if (Input.GetKeyDown(KeyCode.Z))
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
