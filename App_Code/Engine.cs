using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

/// <summary>
/// The Engine of the game
/// </summary>
public class Engine
{
    private string word;
    private int wrongGuess;
    static int maxWrongGuess = 5; // max of wrong guesses
    private int goodGuess;
    private char[] currentGuess;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="word">The HOLY word</param>
	public Engine(string word)
	{
        this.word = word; // The word
        int maxGuess = maxWrongGuess + word.Length; // max guesses
        this.wrongGuess = 0;
        this.goodGuess = 0;
        currentGuess = new char[maxGuess]; // array saves current guesses
	}

    public void ResetEngine()
    {
        currentGuess = null;
    }

    /// <summary>
    /// This method is checking if the letter is placed in the word
    /// </summary>
    /// <param name="word">The HOLY word</param>
    /// <param name="c">Letter</param>
    /// <returns>True if the letter is in the word</returns>
    public bool CheckGuess(char c)
    {
        currentGuess[wrongGuess + goodGuess] = c; // Add the letter to the array of guess
        bool isGuessTrue = false;

        if (this.word.IndexOf(c) != -1) // check if the letter is in the word
        {
            goodGuess++;
            isGuessTrue = true;
        }
        else
        {
            wrongGuess++;
        }

        return isGuessTrue;
    }

    public bool IsGameOver()
    {
        return this.wrongGuess == Engine.maxWrongGuess ? true : false;
    }

    public string Word
    {
        get { return this.word; }
    }

    public int WrongGuess
    {
        get { return this.wrongGuess; }
    }

    public char[] CurrentGuess
    {
        get { return this.currentGuess; }
    }
    
}