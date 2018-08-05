using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace QuestionGenerator
{
  internal class Program
  {

    private static void Main(string[] args)
    {
      //Input validation, error handling is ignored for now.      
      var questionCount = Convert.ToInt32(args[0]);
      //var questionCount = 5;
      Console.WriteLine("Generating {0} questions...", questionCount);
      var strands = Populate();
      var questions = GenerateQuestions(questionCount, strands);

      var result = String.Join(",", questions.Select(x => x.ID));

      Console.WriteLine(result);
      Console.ReadLine();
    }

    private static List<Question> GenerateQuestions(int questionCount, List<Strand> strands)
    {
      var questions = new List<Question>();      
      for (var i = 0; i < questionCount; i++)
      {
        var currentStrand = i % 2 == 0 ? strands[0] : strands[1]; // Refactor to improve strand selection



        var selectedQuestion = PickQuestion(currentStrand, questions);
        questions.Add(selectedQuestion);


      }

      return questions;
    }

    private static Question PickQuestion(Strand currentStrand, List<Question> currentQuestions)
    {
//Second, try to put the same number of questions from each of the strand's standards into the quiz.
      var firstStandardInCurrentStrand = currentStrand.Standards.First();
      if (!currentQuestions.Any())
      {
        return firstStandardInCurrentStrand.Questions.First();
      }

      var existingStandardIds = currentQuestions.Select(x => x.StandardId);
      var standardToPickFrom = currentStrand.Standards.FirstOrDefault(x => !existingStandardIds.Contains(x.ID)) ?? firstStandardInCurrentStrand;

      var rnd = new Random();
      var candidateQuestions = standardToPickFrom.Questions;
      return candidateQuestions[rnd.Next(0, candidateQuestions.Count())];
    }

    public static List<Strand> Populate()
    {
      //Will load the data from csv files using a library like FileHelpers eventually.

      return new List<Strand>
      {
        new Strand
        {
          ID = 1,
          Name = "Nouns",
          Standards = new List<Standard>
          {
            new Standard
            {
              ID = 1,
              Name = "Common Nouns",
              Questions = new List<Question>
              {
                new Question {ID = 1, Difficulty = 0.7, StandardId = 1},
                new Question {ID = 2, Difficulty = 0.6, StandardId = 1}
              }
            },
            new Standard
            {
              ID = 2,
              Name = "Abstract Nouns",
              Questions = new List<Question>
              {
                new Question {ID = 3, Difficulty = 0.8, StandardId = 2}
              }
            },

            new Standard
            {
              ID = 3,
              Name = "Proper Nouns",
              Questions = new List<Question>
              {
                new Question {ID = 4, Difficulty = 0.2, StandardId = 3},
                new Question {ID = 5, Difficulty = 0.5, StandardId = 3},
                new Question {ID = 6, Difficulty = 0.4, StandardId = 3}
              }
            }
          }
        },


        new Strand
        {
          ID = 2,
          Name = "Verbs",
          Standards = new List<Standard>
          {
            new Standard
            {
              ID = 4,
              Name = "Action Verbs",
              Questions = new List<Question>
              {
                new Question {ID = 7, Difficulty = 0.9, StandardId = 4},
                new Question {ID = 8, Difficulty = 0.1, StandardId = 4}
              }
            },

            new Standard
            {
              ID = 5,
              Name = "Transitive Verbs",
              Questions = new List<Question>
              {
                new Question {ID = 9, Difficulty = 0.3, StandardId = 5},
                new Question {ID = 10, Difficulty = 0.6, StandardId = 5},
                new Question {ID = 11, Difficulty = 0.4, StandardId = 5}
              }
            },

            new Standard
            {
              ID = 6,
              Name = "Reflexive Verbs",
              Questions = new List<Question>
              {
                new Question {ID = 12, Difficulty = 0.2, StandardId = 6}
              }
            }
          }
        }
      };
    }
  }


  //The classes will go into their respective files eventually.
  public class Strand
  {
    public int ID { get; set; }
    public string Name { get; set; }

    public List<Standard> Standards { get; set; }
  }

  public class Standard
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public List<Question> Questions { get; set; }
  }

  public class Question
  {
    public int ID { get; set; }
    public double Difficulty { get; set; }
    public int StandardId { get; set; }
  }
}