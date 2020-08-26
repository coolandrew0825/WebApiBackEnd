using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TextEmAllBackEndChallenge.Models;
using TextEmAllBackEndChallenge.Repositories;
using TextEmAllBackEndChallenge.Services;

namespace TextEmAllBackEndChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IStudentService _studentService;
        private readonly ICourseRepository _courseRepository;
        
        public StudentController(IPersonRepository personRepository, IStudentService studentService, ICourseRepository courseRepository)
        {
            _personRepository = personRepository;
            _studentService = studentService;
            _courseRepository = courseRepository;
        }

        /// <summary>
        /// Challenge 1
        /// creating a student's transcript
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>
        /// JSON format of transcript object
        /// </returns>
        [HttpGet("{studentId}/transcript")]
        public ActionResult<Transcript> GetTranscriptByStudentId(int studentId)
        {
            // make a call to database to check if the person record is there
            Person person = _personRepository.GetPersonById(studentId);

            if (person != null)
            {
                // starts creating the JSON response
                var transcript = _studentService.GetTranscriptByStudentId(person, studentId);
                
                return Ok(transcript);
            }
            else
            {
                // returns HTTP status code 404 when there is no person found in the database
                return NotFound();
            }
        }

        /// <summary>
        /// Challenge 2
        /// Get GPAs of all students
        /// </summary>
        /// <returns>
        /// JSON format of a list of GPA
        /// </returns>
        [HttpGet("students")]
        public ActionResult<List<StudentGpa>> GetGpas()
        {
            // getting a list of GPA of all students
            List<StudentGpa> gpaList = _studentService.GetAllGpas();

            return gpaList;
        }

        /// <summary>
        /// Challenge 4
        /// insert grade to student grade table
        /// </summary>
        /// <param name="grade"></param>
        /// <returns>
        /// a returning grade object
        /// </returns>
        [HttpPost("grades")]
        public ActionResult<ReturningGrade> InsertGrade([FromBody] InsertingGrade grade)
        {
            Person person = _personRepository.GetPersonById(grade.StudentId);
            Course course = _courseRepository.GetCourseByCourseId(grade.CourseId);

            if (person == null)
            {
                // no person record in the database
                return BadRequest(String.Format("{0} is not a valid person id.", grade.StudentId.ToString()));
            }
            else if (course == null)
            {
                // not course record in the database
                return BadRequest(String.Format("{0} is not a valid course id.", grade.CourseId.ToString()));
            }
            else
            {
                if (person.Discriminator.ToLower().Equals("student"))
                {
                    var combinationExists = _studentService.IsStudentCourseCombinationExists(grade);
                    
                    if (!combinationExists)
                    {
                        // makes a call to create a row in database
                        var result = _studentService.InsertStudentGrade(grade);

                        // returns a failure message when insertion fails
                        if (result == null)
                        {
                            return BadRequest("The application fails to create a record in database.");
                        }

                        return result;
                    }

                    return BadRequest("The student and course combination is already in the database.");
                }
                else
                {
                    // reutrns a message when the person record is not a student
                    return BadRequest(String.Format("{0} is not a valid student id.", grade.StudentId.ToString()));
                }
            }
        }
    }
}