 class Student
{
    public int RollNo { get; set; }
    public string Name { get; set; }
    public int Math { get; set; }
    public int Science { get; set; }
    public int English { get; set; }
    public int Language { get; set; }
    public int SST { get; set; }
}
class ScoreCard
{
    int n = 0;
    Student[] students;
    public void AcceptDetails()
    {
        Console.WriteLine("Enter the number of students");
        n = Convert.ToInt16(Console.ReadLine());
        students = new Student[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Enter Details for Student {i + 1}");
            Console.WriteLine("Enter Roll No");
            int rollno = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter Student Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Marks for Maths");
            int maths = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter Marks for Science");
            int science = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter Marks for English");
            int english = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter Marks for Language");
            int lang = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter Marks for SST");
            int sst = Convert.ToInt16(Console.ReadLine());
            students[i] = new Student() { RollNo = rollno, Name = name, Math = maths, Science = science, English = english, Language = lang, SST = sst };
        }
    }
    public void ShowDetails()
    {
        int sum = 0;
        int max = 0;
        int mathsAVG = 0;
        int scienceAVG = 0;
        int englishAVG = 0;
        int sstAVG = 0;
        int langavg = 0;
        string topper_name = "";
        int topper_rollnum = 0;
        int AvgSum = 0;
        for (int i = 0; i < students.Length; i++)
        {
            Console.WriteLine($"Roll No: {students[i].RollNo} Name: {students[i].Name}");
            Console.WriteLine($"Math: {students[i].Math}, Science: {students[i].Science}, English: {students[i].English}, Language: {students[i].Language}, SST: {students[i].SST}");
            sum = students[i].Math + students[i].Science + students[i].English + students[i].Language + students[i].SST;
            Console.WriteLine($"Total Score is {sum}");
        }
        foreach (Student student in students)
        {
            if (sum > max)
            {
                max = sum;
                topper_name = student.Name;                        //not updating the name
                topper_rollnum = student.RollNo;                  //not updating the roll num
            }
        }
        Console.WriteLine($"The Top Scorer is {topper_name}, Roll No {topper_rollnum}");
        Console.WriteLine($"Top Scorer marks is {max}");
        foreach (Student student in students)
        {
            englishAVG = (student.English + englishAVG) / students.Length;
            mathsAVG = (student.Math + mathsAVG) / n;
            sstAVG = (student.SST + sstAVG) / n;
            scienceAVG = (scienceAVG + student.Science) / n;
            langavg = (student.Language + langavg) / n;
        }
        Console.WriteLine($"The Average marks in English is {englishAVG}");
        Console.WriteLine($"The Average marks in Maths is {mathsAVG}");
        Console.WriteLine($"The Average marks in Social Studies is {sstAVG}");
        Console.WriteLine($"The Average marks in Science is {scienceAVG}");
        Console.WriteLine($"The Average marks in Language is {langavg}");

        AvgSum = ((englishAVG + mathsAVG + sstAVG + scienceAVG + langavg) / 5);
        Console.WriteLine(AvgSum);
    }
    public void result()
    {
        int count = 0;
        foreach (Student student in students)
        {
            if (student.English < 35 || student.Math < 35 || student.Science < 35 || student.SST < 35 || student.Language < 35)
            {
                Console.WriteLine($"{student.Name}, Roll No: {student.RollNo} need to reappear for the Exam. ");
                count++;
            }
        }
        Console.WriteLine($"No. of Student need to appear for the exaam is {count}");
    }
    public void grades(int x)
    {
        string Grade = "A";
        int rnumber = x;
        foreach (Student student in students)
        {
            double avg = 0;
            int sum = student.Math + student.Science + student.English + student.Language + student.SST;
            avg = sum / 5;
            if (avg >= 95)
            {
                Grade = "A";
            }
            else if (avg >= 80 && avg < 90)
            {
                Grade = "B";
            }
            else if (avg >= 70 && avg < 80)
            {
                Grade = "C";
            }
            else if (avg >= 60 && avg < 70)
            {
                Grade = "D";
            }
            else if (avg >= 50 && avg < 60)
            {
                Grade = "E";
            }
            else if (avg < 50)
            {
                Grade = "F";
            }
            if (student.RollNo == rnumber)
            {
                Console.WriteLine($"The Grade is {Grade}");
            }
            Console.WriteLine();
        }
    }
    public void reportcard(int rollnum)
    {
        Console.WriteLine("ScoreCard of student:");
        foreach (Student student in students)
        {
            int sum = student.Math + student.Science + student.English + student.Language + student.SST;
            if (rollnum == student.RollNo)
            {
                Console.WriteLine($"Name: {student.Name}");
                Console.WriteLine($"Roll Number: {student.RollNo}");
                Console.WriteLine($"Math Marks: {student.Math}");
                Console.WriteLine($"Science Marks: {student.Science}");
                Console.WriteLine($"English Marks: {student.English}");
                Console.WriteLine($"Language Marks: {student.Language}");
                Console.WriteLine($"Social Studoes Marks: {student.SST}");
                Console.WriteLine($"Total Marks Obtained: {sum}");
                grades(rollnum);

            }
        }
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        ScoreCard card = new ScoreCard();
        card.AcceptDetails();
        card.ShowDetails();
        Console.WriteLine();
        card.result();
        Console.WriteLine("Enter the roll number of student whose report card you want to see");
        int rnum = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        card.reportcard(rnum);
    }
}
