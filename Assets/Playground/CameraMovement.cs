using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    //Camera Bounds
    public Transform TopRightBound;
    public Transform BotLeftBound;

    public AnimationCurve distToSpeed;
    public float maxCamSpeed;

    [Range(0,1)]
    public int moveMethod;

    Vector3 dir = new Vector3(0.15f, 0.1f, 0.025f);
    float factor = 0.2f;
	
	// Use this for initialization
	void Start () {
        dir.x *= Camera.main.pixelWidth;
        dir.y *= Camera.main.pixelWidth;
        dir.z *= Camera.main.pixelWidth;
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (moveMethod == 0)
            MouseFollowWorldSpace();
        else
            MouseFollowScreenSpace();
	}
	
	private void MouseFollowScreenSpace()
	{
        Vector3 dv = new Vector3();
        if(Input.mousePosition.x < dir.z)
        {
            //move left 1
            dv.x = -maxCamSpeed;
        }
        else if (Input.mousePosition.x < dir.x)
        {
            //move left .5
            dv.x = -maxCamSpeed * factor;
        }
        else if (Input.mousePosition.x > (Camera.main.pixelWidth - dir.z))
        {
            //move right 1
            dv.x = maxCamSpeed;
        }
        else if(Input.mousePosition.x > (Camera.main.pixelWidth - dir.x))
        {
            //move right .5
            dv.x = maxCamSpeed * factor;
        }

        if(Input.mousePosition.y < dir.z)
        {
            //move down 1
            dv.y = -maxCamSpeed;
        }
        else if(Input.mousePosition.y < dir.y)
        {
            //move down .5
            dv.y = -maxCamSpeed * factor;
        }
        else if(Input.mousePosition.y > (Camera.main.pixelHeight - dir.z))
        {
            //move up 1
            dv.y = maxCamSpeed;
        }
        else if(Input.mousePosition.y > (Camera.main.pixelHeight - dir.y))
        {
            //move up .5
            dv.y = maxCamSpeed * factor;
        }

        transform.position = clampToBounds(transform.position + dv * Time.deltaTime);
        
	}
	
	private void MouseFollowWorldSpace()
	{
        Vector3 v = Input.mousePosition;
        Vector3 wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(v.x, v.y, 10f));
        wantedPos.z = transform.position.z;
       //wantedPos = clampToBounds(wantedPos);

        v = wantedPos - transform.position;
        if (v.x > maxCamSpeed)
            wantedPos.x = transform.position.x + maxCamSpeed;
        else if (v.x < 0)
        {
            if (v.x < -maxCamSpeed)
                wantedPos.x = transform.position.x - maxCamSpeed;
            v.x = -v.x;
        }

        if (v.y > maxCamSpeed)
            wantedPos.y = transform.position.y + maxCamSpeed;
        else if (v.y < 0)
        {
            if (v.y < -maxCamSpeed)
                wantedPos.y = transform.position.y - maxCamSpeed;
            v.y = -v.y;
        }

        if (v.x < factor * maxCamSpeed)
            v.x = 0;
        else
            v.x -= factor * maxCamSpeed;

        float dx = distToSpeed.Evaluate(v.x / maxCamSpeed) * Time.deltaTime;
        float dy = distToSpeed.Evaluate(v.y / maxCamSpeed) * Time.deltaTime;

        wantedPos.x *= 0.8f;

        wantedPos.x = wantedPos.x * dx + transform.position.x * (1 - dx);
        wantedPos.y = wantedPos.y * dy + transform.position.y * (1 - dy);
        
        transform.position = clampToBounds(wantedPos);
	}

    protected Vector3 clampToBounds(Vector3 v)
    {
        if (v.x < BotLeftBound.position.x)
            v.x = BotLeftBound.position.x;
        else if (v.x > TopRightBound.position.x)
            v.x = TopRightBound.position.x;
       
        if (v.y < BotLeftBound.position.y)
            v.y = BotLeftBound.position.y;
        else if (v.y > TopRightBound.position.y)
            v.y = TopRightBound.position.y;

        return v;
    }
}
