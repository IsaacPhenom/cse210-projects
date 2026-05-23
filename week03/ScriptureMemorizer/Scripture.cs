using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // The constructor takes the reference and the raw string of text
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] splitText = text.Split(' ');

        foreach (string wordString in splitText)
        {
            Word newWord = new Word(wordString);
            _words.Add(newWord);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int wordsHiddenThisRound = 0;

        // This will loop until we've hidden the required amount of words
        while (wordsHiddenThisRound < numberToHide)
        {
            if (IsCompletelyHidden())
            {
                break;
            }

            // Pick a random index from the list of words
            int randomIndex = random.Next(_words.Count);

            // We will only hide the word if it isn't already hidden!
            if (!_words[randomIndex].IsHidden())
            {
                _words[randomIndex].Hide();
                wordsHiddenThisRound++;
            }
        }
    }

    // This assembles the reference and the words into one final string
    public string GetDisplayText()
    {
        string scriptureText = "";

        // We will loop through all Word objects and ask them for their text (words or underscores)
        foreach (Word word in _words)
        {
            scriptureText += word.GetDisplayText() + " ";
        }

        return $"{_reference.GetDisplayText()} {scriptureText.Trim()}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            // If we find even one word that is not hidden, the whole thing is not hidden
            if (!word.IsHidden())
            {
                return false; 
            }
        }
        
        // If we checked all words and none of them were visible, return true
        return true; 
    }
}