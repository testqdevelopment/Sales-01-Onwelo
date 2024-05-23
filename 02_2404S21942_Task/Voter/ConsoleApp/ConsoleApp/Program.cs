using System;
using System.Collections.Generic;

namespace VotingApp
{
    class Program
    {
        static List<Candidate> candidates = new List<Candidate>();
        static List<Voter> voters = new List<Voter>();

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("1. Add Candidate");
                Console.WriteLine("2. Add Voter");
                Console.WriteLine("3. Cast Vote");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCandidate();
                        break;
                    case "2":
                        AddVoter();
                        break;
                    case "3":
                        CastVote();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddCandidate()
        {
            Console.Write("Enter candidate name: ");
            string name = Console.ReadLine();
            candidates.Add(new Candidate { Name = name, Votes = 0 });
            Console.WriteLine("Candidate added successfully.");
        }

        static void AddVoter()
        {
            Console.Write("Enter voter name: ");
            string name = Console.ReadLine();
            voters.Add(new Voter { Name = name, HasVoted = false });
            Console.WriteLine("Voter added successfully.");
        }

        static void CastVote()
        {
            Console.WriteLine("Candidates:");
            for (int i = 0; i < candidates.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {candidates[i].Name}");
            }

            Console.Write("Select candidate number: ");
            int candidateIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Voters:");
            for (int i = 0; i < voters.Count; i++)
            {
                if (!voters[i].HasVoted)
                {
                    Console.WriteLine($"{i + 1}. {voters[i].Name}");
                }
            }

            Console.Write("Select voter number: ");
            int voterIndex = int.Parse(Console.ReadLine()) - 1;

            candidates[candidateIndex].Votes++;
            voters[voterIndex].HasVoted = true;

            Console.WriteLine("Vote cast successfully.");
        }
    }
}
