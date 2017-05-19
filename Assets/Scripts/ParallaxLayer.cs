using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour {
	public float slower;

	Vector3 prevPos;
	// Use this for initialization
	void Awake () {
		prevPos = Camera.main.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 newPos = Camera.main.transform.position;
		Vector3 diff = newPos - prevPos;
		prevPos = newPos;

		Vector3 curPos = this.transform.position;

		curPos += slower * diff;
		this.transform.position = curPos;
	}
}
