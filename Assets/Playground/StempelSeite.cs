using UnityEngine;
using System.Collections;
using System;

public class StempelSeite : Clickable {

    public Klausur klausur;

    public override bool getClicked(Vector3 clickPosition, Stempel stempel)
    {
        switch (stempel.stamp)
        {
            case Stempel.stamps.prevPage:
                klausur.PerviousPage();
                break;

            case Stempel.stamps.nextPage:
                klausur.NextPage();
                break;

            case Stempel.stamps.begone:
                klausur.Evaluate();
                break;
        }

        return true;
    }
}
