using UnityEngine;
using System.Collections;

public class TrustBar : MonoBehaviour {

    public float maxWidth = 5.9f;
    [Range(0, 1)]
    public float current =0;

    public Color outCol, inCol;

    public GameObject outL, outMid, outR, inL, inMid, inR;

	// Use this for initialization
	void Start () {
        return;
        outL.GetComponent<SpriteRenderer>().color = outCol;
        outMid.GetComponent<SpriteRenderer>().color = outCol;
        outR.GetComponent<SpriteRenderer>().color = outCol;

        inL.GetComponent<SpriteRenderer>().color = inCol;
        inMid.GetComponent<SpriteRenderer>().color = inCol;
        inR.GetComponent<SpriteRenderer>().color = inCol;
	}
	
	// Update is called once per frame
	void Update () {
        inMid.transform.localScale = new Vector3(maxWidth * current, 1, 1);
	}
}
