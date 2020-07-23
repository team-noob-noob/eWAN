namespace eWAN.Domains.Role
{
    public enum UserRole
    {
        /// <summary>Users who have registered but hasn't been given a role; standard role for new users</summary>
        StudentApplicant = -100,

        /// <summary>Users who are accepted but has not enrolled to any program</summary>
        StudentEnrolee = -99,

        /// <summary>Users who have access to lessons</summary>
        Student = 100,

        /// <summary>Users who have access to grading systems</summary>
        TeachingStaff = 200,

        /// <summary>Users who have access to Student Applicant list</summary>
        ApplicationStaff = 300,

        /// <summary>Users who have access to Access Control</summary>
        HrStaff = 400,

        /// <summary>Users who have access to everything</summary>
        AdminStaff = 500,
    }
}
