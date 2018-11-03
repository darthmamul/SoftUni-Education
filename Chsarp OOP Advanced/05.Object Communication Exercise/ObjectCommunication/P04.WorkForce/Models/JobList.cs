using System.Collections.Generic;

public class JobList : List<Job>
{
    public void AddJob(Job job)
    {
        this.Add(job);
        job.JobCompleted += this.OnJObComplete;
    }

    public void OnJObComplete(Job job)
    {
        this.Remove(job);
    }
}

