using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustMote : MonoBehaviour
{
	Vector2 speed;
	float timeStamp;
	float coolDownTime = 0.2f;

	public void Awake () 
	{
		timeStamp = Time.time + 0.5f;
		randomizeVelocity ();	
	}

	void Update ()
	{
		Vector2 currentPos;

		currentPos = this.transform.position;
		currentPos += (speed * Time.deltaTime);

		// Check for exceeding boundaries
		if (currentPos.x > 10f || currentPos.x < -10f)
		{
			currentPos.x = -currentPos.x;
		}
		if (currentPos.y > 7f || currentPos.y < -7f)
		{
			currentPos.y = -currentPos.y;
		}
		// Update changes
		this.transform.position = currentPos;
	}

	void OnMouseOver ()
	{
		// Left mouse click randomises velocity
		if (timeStamp <= Time.time) {
			randomizeVelocity ();
			timeStamp = Time.time + coolDownTime;
		}


	}

	void randomizeVelocity (){
		speed = new Vector2 (Random.Range(-2f,2f),Random.Range(-2f,2f));

		AudioSource audio = GetComponent<AudioSource>();
		audio.Play ();

	}
}