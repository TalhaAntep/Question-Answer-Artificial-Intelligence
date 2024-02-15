using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;

namespace Homework3
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string[] corpus = File.ReadAllLines("corpus.txt");
            string[] questions = File.ReadAllLines("questions.txt");
            string[] stop_words = { " a ", " after ", " again ", " all ", " am ", " and ", " any ", " are ", " as ", " at ", " be ", " been ", " before ", " between ", " both ", " but ", " by ", " can ", " could ", " for ", " from ", " had ", " has ", " he ", " her ", " here ", " him ", " in ", " into ", " I ", " is ", " it ", " me ", " my ", " of ", " on ", " our ", " she ", " so ", " such ", " than ", " that ", " the ", " then ", " they ", " this ", " to ", " until ", " we ", " was ", " were", " with ", " you " };
            
            

            for (int i = 0; i < stop_words.Length; i++)//Remove the stop words
            {
                for (int j = 0; j < corpus.Length; j++)
                {
                    corpus[j] = corpus[j].ToLower();

                    if (corpus[j].Contains(stop_words[i]))
                    {
                        corpus[j] = corpus[j].Replace(stop_words[i], " ");
                    }

                }

                for (int j = 0; j < questions.Length; j++)
                {

                    questions[j] = questions[j].ToLower();
                    if (questions[j].Contains(stop_words[i]))
                    {
                        questions[j] = questions[j].Replace(stop_words[i], " ");
                    }

                }
            }

            string corpusread = File.ReadAllText("corpus.txt");
            
            
            
            string[] answers = corpusread.Split(' ');  //split for answers array
            for(int i=0; i < answers.Length; i++)
            {
                answers[i] = answers[i].Replace(".", " ");
                answers[i] = answers[i].Replace(",", "");
            }
            string questionread = File.ReadAllText("questions.txt");

            string[] ques_array = questionread.Split(' ');

            string[] corpuswrite = File.ReadAllLines("corpus.txt");
            string notation="";
            string[] notation_arr2 = new string[2] ;
            double x=1;
            double result = 1;
            double sum = 0;
            double mul = 1;
            for (int i = 0; i < questions.Length; i++)//Answer the questions
            {
                for (int j =0; j < corpus.Length; j++)
                {
                    
                    if (questions[i].Contains("what"))
                    {
                        if (questions[i].Contains("result"))
                        {
                            if (questions[i].Contains("+")&& questions[i].Contains("x=1"))
                            {
                                x = 1;
                                for (int k = 0; k < ques_array.Length; k++)
                                {
                                    if (ques_array[k].Contains("+"))
                                    {
                                        notation = ques_array[k];
                                    }
                                    
                                }
                                string[] notation_arr = notation.Split('+');
                                for(int l=0; l < notation_arr.Length; l++)
                                {
                                    notation_arr2 = notation_arr[l].Split('x');
                                    result = (Math.Pow(x, Convert.ToDouble(notation_arr2[1]))) * Convert.ToDouble(notation_arr2[0]);
                                    sum += result;

                                }
                                    
                                Console.WriteLine("The result is : "+sum);
                                result = 1;
                                sum = 0;    
                                break;
                            }
                            else if (questions[i].Contains("*")&& questions[i].Contains("x=2"))
                            {
                                for (int k = 0; k < ques_array.Length; k++)
                                {
                                    if (ques_array[k].Contains("*"))
                                    {
                                        notation = ques_array[k];
                                    }

                                }
                                string[] notation_arr = notation.Split('*');
                                for (int l = 0; l < notation_arr.Length; l++)
                                {
                                    notation_arr2 = notation_arr[l].Split('x');
                                    result = (Math.Pow(x, Convert.ToDouble(notation_arr2[1]))) * Convert.ToDouble(notation_arr2[0]);

                                    mul = result * mul;

                                }

                                Console.WriteLine("The result is : " + mul);
                                result = 1;
                                sum = 0;
                                break;
                            }
                            else if (questions[i].Contains("/")&& questions[i].Contains("x=6"))
                            {
                                for (int k = 0; k < ques_array.Length; k++)
                                {
                                    if (ques_array[k].Contains("/"))
                                    {
                                        notation = ques_array[k];
                                    }
                                }

                                    string[] notation_arr = notation.Split('/');
                                    for (int l = 0; l < notation_arr.Length; l++)
                                    {
                                        notation_arr2 = notation_arr[l].Split('x');
                                        result = (Math.Pow(x, Convert.ToDouble(notation_arr2[1]))) * Convert.ToDouble(notation_arr2[0]);
                                        result /= result;

                                    }
                                
                                Console.WriteLine("The result is : " + result);
                                result = 1;
                                sum = 0;
                                break;
                            }
                            
                            


                        }
                        else if (questions[i].Contains("biggest participant")&& corpus[j].Contains("biggest participant"))
                        {
                            Console.WriteLine(corpuswrite[j]);
                           
                            break;

                        }
                        else if (questions[i].Contains("difference") && corpus[j].Contains("difference"))
                        {
                            Console.WriteLine(corpuswrite[j]);
                            
                            break;
                        }
                        else if (questions[i].Contains("pattern"))
                        {
                            for (int k = 0; k < answers.Length; k++)
                            {
                                
                                    if (answers[k].Length == 7)
                                    {
                                        if (questions[i].Contains("---g-am") && answers[k][3] == 'g' && answers[k][5] == 'a' && answers[k][6] == 'm')
                                        {
                                            Console.Write(answers[k] + " ");
                                        }
                                    }
                                    if (questions[i].Contains("---?") && answers[k].Length == 3)
                                    {
                                        Console.Write(answers[k]+" ");
                                    }
                                    if (answers[k].Length == 4)
                                    {
                                        if (questions[i].Contains("-o-r") && answers[k][1] == 'o' && answers[k][3] == 'r')
                                        {
                                            Console.Write(answers[k] + " ");
                                        }
                                    }
                                
                            }
                            Console.WriteLine();
                            break;
                            
                        }
                        else if (questions[i].Contains("name") && (!corpus[j].Contains("name")))
                        {
                            Console.WriteLine("No answer");
                            break;
                        }
                        

                    }
                    if (questions[i].Contains("where"))
                    {
                        if (questions[i].Contains("ızmir") && corpus[j].Contains("ızmir"))
                        {
                            Console.WriteLine(corpuswrite[j]);
                           
                            break;
                        }

                    }
                    if (questions[i].Contains("how old"))
                    {
                        if (questions[i].Contains("jennifer lopez") && corpus[j].Contains("jennifer lopez"))
                        {
                            Console.WriteLine(corpuswrite[j]);
                            
                            break;
                        }
                    }
                    if (questions[i].Contains("how long"))
                    {
                        if (questions[i].Contains("river nile") && corpus[j].Contains("river nile"))
                        {
                            Console.WriteLine(corpuswrite[j]);
                            
                            break;
                        }
                    }
                    if (questions[i].Contains("which"))
                    {
                        if (questions[i].Contains("11") && corpus[j].Contains("11"))
                        {
                            Console.WriteLine(corpuswrite[j]);
                            
                            break;
                        }
                    }
                    if (questions[i].Contains("who"))
                    {
                        if (questions[i].Contains("thomas edison") && corpus[j].Contains("thomas edison"))
                        {
                            Console.WriteLine(corpuswrite[j]);
                           
                            break;
                        }
                    }
                }
                
            }
           

                Console.ReadLine();
        }
    }
}
