using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralBullet : Bullet {

    private float time;
    private Vector3 initPos;

	// Use this for initialization
	void Start () {
        time = 0.0f;
        initPos = this.transform.position;
	}

    protected override void UpdatePosition()
    {
        Speed = (new Vector2(time * Mathf.Cos(time), time * Mathf.Sin(time)) - new Vector2((time + Time.deltaTime) * Mathf.Cos(time + Time.deltaTime), (time + Time.deltaTime * Mathf.Sin(time + Time.deltaTime))));
        base.UpdatePosition();
        time += Time.deltaTime;
        this.transform.RotateAround(initPos, Vector3.forward, time);
    }

    // Update is called once per frame
    void Update () {
        //Speed 

        UpdatePosition();
        
	}
}
