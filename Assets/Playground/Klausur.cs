using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Klausur : MonoBehaviour {

    public Student verursacher;

    public string lehrstuhl, thema;

    public Aufgabenstellung a1, a2, a3, a4, a5, a6, a7;

    public Text semesterDatumMesh, fakultaetMesh, themaMesh;

    private void Start()
    {
        /*
        DateTime lastWeek = DateTime.Now.AddDays(-7.0);

        string semester = (lastWeek.Month >= 10 || lastWeek.Month <= 3) ? "Wintersemester " + (lastWeek.Year - 1) + "/" + lastWeek.Year : "Sommersemester " + lastWeek.Year;

        semesterDatumMesh.text = semester + "\nKlausur\n" + lastWeek.Day.ToString("00") + "." + lastWeek.Month.ToString("00") + "." + lastWeek.Year;

        fakultaetMesh.text = fakultaet;

        themaMesh.text = thema;
        */
    }
}
