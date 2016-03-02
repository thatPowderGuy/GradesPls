using UnityEngine;
using System.Collections;

public class NameDatabase {

    private static readonly string[] fullNames = {
    "Adam Zapfel",
    "Adi Das",
    "Aidan Bachstrasse",
    "Al Mosen",
    "Alain Zou-House",
    "Alice Imgriff",
    "Alice Murcks",
    "Alma Nach",
    "Andi Arbeit",
    "Andi Biotika",
    "Andi Wand",
    "Andi Sepp-Tisch",
    "Andreas Kreuz",
    "Anka Kette",
    "Ann Boss",
    "Ann Phitamin",
    "Ann Rehde",
    "Ann Tiaging",
    "Ann Tipasti",
    "Anna Bolika",
    "Anna Gramm",
    "John Cena",
    "Annie Time",
    "Archie Tektur",
    "Armin Gips",
    "Arno Rack",
    "August Tiner",
    "Axel Zuggen"
    };

    public static string[] GetFirstAndLastName()
    {
        return fullNames[Random.Range(0, fullNames.Length)].Split();
    }
}
