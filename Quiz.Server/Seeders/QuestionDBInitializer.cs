using Quiz.Server.Data;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.Server.Seeders
{
    public class QuestionDBInitializer
    {
        public static void Seed(DataContext context)
        {
            if (context.Questions.Any())
            {
                return;
            }

            context.Questions.AddRange(
                new Question
                {
                    Content = "What is 8 Kilograms in Pounds?",
                    CategoryId = 1,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "14.5", IsCorrect = false },
                        new Answer { Content = "15.7", IsCorrect = false },
                        new Answer { Content = "17.6", IsCorrect = true },
                        new Answer { Content = "19.7", IsCorrect = false }
                    }
                },
                new Question
                {
                    Content = "James is 5\"8 tall, what is James' height in centimetres (to the nearest cm)?",
                    CategoryId = 1,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "170", IsCorrect = true },
                        new Answer { Content = "174", IsCorrect = false },
                        new Answer { Content = "161", IsCorrect = false },
                        new Answer { Content = "168", IsCorrect = false }
                    }
                },
                new Question
                {
                    Content = "Which is bigger, 54 cm or 20 inches?",
                    CategoryId = 1,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "54cm", IsCorrect = true },
                        new Answer { Content = "20 inches", IsCorrect = false },
                        new Answer { Content = "They are the same", IsCorrect = false },
                        new Answer { Content = "Impossible to tell", IsCorrect = false }
                    }
                },
                new Question
                {
                    Content = "What is 8.75 Pints in Litters?",
                    CategoryId = 1,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "4.8", IsCorrect = false },
                        new Answer { Content = "5", IsCorrect = true },
                        new Answer { Content = "6", IsCorrect = false },
                        new Answer { Content = "6.5", IsCorrect = false }
                    }
                },
                new Question
                {
                    Content = "How many accidents were there in all 3 countries in January and March combined?",
                    CategoryId = 1,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "107", IsCorrect = true },
                        new Answer { Content = "108", IsCorrect = false },
                        new Answer { Content = "109", IsCorrect = false },
                        new Answer { Content = "110", IsCorrect = false }
                    }
                },
                new Question
                {
                    Content = "Which of the follow would best replace the word 'fundamental' in line two of paragraph one?",
                    CategoryId = 2,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "Declining", IsCorrect = false },
                        new Answer { Content = "Major", IsCorrect = true },
                        new Answer { Content = "Worrying", IsCorrect = false },
                        new Answer { Content = "Trending", IsCorrect = false }
                    }
                },
                new Question
                {
                    Content = "Confidence in the internet as a method of shopping is expected to...",
                    CategoryId = 2,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "Increase", IsCorrect = true },
                        new Answer { Content = "Decline", IsCorrect = false },
                        new Answer { Content = "Stay the same", IsCorrect = false },
                        new Answer { Content = "We cannot tell", IsCorrect = false }
                    }
                },
                new Question
                {
                    Content = "If a group of 15 people want to book a holiday, how many different booking options are there?",
                    CategoryId = 2,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "2", IsCorrect = false },
                        new Answer { Content = "3", IsCorrect = true },
                        new Answer { Content = "4", IsCorrect = false },
                        new Answer { Content = "5", IsCorrect = false }
                    }
                },
                new Question
                {
                    Content = "Which of the following words could replace the word 'provides' in sentence 1?",
                    CategoryId = 2,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "Enters", IsCorrect = false },
                        new Answer { Content = "Suggests", IsCorrect = false },
                        new Answer { Content = "Implies", IsCorrect = false },
                        new Answer { Content = "Gives", IsCorrect = true }
                    }
                },
                new Question
                {
                    Content = "Which of the following statements is true?People now regard internet shopping as...",
                    CategoryId = 2,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "A way to fit more into their busy lives.", IsCorrect = true },
                        new Answer { Content = "An easier way to buy luxury goods.", IsCorrect = false },
                        new Answer { Content = "An expensive but useful way to shop.", IsCorrect = false },
                        new Answer { Content = "A way to avoid the Christmas crowds.", IsCorrect = false }
                    }
                },
                new Question
                {
                    Content = "What's the difference between the average precipitation in Tirana and Algiers?",
                    CategoryId = 3,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "64", IsCorrect = false },
                        new Answer { Content = "66", IsCorrect = false },
                        new Answer { Content = "68", IsCorrect = true },
                        new Answer { Content = "70", IsCorrect = false }
                    }
                },
                new Question
                {
                    Content = "What is the change in value of Graff inc's share of the textile industry from 2021 to 2022?",
                    CategoryId = 3,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "$45k", IsCorrect = true },
                        new Answer { Content = "$252k", IsCorrect = false },
                        new Answer { Content = "$435k", IsCorrect = false },
                        new Answer { Content = "$480k", IsCorrect = false }
                    }
                },
                new Question
                {
                    Content = "What was the combined value of Balcom plc's and Tade ltd's share of the industry in 2022?",
                    CategoryId = 3,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "$464k", IsCorrect = false },
                        new Answer { Content = "$551k", IsCorrect = false },
                        new Answer { Content = "$604k", IsCorrect = false },
                        new Answer { Content = "$760k", IsCorrect = true }
                    }
                },
                new Question
                {
                    Content = "What proportion of Val Thorens' snowfall occurred in January?",
                    CategoryId = 3,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "5%", IsCorrect = true },
                        new Answer { Content = "7%", IsCorrect = false },
                        new Answer { Content = "10%", IsCorrect = false },
                        new Answer { Content = "12%", IsCorrect = false }
                    }
                },
                new Question
                {
                    Content = "How much snow fell in Whistler and Les Arcs in January and February combined?",
                    CategoryId = 3,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "40cm", IsCorrect = false },
                        new Answer { Content = "50cm", IsCorrect = false },
                        new Answer { Content = "60cm", IsCorrect = true },
                        new Answer { Content = "70cm", IsCorrect = false }
                    }
                },
                new Question
                {
                    Content = "What is the difference between the number of flights carrying ≥ 4 tonnes of cargo in February compared to May?",
                    CategoryId = 4,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "50", IsCorrect = false },
                        new Answer { Content = "84", IsCorrect = false },
                        new Answer { Content = "108", IsCorrect = false },
                        new Answer { Content = "133", IsCorrect = true }
                    }
                },
                new Question
                {
                    Content = "Which division increased turnover by the most between 2021 and 2022?",
                    CategoryId = 4,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "Audit", IsCorrect = true },
                        new Answer { Content = "Consulting", IsCorrect = false },
                        new Answer { Content = "Strategy", IsCorrect = false },
                        new Answer { Content = "Tax", IsCorrect = false }
                    }
                },
                new Question
                {
                    Content = "What is the ratio of turnover from audit in 2021 to tax in 2022",
                    CategoryId = 4,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "0.51:1", IsCorrect = true },
                        new Answer { Content = "0.62:1", IsCorrect = false },
                        new Answer { Content = "0.72:1", IsCorrect = false },
                        new Answer { Content = "0.87:1", IsCorrect = false }
                    }
                },
                new Question
                {
                    Content = "What was the combined turnover of Consulting and Strategy in 2022?",
                    CategoryId = 4,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "£2,905,000", IsCorrect = false },
                        new Answer { Content = "£2,407,000", IsCorrect = false },
                        new Answer { Content = "£2,158,000", IsCorrect = false },
                        new Answer { Content = "£1,909,000", IsCorrect = true }
                    }
                },
                new Question
                {
                    Content = "In 2021, what proportion of all hurricanes were 2 and 4?",
                    CategoryId = 4,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "24%", IsCorrect = false },
                        new Answer { Content = "32%", IsCorrect = true },
                        new Answer { Content = "38%", IsCorrect = false },
                        new Answer { Content = "42%", IsCorrect = false }
                    }
                },
                new Question
                {
                    Content = "What was the average percentage increase in daily coal production from Day 1 to Day 4?",
                    CategoryId = 5,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "6.07%", IsCorrect = false },
                        new Answer { Content = "1.82%", IsCorrect = false },
                        new Answer { Content = "1.51%", IsCorrect = true },
                        new Answer { Content = "3.14%", IsCorrect = false }
                    }
                },
                new Question
                {
                    Content = "Diamond production is forecast to decrease by 67% between day 6 and 7. What value of diamonds was produced on day 7? ",
                    CategoryId = 5,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "$61.4M", IsCorrect = true },
                        new Answer { Content = "$62.4M", IsCorrect = false },
                        new Answer { Content = "$60.1M", IsCorrect = false },
                        new Answer { Content = "$64.1M", IsCorrect = false }
                    }
                },
                new Question
                {
                    Content = "How many Canadian dollars could you buy with 500 USD in May?",
                    CategoryId = 5,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "505", IsCorrect = false },
                        new Answer { Content = "520", IsCorrect = false },
                        new Answer { Content = "500", IsCorrect = false },
                        new Answer { Content = "495", IsCorrect = true }
                    }
                },
                new Question
                {
                    Content = "A client negotiates a 10% discount on the list price of a Kanga and gets 6 months free insurance how much do they save?",
                    CategoryId = 5,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "£5,500", IsCorrect = false },
                        new Answer { Content = "£5,400", IsCorrect = true },
                        new Answer { Content = "£4,800", IsCorrect = false },
                        new Answer { Content = "£5,100", IsCorrect = false }
                    }
                },
                new Question
                {
                    Content = "At the end of the 4 month period Hetfer is $19,800 below forecast for sales of new licences. How many licences should they have sold?",
                    CategoryId = 5,
                    Answers = new List<Answer>
                    {
                        new Answer { Content = "77", IsCorrect = true },
                        new Answer { Content = "12", IsCorrect = false },
                        new Answer { Content = "65", IsCorrect = false },
                        new Answer { Content = "50", IsCorrect = false }
                    }
                }
            );

            context.SaveChanges();
        }
    }
}
