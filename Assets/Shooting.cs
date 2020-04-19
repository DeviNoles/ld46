using UnityEngine;
using System.Collections;
using System;

public class Shooting : MonoBehaviour
{
	public Transform startSpot;
	public GameObject bulletDesign;
	float bF = 20f;
	private GameObject _bullet;
	void Update()
	{


		if (Input.GetMouseButtonDown(0))
		{
			shoot();
		}
	}

	void FixedUpdate()
	{


	}

	void shoot()
	{
		_bullet = Instantiate(bulletDesign, startSpot.position, startSpot.rotation);
		Rigidbody2D body = _bullet.GetComponent<Rigidbody2D>();
		body.AddForce(startSpot.up * bF, ForceMode2D.Impulse);
	}
}


 