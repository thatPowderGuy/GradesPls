using UnityEngine;
using System.Collections;

public class Stempel : MonoBehaviour {

    public Animator animator;

    public float stampDelayInSec;
    private float timer;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        followMouse();

        if(timer <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("TheTimeIsNow");
                timer = stampDelayInSec;
            }
        }
        else
        {
            timer -= Time.deltaTime;
            if(timer <= 0 || !Input.GetMouseButton(0))
            {
                stampThatShit();
            }
        }
	}

    void followMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10f));
        transform.position = wantedPos;
    }

    void stampThatShit()
    { }
}
