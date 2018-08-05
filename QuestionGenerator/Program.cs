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
      //First, try to put the same number of questions from each strand into the quiz.
      for (var i = 0; i < questionCount; i++)
      {
        var currentStrand = i % 2 == 0 ? strands[0] : strands[1]; // Refactor to improve strand selection     
        var selectedQuestion = currentStrand.Standards.First().Questions.First();
        questions.Add(selectedQuestion);


      }

      return questions;
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
                new Question {ID = 1, Difficulty = 0.7},
                new Question {ID = 2, Difficulty = 0.6}
              }
            },
            new Standard
            {
              ID = 2,
              Name = "Abstract Nouns",
              Questions = new List<Question>
              {
                new Question {ID = 3, Difficulty = 0.8}
              }
            },

            new Standard
            {
              ID = 3,
              Name = "Proper Nouns",
              Questions = new List<Question>
              {
                new Question {ID = 4, Difficulty = 0.2},
                new Question {ID = 5, Difficulty = 0.5},
                new Question {ID = 6, Difficulty = 0.4}
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
                new Question {ID = 7, Difficulty = 0.9},
                new Question {ID = 8, Difficulty = 0.1}
              }
            },

            new Standard
            {
              ID = 5,
              Name = "Transitive Verbs",
              Questions = new List<Question>
              {
                new Question {ID = 9, Difficulty = 0.3},
                new Question {ID = 10, Difficulty = 0.6},
                new Question {ID = 11, Difficulty = 0.4}
              }
            },

            new Standard
            {
              ID = 6,
              Name = "Reflexive Verbs",
              Questions = new List<Question>
              {
                new Question {ID = 12, Difficulty = 0.2}
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
  }
}