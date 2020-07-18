using System.Threading.Tasks;
using System.Collections.Generic;

namespace eWAN.Application.UseCases
{
    using Domains.Session;
    using Domains.Subject;
    using Boundaries.CreateSubject;
    using Services;

    public class CreateSubjectUseCase : ICreateSubjectUseCase
    {
        public CreateSubjectUseCase(
            IUnitOfWork unitOfWork,
            ICreateSubjectOutputPort outputPort,
            ISessionRepository sessionRepository,
            ISessionFitService sessionFitService,
            ISubjectFactory subjectFactory,
            ISubjectRepository subjectRepository
        )
        {
            this._unitOfWork = unitOfWork;
            this._outputPort = outputPort;
            this._sessionRepository = sessionRepository;
            this._sessionFitService = sessionFitService;
            this._subjectFactory = subjectFactory;
            this._subjectRepository = subjectRepository;
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICreateSubjectOutputPort _outputPort;
        private readonly ISessionRepository _sessionRepository;
        private readonly ISessionFitService _sessionFitService;
        private readonly ISubjectFactory _subjectFactory;
        private readonly ISubjectRepository _subjectRepository;

        public async Task Handle(CreateSubjectInput input)
        {
            foreach(var session in input.Sessions)
            {
                var roomSched = await this._sessionRepository.GetSessionsByRoomAndSemester(input.room, input.Semester);
                if(!await this._sessionFitService.IsSessionFitInSched(roomSched, session))
                {
                    this._outputPort.WriteError($"Session {session.StartTime}-{session.EndTime} does not fit in the schedule of Room {input.room.Name}");
                    return;
                }

                var instructorSched = await this._sessionRepository.GetSessionsByInstructorAndSemester(input.Instructor, input.Semester);
                if(!await this._sessionFitService.IsSessionFitInSched(instructorSched, session))
                {
                    this._outputPort.WriteError($"Session {session.StartTime}-{session.EndTime} does not fit in the schedule of Instructor {input.Instructor.FirstName} {input.Instructor.LastName}");
                    return;
                }
            }

            ISubject subject = this._subjectFactory.NewSubject(input.Course, (List<ISession>) input.Sessions, null);
            
            input.Semester.OpenCourses.Add(subject);

            await this._subjectRepository.Add(subject);

            this._outputPort.Standard(new CreateSubjectOutput(subject));

            await this._unitOfWork.Save();
        }
    }
}
