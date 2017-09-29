using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacgroundScroller : MonoBehaviour {
   
    [SerializeField]
    public float scrollSpeed;
    public Vector2 initPosition;

    [SerializeField]
    private GameObject background1;
    [SerializeField]
    private GameObject background2;
    private float tileSize;

	// Use this for initialization
	void Start () {
        tileSize = background1.GetComponent<Renderer>().bounds.size.x;
        initPosition = background2.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        background1.transform.localPosition -= new Vector3(0.1f, 0, 0);
        background2.transform.localPosition -= new Vector3(0.1f, 0, 0);

        if(background1.transform.localPosition.x <= -tileSize)
        {
            background1.transform.localPosition = initPosition;
        }
        if (background2.transform.localPosition.x <= -tileSize)
        {
            background2.transform.localPosition = initPosition;
        }

    }

}
