using UnityEngine;
using System.Collections;
using System;

public class Student {

    public static FontDatabase fontDatabase;

    private string firstName;

    private string lastName;

    private string matrikelNummer;

    private float intelligence;

    private Font typeface;

    public static Student GenerateNewPunnyStudent()
    {
        string[] fullName = NameDatabase.GetFirstAndLastName();

        Student s = new Student {
            firstName = fullName[0],
            lastName = fullName[1],
            matrikelNummer = "0" + UnityEngine.Random.Range(3600000, 3699999),
            intelligence = UnityEngine.Random.Range(0f,1f),
            typeface = fontDatabase.GetRandom()};

        Studentenschaft.instance.AddStudent(s);

        return s;
    }

    public string FirstName()
    {
        return firstName;
    }

    public string LastName()
    {
        return lastName;
    }

    public string MatrikelNummer()
    {
        return matrikelNummer;
    }

    public float Intelligence()
    {
        return intelligence;
    }

    public Font Typeface()
    {
        return typeface;
    }
}
