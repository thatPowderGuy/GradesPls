using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TextMesh))]
public class WriteTest : MonoBehaviour {

    public bool hasFocus;

    TextMesh textMesh;

	// Use this for initialization
	void Start () {
        textMesh = GetComponent<TextMesh>();	
	}
	
	// Update is called once per frame
	void Update () {
	    if(hasFocus && Input.anyKeyDown)
        {
            //write the pressed key to the textmesh's text field.
            textMesh.text += Input.inputString;

            if((textMesh.text.Length > 1) && Input.GetKeyDown(KeyCode.Backspace))
            {
                textMesh.text = textMesh.text.Substring(0, textMesh.text.Length - 2);
            }

            if(Input.GetKeyDown(KeyCode.Return))
            {
                hasFocus = false;
            }
        }
	}
}
