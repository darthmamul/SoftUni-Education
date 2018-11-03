﻿using BachSoft;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public static class IOManager
{
    //public static void TraverseDirectory(int depth)
    //{
    //    TraverseDirectory(SessionData.currentPath, depth);
    //}

    public static void TraverseDirectory(int depth)
    {
        OutputWriter.WriteEmptyLine();
        int initialIdentation = SessionData.currentPath.Split('\\').Length;
        Queue<string> subFolders = new Queue<string>();
        subFolders.Enqueue(SessionData.currentPath);



        while (subFolders.Count != 0)
        {
            string currentPath = subFolders.Dequeue();
            int identation = currentPath.Split('\\').Length - initialIdentation;

            OutputWriter.WriteMessageOnNewLine($"{new string('-', identation)}{currentPath}");


            try
            {
                foreach (var file in Directory.GetFiles(SessionData.currentPath))
                {
                    int indexOfLastSlash = file.LastIndexOf("\\");
                    string fileName = file.Substring(indexOfLastSlash);
                    OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName);
                }

                foreach (string directoryPath in Directory.GetDirectories(currentPath))
                {
                    subFolders.Enqueue(directoryPath);
                }
            }
            catch (UnauthorizedAccessException)
            {
                OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessExceptionMessage);
            }

            if (depth - initialIdentation > 0)
            {
                break;
            }
        }
    }

    public static void CreateDirectoryInCurrentFolder(string name)
    {
        string path = GetCurrentDirectoryPath() + "\\" + name;

        try
        {
            Directory.CreateDirectory(path);
        }
        catch (ArgumentException)
        {
            OutputWriter.DisplayException(ExceptionMessages.ForbiddenSymbolsContainedInName);
        }

    }

    private static string GetCurrentDirectoryPath()
    {
        return SessionData.currentPath;
    }

    public static void ChangeCurrentDirectoryRelative(string relativePath)
    {
        if (relativePath == "..")
        {
            try
            {
                string currentPath = SessionData.currentPath;
                int indexOfLastSlash = currentPath.LastIndexOf("\\");
                string newPath = currentPath.Substring(0, indexOfLastSlash);
                SessionData.currentPath = newPath;
            }
            catch (ArgumentOutOfRangeException)
            {
                OutputWriter.DisplayException(ExceptionMessages.UnableToGoHigherInPartitionHierarchy);
            }
        }
        else
        {
            string currentPath = SessionData.currentPath;
            currentPath += "\\" + relativePath;
            ChangeCurrentDirectoryAbsolute(currentPath);
        }
    }

    public static void ChangeCurrentDirectoryAbsolute(string absolutePath)
    {
        if (!Directory.Exists(absolutePath))
        {
            OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
        }

        SessionData.currentPath = absolutePath;
    }
}

