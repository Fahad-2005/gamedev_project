using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScript : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		transform.Translate(-0.03f, 0, 0);
		if (transform.position.x < -19.4)
		{
			Vector3 v = transform.position;
			v.x = 0.2f;
			transform.position = v;
		}
	}

}
