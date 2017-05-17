using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
	public GameObject dustguyPrefab;
	GameObject[] charPool;
	int charIndex = 0;
	int maxChars = 50;

	public void Start ()
	{
		charPool = new GameObject[maxChars];
	}
		
	public void Update ()
	{
		if (Input.GetMouseButtonDown (0))
		{
			CastRayToWorld ();
		}
	}

	void CastRayToWorld ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Vector2 point = ray.origin + (ray.direction * 4.5f);
		createAtMouseClick (point);
	}

	void createAtMouseClick (Vector2 initPos)
	{
		// If object already exists at this array index > destroy
		if (charPool [charIndex] != null) {
			Destroy (charPool [charIndex]);
		}
		// Instantiate new character at mouse pos
		GameObject newChar;
		newChar = Instantiate(dustguyPrefab, initPos, Quaternion.identity);
		// Make it a child of WorldController
		newChar.transform.parent = this.transform;
		// Rename
		newChar.transform.name = "dust#" + charIndex;
		// Add to array
		charPool [charIndex] = newChar;
		// Loop array index
		if (charIndex < maxChars - 1)
		{
			charIndex++;
		}
		else 
		{
			charIndex = 0;
		}
	}
}