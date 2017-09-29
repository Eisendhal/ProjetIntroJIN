using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyBasicEngine : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Engines>().Speed = new Vector2(-1, 0);
	}
	
    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

	// Update is called once per frame
	void Update () {
        
    }
}
