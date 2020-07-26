using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
	public GameObject followTarget;
	private Vector3 targetPosition;
	public float moveSpeed;
	public bool LockX = false;
	public bool LockY = false;
	private float x;
	private float y;

    // Update is called once per frame
    void Update()
    {
					x = LockX == true ? transform.position.x : followTarget.transform.position.x;
					y = LockY == true ? transform.position.y : followTarget.transform.position.y;
					targetPosition = new Vector3(x, y, transform.position.z);
					transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

}
