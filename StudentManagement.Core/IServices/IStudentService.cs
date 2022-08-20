using StudentManagement.Dtos.StudentDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Core.IServices
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentResponseDto>> GetAllStudentsAsync();
        Task<StudentResponseDto> GetStudentByIdAsync(int id);
        Task AddStudentAsync(StudentRequestDto studentRequestDto);
        Task EditStudentAsync(int id, StudentResponseDto studentsEditDto);
        Task DeleteStudentAsync(int id);
    }
}
