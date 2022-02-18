using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROGRESSTRACKER.API.Helpers.Mapper.Models;
using PROGRESSTRACKER.API.Helpers.Return;
using PROGRESSTRACKER.ENTITIES;
using PROGRESSTRACKER.SERVICES.DTO.TimeTracker;
using PROGRESSTRACKER.SERVICES.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTrackerController : ControllerBase
    {
        private readonly ITimeTrackerRepository _timeTrackerRepository;
        private readonly ITimeTrackerTagRelationRepository _relationRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public TimeTrackerController(ITimeTrackerRepository timeTrackerRepository, ITimeTrackerTagRelationRepository relationRepository,
            ITagRepository tagRepository, IProjectRepository projectRepository, IMapper mapper)
        {
            _timeTrackerRepository = timeTrackerRepository;
            _relationRepository = relationRepository;
            _tagRepository = tagRepository;
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        [HttpPost("AddTimeTracker")]
        public async Task<IActionResult> AddDepartment(TimeTrackerDto dto)
        {
            if (dto.IsActive == true)
            {

                var timetracker = new TimeTracker()
                {
                    Description = dto.Description,
                    StartPoint = DateTime.Now,
                    ProjectId = dto.ProjectId,
                    IsActive = true

                };
                await _timeTrackerRepository.AddTimeTracker(timetracker);

                return Ok("Success".SetResponse(200, _mapper.Map<TimeTrackerResponse>(timetracker)));
            }
            if (dto.IsActive == false)
            {
                var timetracker = new TimeTracker()
                {
                    Description = dto.Description,
                    ProjectId = dto.ProjectId,
                    IsActive = false

                };
                await _timeTrackerRepository.AddTimeTracker(timetracker);

                return Ok("Success".SetResponse(200, _mapper.Map<TimeTrackerResponse>(timetracker)));
            }
            else
            {
                return Ok("Exception".SetResponse(401, new { }));
            }


        }

        [HttpPut("UpdateTimeTracker")]
        public async Task<IActionResult> ActivityStatus([FromForm] int id, bool status)
        {
            var timetracker = _timeTrackerRepository.GetTimeTracker(x => x.Id == id);
            if (status == false && timetracker.IsActive != false)
            {
                timetracker.IsActive = status;
                timetracker.EndPoint = DateTime.Now;
                var timestamp = timetracker.EndPoint.Subtract(timetracker.StartPoint);
                timetracker.Timestamp = DateTime.Today.Add(timestamp);
                await _timeTrackerRepository.UpdateTimeTracker(timetracker);
                return Ok("Success".SetResponse(200, _mapper.Map<TimeTrackerResponse>(timetracker)));
            }
            if (status == true && timetracker.IsActive != true)
            {
                timetracker.IsActive = status;
                timetracker.StartPoint = DateTime.Now;
                //var timestamp = Convert.ToDateTime(timetracker.Timestamp);
                await _timeTrackerRepository.UpdateTimeTracker(timetracker);
                return Ok("Success".SetResponse(200, _mapper.Map<TimeTrackerResponse>(timetracker)));
            }
            else
            {
                return Ok("Exception".SetResponse(401, new { }));
            }
        }

        [HttpGet("GetTimeTrackers")]
        public IActionResult GetTimeTrackers()
        {
            var timetrackers = _timeTrackerRepository.GetTimeTrackers(x => !x.IsDeleted, x => x.Tags,  x => x.Project);
           
            
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
                
                var project = _projectRepository.GetProject(x => x.Id == tracker.ProjectId && !x.IsDeleted);
                tracker.Project = project;
                

            }
            return Ok("Success".SetResponse(200, _mapper.Map<List<TimeTrackerResponse>>(timetrackers)));

        }
        [HttpPost("AddTimeTrackerTagRelation")]
        public async Task<IActionResult> AddTimeTrackerTagRelation(AddRelationDto dto)
        {
            
            var relation = new TimeTrackerTagRelation() 
            { 
                TimeTrackerId = dto.TimeTrackerId,
                TagId = dto.TagId
            };

            var validation = _relationRepository.Get(x => x.TimeTrackerId == dto.TimeTrackerId && x.TagId == dto.TagId);

            if (validation == null)
            {
                relation = await _relationRepository.Add(relation);
                return Ok("Success".SetResponse(200, _mapper.Map<TimeTrackerResponse>(relation)));
            }
            else
            {
                return Ok("Duplication Error".SetResponse(400, new { }));
            }
        }

        [HttpGet("GetTimeTrackerTagRelation")]
        public IActionResult GetTimeTrackerTagRelation()
        {
            var relations = _relationRepository.GetAll(x => true, x => x.TimeTracker,x => x.Tag);
            foreach (TimeTrackerTagRelation relation in relations)
            {
                var timetracker = _timeTrackerRepository.GetTimeTracker(x => x.Id == relation.TimeTrackerId);
                relation.TimeTracker = timetracker;
                var tag = _tagRepository.GetTag(x => x.Id == relation.TagId && !x.IsDeleted);
                relation.Tag = tag;
                
            }
            return Ok("Success".SetResponse(200, _mapper.Map<List<TimeTrackerTagRelationResponse>>(relations)));
        }

        [HttpPost("AddTag")]
        public async Task<IActionResult> AddTag(TagDto dto)
        {
            var tag = new Tag()
            {
                Keyword = dto.Keyword
            };
            var validation = _tagRepository.GetTag(x => x.Keyword == dto.Keyword);
            if (validation == null) 
            {
                await _tagRepository.AddTag(tag);
                return Ok("Success".SetResponse(200, _mapper.Map<TagResponse>(tag)));
            }
            else
            {
                return Ok("Duplication Error".SetResponse(400, new { }));
            }
        }

        [HttpGet("GetTags")]
        public IActionResult GetTags()
        {
            var tags = _tagRepository.GetTags(x => x.IsDeleted == false);
            
            return Ok("Success".SetResponse(200, _mapper.Map<List<TagResponse>>(tags)));

        }
        [HttpDelete("DeleteTag")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var tag = _tagRepository.GetTag(x => x.Id == id);
            if (tag.IsDeleted == false)
            {
                tag.IsDeleted = true;
                await _tagRepository.UpdateTag(tag);
                return Ok("Success".SetResponse(201, new { }));
            }
            else
            {
                return Ok("Duplication Error".SetResponse(400, new { }));
            }
        }

        [HttpPost("AddProjectToTimeTracker")]
        public async Task<IActionResult> AddProjectToTimeTracker(AddProjectToTimeTrackerDto dto)
        {
            var timetracker = _timeTrackerRepository.GetTimeTracker(x => x.Id == dto.TimeTrackerId, x => x.Project);
            
            
            timetracker.ProjectId = dto.ProjectId;
            await _timeTrackerRepository.UpdateTimeTracker(timetracker);
            return Ok("Success".SetResponse(200, _mapper.Map<TimeTrackerResponse>(timetracker)));
            
        }

       

    }
}
