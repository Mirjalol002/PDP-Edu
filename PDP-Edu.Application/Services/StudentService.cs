using Microsoft.EntityFrameworkCore;
using PDP_Edu.Application.Abstractions;
using PDP_Edu.Application.Models.Student;
using PDP_Edu.Domain.Entities;

namespace PDP_Edu.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IApplicationDbContext _context;
        public StudentService(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(CreateStudentModel entity)
        {
            var student = new Student()
            {
                FullName = entity.FullName,
                BirthDate = entity.BirthDate,
                PhoneNumber = entity.PhoneNumber,
                CreatedDateTime = DateTime.UtcNow
            };
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student != null)
            {
                throw new Exception("Not found");
            }
            _context.Students.Remove(student!);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StudentViewModel>> GetAllAsync()
        {
            return await _context.Students.Select(x => new StudentViewModel()
            {
                Id = x.Id,
                FullName = x.FullName,
                BirthDate = x.BirthDate,
                PhoneNumber = x.PhoneNumber
            }).ToListAsync();
        }

        public async Task<StudentViewModel> GetByIdAsync(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            return new StudentViewModel()
            {
                Id = student!.Id,
                FullName = student.FullName,
                BirthDate = student.BirthDate,
                PhoneNumber = student.PhoneNumber
            };
        }

        public async Task UpdateAsync(UpdateStudentModel entity)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (student != null)
            {
                throw new Exception("Not found");
            }
            student!.FullName = entity.FullName ?? student.FullName;
            student.BirthDate = entity.BirthDate ?? student.BirthDate;
            student.PhoneNumber = entity.FullName ?? student.PhoneNumber;

            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
