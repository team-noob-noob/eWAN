namespace eWAN.Domains.Course
{
    public interface ICourseRepository
    {
        void Add(ICourse course);
        void Remove(ICourse course);
    }
}
