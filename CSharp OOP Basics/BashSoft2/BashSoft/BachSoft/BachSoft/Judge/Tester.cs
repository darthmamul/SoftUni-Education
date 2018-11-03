﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


public class Tester
{
    public void CompareContent(string userOuputPath, string expextedOutputPath)
    {
        try
        {
            OutputWriter.WriteMessageOnNewLine("Reading files...");
            string mismatchPath = this.GetMismatchPath(expextedOutputPath);

            string[] actualOutputLines = File.ReadAllLines(userOuputPath);
            string[] expectedOutputLine = File.ReadAllLines(expextedOutputPath);

            bool hasMismatch;
            string[] mismatches = GetLinesWithPossibleMismatches(actualOutputLines, expectedOutputLine, out hasMismatch);

            PrintOutput(mismatches, hasMismatch, mismatchPath);
            OutputWriter.WriteMessageOnNewLine("Files read!");
        }
        catch (IOException ioEx)
        {
            Console.WriteLine(ioEx.Message);
        }
    }

    private void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchPath)
    {
        if (hasMismatch)
        {
            foreach (var line in mismatches)
            {
                OutputWriter.WriteMessageOnNewLine(line);
            }

            File.WriteAllLines(mismatchPath, mismatches);
            return;
        }

        OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches.");
    }

    private string[] GetLinesWithPossibleMismatches(string[] actualOutputLines, string[] expectedOuputLine, out bool hasMismatch)
    {
        hasMismatch = false;
        string output = string.Empty;

        OutputWriter.WriteMessageOnNewLine("Comparing files...");

        var minOutputLines = actualOutputLines.Length;
        if (actualOutputLines.Length != expectedOuputLine.Length)
        {
            hasMismatch = true;
            minOutputLines = Math.Min(actualOutputLines.Length, expectedOuputLine.Length);
            OutputWriter.DisplayException(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
        }

        string[] mismatches = new string[minOutputLines];

        for (int index = 0; index < minOutputLines; index++)
        {
            string actualLine = actualOutputLines[index];
            string expectedLine = expectedOuputLine[index];

            if (!actualLine.Equals(expectedLine))
            {
                output = string.Format("Mismatch at line {0} -- expected: \"{1}\", actual: \"{2}\"", index, expectedLine, actualLine);
                output += Environment.NewLine;
                hasMismatch = true;
            }
            else
            {
                output = actualLine;
                output += Environment.NewLine;
            }

            mismatches[index] = output;
        }

        return mismatches;
    }

    private string GetMismatchPath(string expectedOutputPath)
    {
        int indexOf = expectedOutputPath.LastIndexOf('\\');
        string directoryPath = expectedOutputPath.Substring(0, indexOf);
        string finalPath = directoryPath + @"\Mismatches.txt";
        return finalPath;
    }
}
