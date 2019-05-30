using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleRotate2 : MonoBehaviour {

	public Transform target;

  void Update()
  {
		// Rotate the camera every frame so it keeps looking at the target
    transform.LookAt(new Vector3(transform.position.x-1, target.position.y, transform.position.z));
		// transform.RotateAround(transform.position, Vector3.forward, 90);
  }
}
