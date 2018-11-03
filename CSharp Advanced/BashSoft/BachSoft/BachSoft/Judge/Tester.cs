using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


public static class Tester
{
    public static void CompareContent(string userOuputPath, string expextedOutputPath)
    {

        OutputWriter.WriteMessageOnNewLine("Reading files...");
        try
        {
            string mismatchPath = GetMismatchPath(expextedOutputPath);

            string[] actualOutputLines = File.ReadAllLines(userOuputPath);
            string[] expectedOutputLine = File.ReadAllLines(expextedOutputPath);


            bool hasMismatch;
            string[] mismatches = GetLinesWithPossibleMismatches(actualOutputLines, expectedOutputLine, out hasMismatch);

            PrintOutput(mismatches, hasMismatch, mismatchPath);
            OutputWriter.WriteMessageOnNewLine("Files read!");
        }
        catch (FileNotFoundException)
        {
            OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
        }
    }

    private static void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchPath)
    {
        if (hasMismatch)
        {
            foreach (var line in mismatches)
            {
                OutputWriter.WriteMessageOnNewLine(line);
            }

            try
            {
                File.WriteAllLines(mismatchPath, mismatches);
            }
            catch (DirectoryNotFoundException)
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }
            return;
        }

        OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches.");
    }

    private static string[] GetLinesWithPossibleMismatches(string[] actualOutputLines, string[] expectedOuputLine, out bool hasMismatch)
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

    private static string GetMismatchPath(string expectedOutputPath)
    {
        int indexOf = expectedOutputPath.LastIndexOf('\\');
        string directoryPath = expectedOutputPath.Substring(0, indexOf);
        string finalPath = directoryPath + @"\Mismatches.txt";
        return finalPath;
    }
}

