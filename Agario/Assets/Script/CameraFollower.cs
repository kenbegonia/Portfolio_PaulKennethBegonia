using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {
	public Transform target;
	private Vector3 offset;
	private Vector3 player;

	// Use this for initialization
	void Start () {
		offset = target.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		player = target.transform.position;
		player.z = -10;
		this.transform.position = Vector3.MoveTowards(transform.position, player, 7.5f * Time.fixedDeltaTime);
	}
}
