using System.Globalization;

namespace InternshipFortech.UserOption
{
  public class ProcessUserInput : IProcessUserInput
  {
    public string Input { get; }

    private readonly char[] Vowels = new[] { 'a', 'e', 'i', 'o', 'u' };

    public ProcessUserInput(string input)
    {
      Input = input;
    }

    public string ConvertToUpperCase()
    {
      return Input.ToUpper();
    }

    public string ReverseString()
    {
      var reversed = string.Empty;

      for (var i = Input.Length - 1; i >= 0; i--)
      {
        reversed += Input[i];
      }

      return reversed;
    }

    public int CountVowels()
    {
      var count = 0;
      string copy = Input.ToLower();
      for (var i = 0; i < Input.Length; i++)
      {
        if (Vowels.Contains(copy[i]))
        { count++; }
      }

      return count;
    }

    public int CountWords()
    {
      return Input.Split(' ').Length;
    }

    public string ConvertToTitle()
    {
      var textinfo = new CultureInfo("en-US", false).TextInfo;

      return textinfo.ToTitleCase(Input.ToLower());
    }
  }
}
