using UnityEngine;
using System.Collections;

public class Stempel : MonoBehaviour {

    public enum stamps
    {
        checkmark,
        zero,
        one,
        two,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine,
        nextPage,
        prevPage,
        mine,
        begone
    }

    public Animator animator;

    public Color stampColor;

    public GameObject image;
    public stamps stamp;

    private float stampDelayInSec = 0.4f;
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
            if(timer <= 0)
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
                if (c.getClicked(mousePos, this) && image != null)
                {
                    GameObject stamped = (GameObject)Instantiate(image, mousePos, image.transform.rotation);
                    stamped.GetComponent<SpriteRenderer>().color = stampColor;
                    stamped.transform.parent = hit.collider.transform;

                    stampColor = new Color(stampColor.r, stampColor.g, stampColor.b, stampColor.a * 0.9f);
                }
                break;
            }
        }
    }
}
