using AutoMapper;
using StudentManagement.Core.IServices;
using StudentManagement.Data.IRepositories;
using StudentManagement.Dtos.StudentDtos;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task AddStudentAsync(StudentRequestDto studentRequestDto)
        {
            var student = _mapper.Map<Student>(studentRequestDto);
            student.CreatedDate = DateTime.Now;
            student.LastUpdatedDate = DateTime.Now;
            try
            {
                await _studentRepository.AddStudentAsync(student);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<IEnumerable<StudentResponseDto>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            return _mapper.Map<IEnumerable<StudentResponseDto>>(students);
        }

        public async Task<StudentResponseDto> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if(student == null)
            {
                throw new ArgumentException(nameof(student));
            }
            return _mapper.Map<StudentResponseDto>(student);
        }

        public async Task EditStudentAsync(int id, StudentResponseDto studentsEditDto)
        {
            var student = await _studentRepository.GetStudentByIdAsync(studentsEditDto.Id);
            student.FirstName = studentsEditDto.FirstName;
            student.LastName = studentsEditDto.LastName;
            student.Email = studentsEditDto.Email;  
            student.CreatedDate = student.CreatedDate;
            student.LastUpdatedDate = studentsEditDto.LastUpdatedDate;  
            try
            {
                await _studentRepository.EditStudentAsync(student);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteStudentAsync(int id)
        {
            try
            {
                await _studentRepository.DeleteStudentAsync(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
