namespace GradeBook
{
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        void ShowStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
}
