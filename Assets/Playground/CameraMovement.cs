using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    //Camera Bounds
    public Transform TopRightBound;
    public Transform BotLeftBound;

    public AnimationCurve xDistToSpeed;
    public AnimationCurve yDistToSpeed;
    public float maxCamSpeedX;
    public float maxCamSpeedY;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v = Input.mousePosition;
        Vector3 wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(v.x, v.y, 10f));
        wantedPos.z = transform.position.z;
       //wantedPos = clampToBounds(wantedPos);

        v = wantedPos - transform.position;
        if (v.x > maxCamSpeedX)
            wantedPos.x = transform.position.x + maxCamSpeedX;
        else if (v.x < 0)
        {
            if (v.x < -maxCamSpeedX)
                wantedPos.x = transform.position.x - maxCamSpeedX;
            v.x = -v.x;
        }

        if (v.y > maxCamSpeedY)
            wantedPos.y = transform.position.y + maxCamSpeedY;
        else if (v.y < 0)
        {
            if (v.y < -maxCamSpeedY)
                wantedPos.y = transform.position.y - maxCamSpeedY;
            v.y = -v.y;
        }

        float dx = xDistToSpeed.Evaluate(v.x / maxCamSpeedX) * Time.deltaTime;
        float dy = yDistToSpeed.Evaluate(v.y / maxCamSpeedY) * Time.deltaTime;

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
