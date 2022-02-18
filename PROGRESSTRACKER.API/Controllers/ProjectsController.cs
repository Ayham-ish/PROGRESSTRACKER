using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROGRESSTRACKER.API.Helpers.Mapper.Models;
using PROGRESSTRACKER.API.Helpers.Return;
using PROGRESSTRACKER.ENTITIES;
using PROGRESSTRACKER.SERVICES.DTO.Project;
using PROGRESSTRACKER.SERVICES.Repositories.Implementation;
using PROGRESSTRACKER.SERVICES.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IDailyReportRepository _dailyReportRepository;
        private readonly ITimeTrackerRepository _timeTrackerRepository;
        private readonly ITimeTrackerTagRelationRepository _relationRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IAuthRepository _userRepository;
        private readonly IWorkRepository _taskRepository;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectRepository projectRepository, IClientRepository clientRepository, 
            IDailyReportRepository dailyReportRepository, ITimeTrackerRepository timeTrackerRepository, ITimeTrackerTagRelationRepository relationRepository, 
            ITagRepository tagRepository, IAuthRepository userRepository, IWorkRepository taskRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _clientRepository = clientRepository;
            _dailyReportRepository = dailyReportRepository;
            _timeTrackerRepository = timeTrackerRepository;
            _relationRepository = relationRepository;
            _tagRepository = tagRepository;
            _userRepository = userRepository;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        [HttpGet("GetProjects")]
        public IActionResult GetProjects()
        {
            var projects = _projectRepository.GetProjects(x => true, x => x.Client, x => x.WorkList);
            foreach (Project project in projects)
            {
                var tasks = _taskRepository.GetTasks(x => x.ProjectId == project.Id);
                project.WorkList = new List<Work>();
                foreach (Work task in tasks)
                {
                    var user = _userRepository.GetUser(x => x.Id == task.UserId && !x.IsDeleted);
                    task.User = user;
                    var dailyreports = _dailyReportRepository.GetDailyReports(x => x.WorkId == task.Id);
                    task.DailyReports = new List<DailyReport>();
                    foreach (DailyReport dailyreport in dailyreports)
                    {
                        task.DailyReports.Add(dailyreport);
                    }
                    project.WorkList.Add(task);
                }

                var timetrackers = _timeTrackerRepository.GetTimeTrackers(x => x.ProjectId == project.Id && !x.IsDeleted, x => x.Tags);
                project.TimeTrackers = new List<TimeTracker>();
                foreach (TimeTracker tracker in timetrackers)
                {
                    var relations = _relationRepository.GetAll(x => !x.IsDeleted && x.TimeTrackerId == tracker.Id);
                    foreach (TimeTrackerTagRelation relation in relations)
                    {
                        if (relation.Id >= 1)
                        {
                            var tag = _tagRepository.GetTag(x => x.Id == relation.TagId && !x.IsDeleted);
                            tracker.Tags.Add(tag);
                        }
                    }
                    project.TimeTrackers.Add(tracker);
                }
                var client = _clientRepository.GetClient(x => x.Id == project.ClientId && !x.IsDeleted);
                project.Client = client;

            }
            return Ok("Success".SetResponse(200, _mapper.Map<List<ProjectResponse>>(projects)));

        }

        [HttpPost("AddProject")]
        public async Task<IActionResult> AddProject(ProjectDto dto)
        {
            var project = new Project()
            {
                ClientId = dto.ClientId,
                Name = dto.Name,
                Progress = dto.Progress
            };
            project = await _projectRepository.AddProject(project);
            return Ok("Success".SetResponse(200, _mapper.Map<ProjectResponse>(project)));
        } 
        [HttpPost("AddTaskForProject")]
        public async Task<IActionResult> AddTaskForProject(TaskDto dto)
        {
            var task = new Work()
            {
                Name = dto.Name,
                ProjectId = dto.ProjectId,
                UserId = dto.UserId
            };
            task = await _taskRepository.AddTask(task);
            return Ok("Success".SetResponse(200, _mapper.Map<WorkResponse>(task)));
        }

        [HttpGet("GetTasksForProject")]
        public IActionResult GetTasks()
        {
            var tasks = _taskRepository.GetTasks(x => true, x => x.User, x => x.Project,x => x.DailyReports);
            foreach (Work task in tasks)
            {
                var project = _projectRepository.GetProject(x => x.Id == task.ProjectId && !x.IsDeleted);
                task.Project = project;
                var user = _userRepository.GetUser(x => x.Id == task.UserId && !x.IsDeleted);
                task.User = user;
                var dailyreports = _dailyReportRepository.GetDailyReports(x => x.WorkId == task.Id);
                foreach (DailyReport dailyreport in dailyreports)
                {
                    task.DailyReports.Add(dailyreport);
                }
                
            }
            return Ok("Success".SetResponse(200, _mapper.Map<List<WorkResponse>>(tasks)));
        }

        [HttpGet("GetDailyReports")]
        public IActionResult GetDailyReports() 
        {
            var dailyreports = _dailyReportRepository.GetDailyReports();
            return Ok("Success".SetResponse(200, _mapper.Map<List<DailyReportResponse>>(dailyreports)));
        }

        [HttpPost("AddDailyReportForTask")]
        public async Task<IActionResult> AddDailyReportForTask(DailyReportDto dto)
        {
            var dailyreport = new DailyReport()
            {
                Description = dto.Description,
                WorkId = dto.WorkId
            };
            dailyreport = await _dailyReportRepository.AddDailyReport(dailyreport);
            return Ok("Success".SetResponse(200, _mapper.Map<DailyReportResponse>(dailyreport)));
        }

        [HttpGet("GetClientsForProject")]
        public IActionResult GetClients()
        {
            
            var clients = _clientRepository.GetClients();
            
            return Ok("Success".SetResponse(200, _mapper.Map<List<ClientResponse>>(clients)));
        }

        [HttpPost("AddClient")]
        public async Task<IActionResult> AddClient(ClientDto dto)
        {
            var client = new Client()
            {
                Name = dto.Name
            };
            client = await _clientRepository.AddClient(client);
            return Ok("Success".SetResponse(200, _mapper.Map<ClientResponse>(client)));
        }
    }
}
