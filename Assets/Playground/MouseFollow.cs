using UnityEngine;
using System.Collections;

public class MouseFollow : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePos = Input.mousePosition;
        Vector3 wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10f));
        transform.position = wantedPos;
	}
}
