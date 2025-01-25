using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public ScriptureReference Reference { get; private set; }
    private List<Word> Words { get; set; }

    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", Words.Select(word => word.GetDisplayText()));
        return $"{Reference.GetReferenceText()}\n\n{scriptureText}";
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        int hiddenWords = 0;

        while (hiddenWords < count)
        {
            var visibleWords = Words.Where(word => !word.IsHidden).ToList();

            if (visibleWords.Count == 0) break;

            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            hiddenWords++;
        }
    }

    public bool AreAllWordsHidden()
    {
        return Words.All(word => word.IsHidden);
    }
}
