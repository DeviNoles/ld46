using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using System;
public class Bullet : MonoBehaviour
{


	void OnCollisionEnter2D(Collision2D coll)
	{

		if (coll.gameObject.name != "kitty")
		{
			{
				Destroy(gameObject);
			}

		}

	}
}


