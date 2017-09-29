using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        this.GetComponent<Engines>().Speed = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKey(KeyCode.Space))
        {
            this.GetComponent<BulletGun>().Fire();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            this.GetComponent<BulletGun>().guntype += 1;
        }
	}
}
