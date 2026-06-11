/*
 * Assignment: Rock Paper Scissors Lizard Spock Game
 * 
 * Objective:
 * Implement a fully functional Rock Paper Scissors Lizard Spock game using Unity and C#. The player selects a choice via UI buttons, 
 * the computer randomly selects its choice, and the game determines the winner based on the game rules.
 * 
 * Requirements:
 * 1. The player can choose from five options: Rock, Paper, Scissors, Lizard, or Spock by pressing designated buttons in the scene.
 * 2. The computer randomly selects one of the five choices each turn.
 * 3. Game logic determines the winner based on the following rules:
 *    - Rock beats Scissors and Lizard
 *    - Scissors beats Paper and Lizard
 *    - Paper beats Rock and Spock
 *    - Lizard beats Paper and Spock
 *    - Spock beats Scissors and Rock
 * 4. Ties occur when both the player and computer choose the same option.
 * 5. All game results (player choice, computer choice, and outcome) should be output using Debug.Log.
 * 6. Use an enum to represent the five choices instead of strings.
 * 7. Update the OnClick() method in the editor to use enums instead of strings.
 * 
 * Instructions:
 * - Attach the script to any active GameObject in your Unity scene.
 * - Change the OnClick method on the UI buttons in the scene to use enums instead of strings.
 * - Observe the game results in the Console after each button press.
 * 
 * Hint:
 * - Start by just fixing up the strings and doing Rock Paper Scissors. 
 * - Once you have that working, add in the Lizard and Spock options and update the game logic accordingly.
 * - Lastly, change the method to use enums instead of strings.
 *
 */

using UnityEngine;

public class RockPaperScissorsGame : MonoBehaviour
{
   //enum Declaration, this is to assign a number to each Choice the player or Computer can make

   public enum Choice
    {
        Rock,           // value = 0
        Paper,          // value = 1
        Scissors,       // value = 2
        Lizard,         // value = 3
        Spock           // value = 4
    }
   
   
   void Start() //I added back in Start and Update because one, I was more comfortable writing it with these already in there, and two, I added a Game start message
    {
        //Start Message to Player via debug console

        Debug.Log("The Game as started!");
        Debug.Log("Pick your move! Click on Rock, Paper, Scissors, Lizard, or Spock to Play the Game!");
    }

    void Update()
    {
        
    }
    //these public void ChooseName are for UI Button assignment
    public void ChooseRock()
    {
        PlayGame(Choice.Rock);
    }

    public void ChoosePaper()
    {
        PlayGame(Choice.Paper);
    }

    public void ChooseScissors()
    {
        PlayGame(Choice.Scissors);
    }

    public void ChooseLizard()
    {
        PlayGame(Choice.Lizard);
    }

    public void ChooseSpock()
    {
        PlayGame(Choice.Spock);
    }


    //defines the player choice and runs the game mechanic through debug.log and assigns the appropriate win/loss/tie message based off the following bool
    void PlayGame(Choice playerChoice)
    {
        Debug.Log("You Chose: " + playerChoice + "!");

        Choice computerChoice = (Choice)Random.Range(0,5);

        Debug.Log("Computer Chose: " + computerChoice);

        if (playerChoice == computerChoice)
        {
            Debug.Log("It's a tie! Both chose " + playerChoice + "!");
        }
        
        else if(PlayerWins(playerChoice, computerChoice))
        {
            Debug.Log("You win! " + playerChoice + " beats " + computerChoice);
        }

        else
        {
            Debug.Log("You Lose! " + playerChoice + " does NOT beat " + computerChoice);
        }
    }

    //this bool is true for all player win states and if none of the values are met, changes the bool to false
    bool PlayerWins(Choice playerChoice, Choice computerChoice)
    {
        if (playerChoice == Choice.Rock)
        {
            return computerChoice == Choice.Scissors || computerChoice == Choice.Lizard;
        }

        else if (playerChoice == Choice.Paper)
        {
            return computerChoice == Choice.Rock || computerChoice == Choice.Spock;
        }
        
        else if (playerChoice == Choice.Scissors)
        {
            return computerChoice == Choice.Paper || computerChoice == Choice.Lizard;
        }
        
        else if (playerChoice == Choice.Lizard)
        {
            return computerChoice == Choice.Paper || computerChoice == Choice.Spock;
        }
        
        else if (playerChoice == Choice.Spock)
        {
            return computerChoice == Choice.Scissors || computerChoice == Choice.Rock;
        }

        else
        {
            return false;
        }




        
    }


}
