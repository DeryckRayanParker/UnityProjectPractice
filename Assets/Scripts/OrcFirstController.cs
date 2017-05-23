using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcFirstController : MonoBehaviour {
	private Vector3 startPos;
	public float radius = 4f;
	public float speed = 1f;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vec = startPos;
		vec.x += radius * Mathf.Sin (Time.time * speed);
		transform.position = vec;
	}
}
