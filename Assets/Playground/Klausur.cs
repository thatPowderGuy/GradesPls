using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Klausur : MonoBehaviour {

    public bool isSolution = false;

    private Student verursacher;

    public string lehrstuhl, fach;

    public Canvas[] pageCanvases;
    public AufgabenSeite[] aufgabenSeiten;
    public Text[] aufgabenMaxPunkte;
    public Text gesamtPunkte;

    private Canvas activeCanvas;

    public Text semesterDatumText, lehrstuhlText, fachText, nameText, vornameText, matrNrText, hoersaalText, reiheText, sitzText;

    private int page = 0;

    private void Start()
    {
        activeCanvas = pageCanvases[0];

        DateTime lastWeek = DateTime.Now.AddDays(-7.0);

        string semester = (lastWeek.Month >= 10 || lastWeek.Month <= 3) ? "Wintersemester " + (lastWeek.Year - 1) + "/" + lastWeek.Year : "Sommersemester " + lastWeek.Year;

        semesterDatumText.text = semester + "\nKlausur\n" + lastWeek.Day.ToString("00") + "." + lastWeek.Month.ToString("00") + "." + lastWeek.Year;

        lehrstuhlText.text = "Lehrstuhl für " + lehrstuhl;

        fachText.text = fach;

        if (!isSolution)
        {
            verursacher = Student.GenerateNewPunnyStudent();

            nameText.text = verursacher.LastName();
            nameText.font = verursacher.Typeface();

            vornameText.text = verursacher.FirstName();
            vornameText.font = verursacher.Typeface();

            matrNrText.text = verursacher.MatrikelNummer();
            matrNrText.font = verursacher.Typeface();

            string[] hoersaehle = { "MW 0001", "MI 0001", "Interim 1", "Interim 2", "MW 1701", "MW 1201", "MI HS 2", "MI HS 3" };
            hoersaalText.text = hoersaehle[UnityEngine.Random.Range(0, hoersaehle.Length)];
            hoersaalText.font = verursacher.Typeface();

            string rows = "ABCDEFGHIJKLMNOPQ";
            reiheText.text = rows[UnityEngine.Random.Range(0, rows.Length)].ToString();
            reiheText.font = verursacher.Typeface();

            sitzText.text = UnityEngine.Random.Range(1, 31).ToString();
            sitzText.font = verursacher.Typeface();
        }

        int gesPkt = 0;
        for (int i = 0; i < 7; i++)
        {
            AufgabenSeite ags = aufgabenSeiten[i];

            aufgabenMaxPunkte[i].text = ags.aufgabenStellung.punkte.ToString();
            gesPkt += ags.aufgabenStellung.punkte;

            ags.aufgabePunkte.text = "Aufgabe " + (i + 1) + " (" + ags.aufgabenStellung.punkte + " Punkte)";
            ags.aufgabenText = ags.aufgabenStellung.text;
            ags.divider.transform.position = ags.aufgabenText.TransformPoint(new Vector2(
                ags.aufgabenText.rect.center.x, ags.aufgabenText.rect.yMax - 70));

            if (isSolution)
            {
                ags.aufgabenStellung.musterloesung.SetActive(true);

                ags.loesungHeader.gameObject.SetActive(true);
                ags.loesungHeader.transform.position = ags.aufgabenText.TransformPoint(new Vector2(
                ags.aufgabenText.rect.xMin + ags.loesungHeader.rectTransform.rect.width / 2f, ags.aufgabenText.rect.yMax - 95));

                ags.aufgabenStellung.musterloesung.transform.position = ags.aufgabenText.TransformPoint(new Vector2(
                ags.aufgabenText.rect.center.x, ags.aufgabenText.rect.yMax - 135));
            }
            else
            {
                Transform loesung = ags.loesungen.transform.GetChild(UnityEngine.Random.Range(0, ags.loesungen.transform.childCount));

                foreach (Text t in loesung.GetComponentsInChildren<Text>())
                {
                    t.font = verursacher.Typeface();
                }

                loesung.gameObject.SetActive(true);
                loesung.position = ags.aufgabenText.TransformPoint(new Vector2(
                ags.aufgabenText.rect.center.x, ags.aufgabenText.rect.yMax - 135));
            }

            gesamtPunkte.text = gesPkt.ToString();
        }
    }

    void Update()
    {
#if DEVBUILD
        if (Input.GetKeyDown(KeyCode.RightArrow))
            NextPage();

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            PerviousPage();
#endif
    }

    public void NextPage()
    {
        if (page < 7)
        {
            page++;

            activeCanvas.enabled = false;
            activeCanvas = pageCanvases[page];
            activeCanvas.enabled = true;
        }
    }

    public void PerviousPage()
    {
        if (page > 0)
        {
            page--;
            activeCanvas.enabled = false;
            activeCanvas = pageCanvases[page];
            activeCanvas.enabled = true;
        }
    }
}
