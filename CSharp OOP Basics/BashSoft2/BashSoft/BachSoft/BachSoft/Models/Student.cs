﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Student
{
    private string userName;
    private Dictionary<string, Course> enrolledCourses;
    private Dictionary<string, double> marksByCourseName;

    public Student(string userName)
    {
        this.UserName = userName;
        this.enrolledCourses = new Dictionary<string, Course>();
        this.marksByCourseName = new Dictionary<string, double>();
    }

    public string UserName
    {
        get => this.userName;
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidStringException();
            }

            this.userName = value;
        }
    }

    public IReadOnlyDictionary<string, Course> EnrolledCourses
    {
        get
        {
            return enrolledCourses;
        }
    }

    public IReadOnlyDictionary<string, double> MarksByCourseName
    {
        get
        {
            return marksByCourseName;
        }
    }

   

    public void EnrollInCourse(Course course)
    {
        if (this.enrolledCourses.ContainsKey(course.name))
        {
            throw new DuplicateEntryInStructureException(this.userName, course.Name);
        }

        this.enrolledCourses.Add(course.name, course);
    }

    public void SetMarkOnCourse(string courseName, params int[] scores)
    {
        if (!this.enrolledCourses.ContainsKey(courseName))
        {
            throw new CourseNotFoundException();
        }

        if (scores.Length > Course.NumberOfTasksOnExam)
        {
            throw new InvalidScoresCountException();
        }

        this.marksByCourseName.Add(courseName, CalculateMark(scores));
    }

    private double CalculateMark(int[] scores)
    {
        double percentageOfSolvedExams = scores.Sum() / (double)(Course.NumberOfTasksOnExam * Course.MaxScoreOnExamTask);
        double mark = percentageOfSolvedExams * 4 + 2;
        return mark;
    }
}

