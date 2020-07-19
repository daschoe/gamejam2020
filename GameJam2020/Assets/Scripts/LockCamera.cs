using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCamera : MonoBehaviour
{
    [SerializeField]
    public CameraControl cameraControl;
    public string axis;
    // Start is called before the first frame update

    void OnTriggerEnter2D (Collider2D col)
		{
			if (col.tag == "Player")
			{
        if (axis == "x")
				    cameraControl.LockX = true;
        else if (axis == "y")
            cameraControl.LockY = true;
			}
		}

		void OnTriggerExit2D (Collider2D col)
		{
			if (col.tag == "Player")
			{
        if (axis == "x")
            cameraControl.LockX = false;
        else if (axis == "y")
            cameraControl.LockY = false;
			}
		}
}
