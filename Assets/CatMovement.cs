using UnityEngine;
using System.Collections;
using System.Threading;
using System;

public class CatMovement : MonoBehaviour
{

	public Rigidbody2D player;
	public float speed = 5f;
	Vector2 mvmt;
	public Camera cam;
	Vector2 mousePos;

	void Update(){
	

		mvmt.x = Input.GetAxisRaw("Horizontal");
		mvmt.y = Input.GetAxisRaw("Vertical");
		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
	
	}

	void FixedUpdate()
	{
	

		player.MovePosition(player.position + mvmt * speed * Time.fixedDeltaTime);

		Vector2 shootDir = mousePos - player.position;
		float shootAngle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg + 185f;
		player.rotation = shootAngle;
		}

	}


