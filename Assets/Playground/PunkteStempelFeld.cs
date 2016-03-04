using UnityEngine;
using System.Collections;
using System;

public class PunkteStempelFeld : Clickable {

    public int? punkte = null;

    public override bool getClicked(Vector3 clickPosition, Stempel stempel)
    {
        switch (stempel.stamp)
        {
            /*case Stempel.stamps.zero:
                punkte = 0;
                break;*/

            case Stempel.stamps.one:
                punkte = 1;
                break;

            case Stempel.stamps.two:
                punkte = 2;
                break;

            case Stempel.stamps.three:
                punkte = 3;
                break;

            case Stempel.stamps.four:
                punkte = 4;
                break;

            case Stempel.stamps.five:
                punkte = 5;
                break;

            case Stempel.stamps.six:
                punkte = 6;
                break;

            case Stempel.stamps.seven:
                punkte = 7;
                break;

            case Stempel.stamps.eight:
                punkte = 8;
                break;

            case Stempel.stamps.nine:
                punkte = 9;
                break;

        }

        return true;
    }
}
