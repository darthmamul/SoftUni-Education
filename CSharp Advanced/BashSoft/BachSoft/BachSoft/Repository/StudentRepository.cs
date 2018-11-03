using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public static class StudentRepository
{
    public static bool isDataInitialized = false;
    private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

    public static void InitializeData(string fileName)
    {
        if (!isDataInitialized)
        {
            OutputWriter.WriteMessageOnNewLine("Reading data...");
            studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
            ReadData(fileName);
        }
        else
        {
            OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitialisedException);
        }
    }

    private static void ReadData(string fileName)
    {
        string path = SessionData.currentPath + "\\" + fileName;
        if (File.Exists(path))
        {
            var pattern = @"([A-Z][a-zA-Z#+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d+)";
            var rgx = new Regex(pattern);
            var allInputLines = File.ReadAllLines(path);

            for (int line = 0; line < allInputLines.Length; line++)
            {
                if (!string.IsNullOrEmpty(allInputLines[line]) && rgx.IsMatch(allInputLines[line]))
                {
                    var currentMatch = rgx.Match(allInputLines[line]);
                    var courseName = currentMatch.Groups[1].Value;
                    var userName = currentMatch.Groups[2].Value;
                    int studentScoreOnTask;
                    bool hasParsedScore = int.TryParse(currentMatch.Groups[3].Value, out studentScoreOnTask);

                    if (hasParsedScore && studentScoreOnTask >= 0 && studentScoreOnTask <= 100)
                    {
                        if (!studentsByCourse.ContainsKey(courseName))
                        {
                            studentsByCourse.Add(courseName, new Dictionary<string, List<int>>());
                        }

                        if (!studentsByCourse[courseName].ContainsKey(userName))
                        {
                            studentsByCourse[courseName].Add(userName, new List<int>());
                        }
                    }
                }
            }
        }

        isDataInitialized = true;
        OutputWriter.WriteMessageOnNewLine("Data read!");
    }

    private static bool IsQueryForCoursePossible(string courseName)
    {
        if (isDataInitialized)
        {
            if (studentsByCourse.ContainsKey(courseName))
            {
                return true;
            }

            OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
        }

        OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);


        return false;
    }

    public static void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
    {
        if (IsQueryForCoursePossible(courseName))
        {
            if (studentsToTake == null)
            {
                studentsToTake = studentsByCourse[courseName].Count;
            }

            RepositoryFilters.FilterAndTake(studentsByCourse[courseName], givenFilter, studentsToTake.Value);
        }
    }

    public static void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
    {
        if (IsQueryForCoursePossible(courseName))
        {
            if (studentsToTake == null)
            {
                studentsToTake = studentsByCourse[courseName].Count;
            }

            RepositorySorters.OrderAndTake(studentsByCourse[courseName], comparison, studentsToTake.Value);
        }
    }

    private static bool IsQueryForStudentPossible(string courseName, string studentUserName)
    {
        if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentUserName))
        {
            return true;
        }

        OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
        return false;
    }

    public static void GetStudentScoresFromCourse(string courseName, string username)
    {
        if (IsQueryForStudentPossible(courseName, username))
        {
            OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(username, studentsByCourse[courseName][username]));
        }
    }

    public static void GetAllStudentsFromCourse(string courseName)
    {
        if (IsQueryForCoursePossible(courseName))
        {
            OutputWriter.WriteMessageOnNewLine($"{courseName}");
            foreach (var studentMarksEntry in studentsByCourse[courseName])
            {
                OutputWriter.PrintStudent(studentMarksEntry);
            }
        }
    }
}

