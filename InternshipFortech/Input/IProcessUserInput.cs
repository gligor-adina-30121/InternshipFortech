namespace InternshipFortech.UserOption
{
  /// <summary>
  /// simple interface to hold the user input and all methods that will be called to perform a certain action
  /// </summary>
  public interface IProcessUserInput
  {
    /// <summary>
    /// will hold the user provided string as input
    /// </summary>
    public string Input { get; }

    /// <summary>
    /// converts Input to upper case
    /// </summary>
    /// <returns>result as string</returns>
    public string ConvertToUpperCase();

    /// <summary>
    /// reverts the Input
    /// </summary>
    /// <returns>result as string</returns>
    public string ReverseString();

    /// <summary>
    /// counts vowels
    /// </summary>
    /// <returns>number of vowels</returns>
    public int CountVowels();

    /// <summary>
    /// counts words
    /// </summary>
    /// <returns>number of words</returns>
    public int CountWords();

    /// <summary>
    /// converts to title
    /// </summary>
    /// <returns>result as string</returns>
    public string ConvertToTitle();
  }
}
