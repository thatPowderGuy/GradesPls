using UnityEngine;
using System.Collections;

public class FollowLikeAShadow : MonoBehaviour {

    public Transform followMe;

    SpriteRenderer sren;

    Vector3 defaultOffset;
    float minAlpha;

	// Use this for initialization
	void Start () {

        sren = gameObject.GetComponent<SpriteRenderer>();
        defaultOffset = transform.position - followMe.position;
        minAlpha = sren.color.a;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(followMe.position.x + defaultOffset.x, transform.position.y, transform.position.z);
        float dy = (transform.position.y - followMe.position.y) / defaultOffset.y;
        sren.color = new Color(sren.color.r, sren.color.g, sren.color.b, minAlpha * dy + (1.25f - dy));
	}
}
