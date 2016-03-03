using UnityEngine;
using System.Collections;

public class AufPapierStempeln : Clickable {

	public override bool getClicked(Vector3 clickPosition, Stempel stempel)
    {
        return true;
    }
}
