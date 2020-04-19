using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using System;

public class Enemy : MonoBehaviour
{
	public float health = 100f;
	public float love = 0f;
	private bool friendly = false;
	public Transform body;
	private NavMeshAgent _nav;
	private float _speed = 5f;
	private Rigidbody2D myrb;
	private Vector2 _mvmt;
	void Start()
    {	
		myrb = this.GetComponent<Rigidbody2D>();
	}
	void Update()
    {
		
	}
	void FixedUpdate()
    {
		if (friendly == false)
		{
			Vector3 dir = body.position - transform.position;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			myrb.rotation = angle;
			dir.Normalize();
			_mvmt = dir;

		}
		else if (friendly == true)
		{
			if (GameObject.Find("enemy"))
			{
				Vector3 dir = GameObject.Find("enemy").transform.position - this.transform.position;
				float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
				myrb.rotation = angle;
				dir.Normalize();
				_mvmt = dir;
			}
			else
			{
				Debug.Log("WAITING FOR BULLET");
			}

		}

			movePlayer(_mvmt);
		
    }
	void movePlayer(Vector2 dir)
    {
		myrb.MovePosition((Vector2)transform.position + (dir * _speed * Time.deltaTime));
    }

	void OnCollisionEnter2D(Collision2D bullet)
	{/*
		if(bullet.gameObject.name == "bullet(Clone)")
        {
			health = health - 10f;
            if (health <= 0)
            {
				Destroy(gameObject);
			}
			
		}*/
		if (bullet.gameObject.name == "bullet(Clone)")
		{
			love = love + 10f;
			if (love >= 100)
			{
				Debug.Log("MAX LOVE");
				friendly = true;
			}

		}
	}
}


