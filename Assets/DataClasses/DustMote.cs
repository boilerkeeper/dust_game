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
		//timeStamp = Time.time + 0.5f;
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

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "mote") {
			randomizeVelocity ();
		}
	}

	void OnMouseOver ()
	{
			randomizeVelocity ();
	}

	void randomizeVelocity (){
		if (timeStamp <= Time.time) {
			timeStamp = Time.time + coolDownTime;
			float maxVelocity = 4f;
			speed = new Vector2 (Random.Range (-maxVelocity, maxVelocity), Random.Range (-maxVelocity, maxVelocity));
			AudioSource audio = GetComponent<AudioSource> ();
			audio.pitch = speed.magnitude / 5f;
			audio.Play ();
		}

	}
}