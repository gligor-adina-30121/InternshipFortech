using InternshipFortech.UserOption;

namespace InternshipFortech
{
  public class Internship
  {
    // private and readonly so no other class can access them and nobody will change them - they do not exist outside scope

    // main menu options
    private readonly string ConvertToUpperCase = "Convert a string to uppercase";
    private readonly string ReverseString = "Reverse a string";
    private readonly string CountVowels = "Count the number of vowels in a string";
    private readonly string CountWords = "Count the number of words in a string";
    private readonly string ConvertToTitle = "Convert a string to title case";
    private readonly string Exit = "Exit";

    // second menu options
    private readonly string IntroduceAString = "Please introduce a string";
    private readonly string BackToMainMenu = "Go back to previous screen";

    // main menu
    public void MainMenu()
    {
      // display main menu with all required options + exit
      Console.WriteLine($"Please choose the desired option: " +
                        $"\n1 {ConvertToUpperCase} " +
                        $"\n2 {ReverseString} " +
                        $"\n3 {CountVowels} " +
                        $"\n4 {CountWords} " +
                        $"\n5 {ConvertToTitle} " +
                        $"\n6 {Exit} \n");
      int mainMenuOption;

      // read chosen option by the user and while it is not between 1 and 6 or if not a number then just display an error message
      while (!int.TryParse(Console.ReadLine(), out mainMenuOption) || mainMenuOption < 1 || mainMenuOption > 6)
      {
        Console.WriteLine("Invalid option, choose a number between 1 and 6: ");
      }

      // clear out screen after option was succesfully read and display second menu options
      Console.Clear();

      // this switches between options and displays previously main menu chosen option and secondary menu
      switch (mainMenuOption)
      {
        case 1:
          Console.WriteLine($"{ConvertToUpperCase}");
          SecondaryMenu(mainMenuOption);
          break;

        case 2:
          Console.WriteLine($"{ReverseString}");
          SecondaryMenu(mainMenuOption);
          break;

        case 3:
          Console.WriteLine($"{CountVowels}");
          SecondaryMenu(mainMenuOption);
          break;

        case 4:
          Console.WriteLine($"{CountWords}");
          SecondaryMenu(mainMenuOption);
          break;

        case 5:
          Console.WriteLine($"{ConvertToTitle}");
          SecondaryMenu(mainMenuOption);
          break;

        case 6:
          Console.WriteLine($"{Exit}");
          // sleep for 3 sec and then close
          Thread.Sleep(3000);
          Environment.Exit(0);
          break;
      }
    }

    // second menu
    public void SecondaryMenu(int action)
    {
      Console.WriteLine(
        $"\n1 {IntroduceAString} " +
        $"\n" +
        $"\n2 {BackToMainMenu} ");

      int secondaryMenuOption;
      while (!int.TryParse(Console.ReadLine(), out secondaryMenuOption) || secondaryMenuOption < 1 || secondaryMenuOption > 2)
      {
        Console.WriteLine("Invalid option, choose a number between 1 and 2 : ");
      }

      // if previous menu option was chosen then go to mainMenu
      if (secondaryMenuOption.Equals(2))
      {
        Console.Clear();
        MainMenu();
      }

      // read user input string from the console
      var userInputString = Console.ReadLine();

      // if the user enters nothing and hits enter then display a message and take the user back to second menu
      while (string.IsNullOrWhiteSpace(userInputString))
      {
        Console.WriteLine(
          $"\n1 {IntroduceAString} " +
          $"\n" +
          $"\n2 {BackToMainMenu} ");

        userInputString = Console.ReadLine();
      }

      // create a new worker object that will perform an action chosen from main menu 
      // this worker will be initialized with a provided user input (a string)
      IProcessUserInput worker = new ProcessUserInput(userInputString);

      // this will be the result of processing the provided input
      string result = string.Empty;

      // based on the main menu action, bellow we are calling the right function
      if (action == 1)
      {
        result = worker.ConvertToUpperCase();
      }
      else if (action == 2)
      {
        result = worker.ReverseString();
      }
      else if (action == 3)
      {
        result = worker.CountVowels().ToString();
      }
      else if (action == 4)
      {
        result = worker.CountWords().ToString();
      }
      else if (action == 5)
      {
        result = worker.ConvertToTitle();
      }

      // display an empty line
      Console.WriteLine();

      // display the result
      Console.WriteLine(result);

      // wait for a key pressed action, so that the console will not close after displaying the result
      Console.ReadLine();

      // clear screen 
      Console.Clear();

      // and go back to main menu
      MainMenu();
    }
  }
}