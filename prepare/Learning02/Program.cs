using System;

class Program
{
    static void Main(string[] args)
    {

        Resume resume = new Resume();
        Job job1 = new Job();
        Job job2 = new Job();
        
        resume._name = "Allison Rose";

        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";    
        job1._startYear = 2019;
        job1._endYear = 2022;

        job2._jobTitle = "Manager";
        job2._company = "Apple";    
        job2._startYear = 2022;
        job2._endYear = 2023;

        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        resume.Display();
    }
}