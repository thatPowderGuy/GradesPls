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
            if(timer <= 0 || (timer <= 0.25f * stampDelayInSec && !Input.GetMouseButton(0)))
            {
                stampThatShit();
                timer = 0;
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
    {
        Vector3 mousePos = Input.mousePosition;
        Ray charles = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit2D[] greatestHits = Physics2D.GetRayIntersectionAll(charles, 20);
        foreach(RaycastHit2D hit in greatestHits)
        {
            Clickable c = hit.collider.gameObject.GetComponent<Clickable>();
            if(c != null)
            {
                mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10f));
                mousePos.z = c.transform.position.z;
                c.getClicked(mousePos);
            }
        }
    }
}
