using UnityEngine;
using System.Collections;

public class TUMstempeln : Clickable {

    public GameObject TUMlogo;

    public override void getClicked(Vector3 clickPosition)
    {
        Instantiate(TUMlogo, clickPosition, TUMlogo.transform.rotation);
    }
}
