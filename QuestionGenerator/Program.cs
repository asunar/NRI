using System.Collections.Generic;

namespace QuestionGenerator
{
  internal class Program
  {
    private static List<Strand> strands;
    private static List<Standard> standards;
    private static List<Question> questions;

    private static void Main(string[] args)
    {
    }

    public static void Populate()
    {
      //Will load the data from csv files using a library like FileHelpers eventually.

      strands = new List<Strand>
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