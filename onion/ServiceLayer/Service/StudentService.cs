using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer;
using DomainLayer.Models;
using RepositoryLayer.Repository;
using ServiceLayer.DTO;

namespace ServiceLayer.Service
{
    public class StudentService: ICustomService<StudentDTO>
    {
        readonly IRepository<Student> studentRepository;
        readonly IMapper mapper;

        public StudentService(IRepository<Student> students, IMapper mapper)
        {
            this.studentRepository = students;
            this.mapper = mapper;
        }


        public void Delete(StudentDTO entity)
        {
            try
            {
                if (entity != null)
                {
                    Student st = mapper.Map<Student>(entity);
                    studentRepository.Delete(st);
                    studentRepository.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public StudentDTO Get(int id)
        {
            try
            {
                var student = studentRepository.Get(id);
                var dto = mapper.Map<StudentDTO>(student);
                if (dto != null)
                {
                    return dto;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public IEnumerable<StudentDTO> GetAll()
        {
            try
            {
                var students = studentRepository.GetAll().Select(s => mapper.Map<StudentDTO>(s));
                if (students != null)
                {
                    return students;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public void Insert(StudentDTO entity)
        {
            try
            {
                if (entity != null)
                {
                    Student student = mapper.Map<Student>(entity);
                    studentRepository.Insert(student);
                    studentRepository.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public void Update(StudentDTO entity)
        {
            try
            {
                if (entity != null)
                {
                    Student student = mapper.Map<Student>(entity);
                    studentRepository.Update(student);
                    studentRepository.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public IEnumerable<Student> FindAll() {
            try
            {
                var students = studentRepository.GetAll();
                if(students != null)
                {
                    return students;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) { 
                throw new Exception();
            }
        }

        public void Remove(StudentDTO entity)
        {
            try
            {
                if (entity != null)
                {
                    Student s = mapper.Map<Student>(entity);
                    studentRepository.Remove(s);
                    studentRepository.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
