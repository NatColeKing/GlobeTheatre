using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private GameObject on_t;
	private GameObject on_p;
	private GameObject on_d;

	public void TurnOnTitle(GameObject obj_t)
	{
			// Debug.Log("in game manager");
			// Debug.Log("on = " + on_t);
			// Debug.Log("obj = " + obj_t);
			if(on_t != null)
					on_t.SetActive(false);
			obj_t.SetActive(true);
			on_t = obj_t;
	}

	public void TurnOnParchment(GameObject obj_p)
	{
			// Debug.Log("in game manager");
			// Debug.Log("on = " + on_p);
			// Debug.Log("obj = " + obj_p);
			if(on_p != null)
					on_p.SetActive(false);
			obj_p.SetActive(true);
			on_p = obj_p;
	}

	public void TurnOnDescription(GameObject obj_d)
	{
			// Debug.Log("in game manager");
			// Debug.Log("on = " + on_d);
			// Debug.Log("obj = " + obj_d);
			if(on_d != null)
					on_d.SetActive(false);
			obj_d.SetActive(true);
			on_d = obj_d;
	}
}
