﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class StudentRepository
{
    private bool isDataInitialized = false;
    private Dictionary<string, Dictionary<string, List<int>>> studentByCourse;
    private RepositoryFilter filter;
    private RepositorySorter sorter;

    private Dictionary<string, Course> courses;
    private Dictionary<string, Student> students;

    public StudentRepository(RepositorySorter sorter, RepositoryFilter filter)
    {
        this.filter = filter;
        this.sorter = sorter;
        this.studentByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
    }

    public void LoadData(string fileName)
    {
        if (!this.isDataInitialized)
        {
            OutputWriter.WriteMessageOnNewLine("Reading data...");
            this.students = new Dictionary<string, Student>();
            this.courses = new Dictionary<string, Course>();
            ReadData(fileName);
        }
        else
        {
            throw new ArgumentException(ExceptionMessages.DataAlreadyInitialisedException);
        }
    }

    public void UnloadData()
    {
        if (!this.isDataInitialized)
        {
            throw new ArgumentException(ExceptionMessages.DataNotInitializedExceptionMessage);
        }

        this.students = null;
        this.courses = null;
        this.isDataInitialized = false;
    }

    public void ReadData(string fileName)
    {
        string path = SessionData.currentPath + "\\" + fileName;
        if (File.Exists(path))
        {
            var pattern = @"([A-Z][a-zA-Z#\++]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)";
            var rgx = new Regex(pattern);
            var allInputLines = File.ReadAllLines(path);

            for (int line = 0; line < allInputLines.Length; line++)
            {
                if (!string.IsNullOrEmpty(allInputLines[line]) && rgx.IsMatch(allInputLines[line]))
                {
                    var currentMatch = rgx.Match(allInputLines[line]);
                    var courseName = currentMatch.Groups[1].Value;
                    var userName = currentMatch.Groups[2].Value;
                    var scoresStr = currentMatch.Groups[3].Value;

                    try
                    {
                        int[] scores = scoresStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

                        if (scores.Any(x => x > 100 || x < 0))
                        {
                            OutputWriter.DisplayException(ExceptionMessages.InvalidScore);
                        }

                        if (scores.Length > Course.NumberOfTasksOnExam)
                        {
                            OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                        }

                        if (!this.students.ContainsKey(userName))
                        {
                            this.students.Add(userName, new Student(userName));
                        }

                        if (!this.courses.ContainsKey(courseName))
                        {
                            this.courses.Add(courseName, new Course(courseName));
                        }

                        Course course = this.courses[courseName];
                        Student student = this.students[userName];

                        student.EnrollInCourse(course);
                        student.SetMarkOnCourse(courseName, scores);

                        course.EnrollStudent(student);
                    }
                    catch (FormatException fex)
                    {
                        OutputWriter.DisplayException(fex.Message + $"at line : {line}");
                    }
                }
            }
        }

        isDataInitialized = true;
        OutputWriter.WriteMessageOnNewLine("Data read!");
    }

    public bool IsQueryForCoursePossible(string courseName)
    {
        if (isDataInitialized)
        {
            if (this.courses.ContainsKey(courseName))
            {
                return true;
            }

            OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
        }

        OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);


        return false;
    }

    public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
    {
        if (IsQueryForCoursePossible(courseName))
        {
            if (studentsToTake == null)
            {
                studentsToTake = this.courses[courseName].studentsByName.Count;
            }

            Dictionary<string, double> marks = this.courses[courseName].studentsByName
                .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);
            this.filter.FilterAndTake(marks, givenFilter, studentsToTake.Value);
        }
    }

    public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
    {
        if (IsQueryForCoursePossible(courseName))
        {
            if (studentsToTake == null)
            {
                studentsToTake = this.courses[courseName].studentsByName.Count;
            }

            Dictionary<string, double> marks = this.courses[courseName].studentsByName
                .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);
            this.filter.FilterAndTake(marks, comparison, studentsToTake.Value);
        }
    }

    public bool IsQueryForStudentPossible(string courseName, string studentUserName)
    {
        if (IsQueryForCoursePossible(courseName) && this.courses[courseName].studentsByName.ContainsKey(studentUserName))
        {
            return true;
        }

        OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
        return false;
    }

    public void GetStudentScoresFromCourse(string courseName, string username)
    {
        if (IsQueryForStudentPossible(courseName, username))
        {
            OutputWriter.PrintStudent(new KeyValuePair<string, double>(username, this.courses[courseName].studentsByName[username].MarksByCourseName[courseName]));
        }
    }

    public void GetAllStudentsFromCourse(string courseName)
    {
        if (IsQueryForCoursePossible(courseName))
        {
            OutputWriter.WriteMessageOnNewLine($"{courseName}");
            foreach (var studentMarksEntry in this.courses[courseName].studentsByName)
            {
                this.GetStudentScoresFromCourse(courseName, studentMarksEntry.Key);
            }
        }
    }
}