using System;
using System.Collections.Generic;
namespace hiest

{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dictionary<string, string>> crewMembers = new List<Dictionary<string, string>>();

            Console.WriteLine("================");
            Console.WriteLine("Plan your Hiest!");
            Console.WriteLine("================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //At the beginning of the program, prompt the user to enter the difficulty level of the bank.
            Console.WriteLine("What is the difficulty level of the bank? 🏦 (1-100)");
            string bankDifficultyLevelInput = Console.ReadLine();
            int bankDifficultyLevel = int.Parse(bankDifficultyLevelInput);

            //continuous program loop
            while (true)
            {
                Dictionary<string, string> crewMember = new Dictionary<string, string>();

                Console.WriteLine("Enter your team members name:");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                //Prompt the user to enter a team member's name and save that name.
                string memberName = Console.ReadLine();

                crewMember.Add("name", memberName);

                //if crew member name is not blank
                if (memberName != "")

                //Create a way to store a single team member. 
                //A team member will have a name, a skill Level and a courage factor. 
                //The skill Level will be a positive integer and the courage factor will be a decimal between 0.0 and 2.0.
                {
                    //Prompt the user to enter a team member's skill level and save that skill level with the name.                    
                    Console.WriteLine($"Enter {crewMember["name"]}'s skill level (1-50)");
                    string memberSkillLevel = Console.ReadLine();
                    crewMember.Add("skill level", memberSkillLevel);

                    //Prompt the user to enter a team member's courage factor and save that courage factor with the name.
                    Console.WriteLine($"Enter {crewMember["name"]}'s courage factor (0-2.0)");
                    string memberCourageFactor = Console.ReadLine();
                    crewMember.Add("courage factor", memberCourageFactor);

                    //Display the team member's information.
                    Console.WriteLine($"Team member {crewMember["name"]} has a skill level of {crewMember["skill level"]} and a courage factor of {crewMember["courage factor"]}.");
                    crewMembers.Add(crewMember);

                    //Stop displaying each team member's information.
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                //After the user enters the team information, prompt them to enter the number of trial runs the program should perform.
                {
                    Console.WriteLine("How many trial runs?");

                    string userInputTrialNumber = Console.ReadLine();

                    int trialValue = int.Parse(userInputTrialNumber);

                    int successValue = 0, failureValue = 0;

                    //Run the scenario multiple times.
                    //Loop through the difficulty / skill level calculation based on the user-entered number of trial runs. Choose a new luck value each time.
                    for (int i = 0; i < trialValue; i++)
                    {
                        int teamSkillLevel = 0;
                        foreach (Dictionary<string, string> member in crewMembers)

                        {
                            string skillLevel = member["skill level"];
                            int skillLevelInt = int.Parse(skillLevel);
                            teamSkillLevel += skillLevelInt;
                        }

                        Random rand = new Random();

                        //Create a random number between -10 and 10 for the heist's luck value.
                        //Store a value for the bank's difficulty level. Set this value to 100.
                        int luckValue = rand.Next(-10, 11);
                        // int bankDifficultyLevel = 100;

                        //Sum the skill levels of the team. Save that number.
                        int outcome = bankDifficultyLevel + luckValue;

                        //Before displaying the success or failure message, display a report that shows.
                        //The team's combined skill level
                        //The bank's difficulty level
                        Console.WriteLine($"Team's skill level: {teamSkillLevel}");

                        Console.WriteLine($"Bank's difficulty level: {outcome}");

                        //Compare the number with the bank's difficulty level. If the team's skill level is greater than or equal to the bank's difficulty level, Display a success message, otherwise display a failure message.
                        if (teamSkillLevel >= outcome)
                        {
                            successValue++;
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("The hiest was a success! 💰");
                        }
                        else
                        {
                            failureValue++;
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("The hiest failed. 🚓");
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    //At the end of the program, display a report showing the number of successful runs and the number of failed runs.
                    Console.WriteLine($"Successful hiests:{successValue} Failed hiests:{failureValue}");

                    return;
                }
            }
        }
    }
}
