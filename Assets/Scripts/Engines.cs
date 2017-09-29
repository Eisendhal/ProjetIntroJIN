using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engines : MonoBehaviour {


    
    private Vector2 speed;
    private Vector2 position;

    public Vector2 Speed
    {
        get
        {
            return this.speed;
        }
        set
        {
            this.speed = value;
        }
    }

    public Vector2 Position
    {
        get
        {
            return this.position;
        }
        private set
        {
            this.position = value;
        }
    }

    public void InitPosition(Vector2 initPosition)
    {
        Position = initPosition;
        transform.position = initPosition;
    }

	// Use this for initialization
	void Start () {
        Position = this.transform.position;
        if (this.gameObject.GetComponent<EnemyAvatar>())
        {
            Speed = new Vector2(-1, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {

        Position += this.GetComponent<BaseAvatar>().MaxSpeed * Time.deltaTime * Speed;
        transform.position = Position;

	}
}
