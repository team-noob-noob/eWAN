namespace eWAN.Domains.Role
{
    public enum UserRole
    {
        /// <summary>Users who have registered but hasn't been given a role; standard role for new users</summary>
        StudentApplicant = 1 << 0,

        /// <summary>Users who are accepted but has not enrolled to any program</summary>
        StudentEnrolee = 1 << 1,

        /// <summary>Users who have access to lessons</summary>
        Student = 1 << 2,

        /// <summary>Users who have access to grading systems</summary>
        TeachingStaff = 1 << 3,

        /// <summary>Users who have access to Student Applicant list</summary>
        ApplicationStaff = 1 << 4,

        /// <summary>Users who have access to Access Control</summary>
        HrStaff = 1 << 5,

        /// <summary>Users who have access to everything</summary>
        AdminStaff = 1 << 6,
    }
}
