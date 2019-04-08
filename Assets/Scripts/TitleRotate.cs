using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleRotate : MonoBehaviour {

	public Transform target;

  void Update()
  {
		// Rotate the camera every frame so it keeps looking at the target
    transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
		transform.RotateAround(transform.position, Vector3.up, 90);
  }
}
