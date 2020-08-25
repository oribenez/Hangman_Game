using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Words
/// </summary>
public class Words
{
    private static string[] subjects = { "חיות", "שמות", "ערים" };
    private static string[] animals = { "דביבון" , "סנאי" , "אוגר", "חולדה" , "גירית" ,"בונה" , "ציפור" , "עורב" , "ינשוף" , "יונה" , "נקר" , "עיט" , "בז", "נץ" , "דוכיפת" , "טווס" , "יען" , "אווז" , "ברווז" , "ברבור" , "שחף" , "סנונית" , "נשר"};
    private static string[] names = { "אבי", "יונתן", "אורי", "עמית", "ליאור", "רועי", "אלון", "דור" };
    private static string[] city = { "עפולה", "לפיד", "ירושלים", "חולון", "נהריה", "גדרה", "אילת", "דימונה" };
	public Words()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string GetWord(string type)
    {
        Random rnd = new Random();
        if (type == "חיות")
        {
            return animals[rnd.Next(animals.Length)];
        }
        else if (type == "שמות")
        {
            return names[rnd.Next(names.Length)];
        }
        else
        {
            return city[rnd.Next(city.Length)];
        }
        
    }
    public static string[] Subjects
    {
        get
        {
            return Words.subjects;
        }
    }
}