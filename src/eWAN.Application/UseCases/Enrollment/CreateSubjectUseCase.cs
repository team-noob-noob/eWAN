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
            _unitOfWork = unitOfWork;
            _outputPort = outputPort;
            _sessionRepository = sessionRepository;
            _sessionFitService = sessionFitService;
            _subjectFactory = subjectFactory;
            _subjectRepository = subjectRepository;
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
                var roomSched = await _sessionRepository.GetSessionsByRoomAndSemester(session.Room, input.Semester);
                if(!await _sessionFitService.IsSessionFitInSchedule(roomSched, session))
                {
                    _outputPort.WriteError($"Session {session.StartTime}-{session.EndTime} does not fit in the schedule of Room {session.Room.Name}");
                    return;
                }

                var instructorSched = await _sessionRepository.GetSessionsByInstructorAndSemester(input.Instructor, input.Semester);
                if(!await _sessionFitService.IsSessionFitInSchedule(instructorSched, session))
                {
                    _outputPort.WriteError($"Session {session.StartTime}-{session.EndTime} does not fit in the schedule of Instructor {input.Instructor.FirstName} {input.Instructor.LastName}");
                    return;
                }
            }

            ISubject subject = _subjectFactory.NewSubject(input.Course, (List<ISession>) input.Sessions);
            
            input.Semester.OpenCourses.Add(subject);

            subject.Sessions.AddRange(input.Sessions);

            await _subjectRepository.Add(subject);

            _outputPort.Standard(new CreateSubjectOutput(subject));

            await _unitOfWork.Save();
        }
    }
}
