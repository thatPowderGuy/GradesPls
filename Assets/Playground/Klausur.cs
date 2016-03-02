using UnityEngine;
using System.Collections;
using System;

public class Klausur : MonoBehaviour {

    public Student verursacher;

    public string fakultaet, thema;

    public TextMesh semesterDatumMesh, fakultaetMesh, themaMesh;

    private void Start()
    {
        DateTime lastWeek = DateTime.Now.AddDays(-7.0);

        string semester = (lastWeek.Month >= 10 || lastWeek.Month <= 3) ? "WS " + (lastWeek.Year - 1) + "/" + lastWeek.Year : "SS " + lastWeek.Year;

        semesterDatumMesh.text = semester + "\n" + lastWeek.Day.ToString("00") + "." + lastWeek.Month.ToString("00") + "." + lastWeek.Year;

        fakultaetMesh.text = fakultaet;

        themaMesh.text = thema;
    }
}
