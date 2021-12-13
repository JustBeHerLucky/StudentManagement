﻿using StudentManagement.Models;
using StudentManagement.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Objects
{
    public class CourseItem : Models.SubjectClass
    {
        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set 
            { 
                _isSelected = value; 
                OnPropertyChanged(); 
                if (value)
                {
                    _isSelected = !IsConflict;
                }
            }
        }
        private bool _isConflict;
        public bool IsConflict
        {
            get => _isConflict;
            set { _isConflict = value; OnPropertyChanged(); }
        }

        private Teacher _mainTeacher;
        public Teacher MainTeacher { get => _mainTeacher; set { _mainTeacher = value; OnPropertyChanged(); } }

        public CourseItem(Models.SubjectClass a, bool isSelected, bool isConflict = false)
        {
            this.Id = a.Id;
            this.Semester = a.Semester;
            this.IdSemester = a.IdSemester;
            this.Subject = a.Subject;
            this.IdSubject = a.IdSubject;
            this.StartDate = a.StartDate;
            this.EndDate = a.EndDate;
            this.Period = a.Period;
            this.WeekDay = a.WeekDay;
            this.Code = a.Code;
            this.TrainingForm = a.TrainingForm;
            this.IdTrainingForm = a.IdTrainingForm;
            this.NumberOfStudents = a.NumberOfStudents;
            this.MaxNumberOfStudents = a.MaxNumberOfStudents;
            this.IdThumbnail = a.IdThumbnail;
            this.DatabaseImageTable = a.DatabaseImageTable;
            this.IsSelected = false;
            this.IsConflict = isConflict;
            this.MainTeacher = this.Teacher_SubjectClass.FirstOrDefault()?.Teacher;
        }
        public SubjectClass ConvertToSubjectClass()
        {
            SubjectClass temp = new SubjectClass()
            {
                Id = this.Id,
                Semester = this.Semester,
                IdSemester = this.IdSemester,
                Subject = this.Subject,
                IdSubject = this.IdSubject,
                StartDate = this.StartDate,
                EndDate = this.EndDate,
                Period = this.Period,
                WeekDay = this.WeekDay,
                Code = this.Code,
                TrainingForm = this.TrainingForm,
                IdTrainingForm = this.IdTrainingForm,
                NumberOfStudents = this.NumberOfStudents,
                MaxNumberOfStudents = this.MaxNumberOfStudents,
                IdThumbnail = this.IdThumbnail,
                DatabaseImageTable = this.DatabaseImageTable,
            };
            return temp;
        }

        public static ObservableCollection<CourseItem> ConvertToListCourseItem(ObservableCollection<SubjectClass> listSubjectClass)
        {
            ObservableCollection<CourseItem> result = new ObservableCollection<CourseItem>();
            foreach(SubjectClass subjectClass in listSubjectClass)
            {
                result.Add(new CourseItem(subjectClass, false));
            }
            return result;
        }
        public static ObservableCollection<SubjectClass> ConvertToListSubjectClass(ObservableCollection<CourseItem> listCourseItem)
        {
            ObservableCollection<SubjectClass> result = new ObservableCollection<SubjectClass>();
            foreach (CourseItem course in listCourseItem)
            {
                result.Add(course.ConvertToSubjectClass());
            }
            return result;
        }
        public static bool IsConflictCourseRegistry(ObservableCollection<CourseItem> listCourse, CourseItem course)
        {
            foreach (CourseItem listElement in listCourse)
            {
                if (course.WeekDay == listElement.WeekDay)
                {
                    foreach (char period in listElement.Period)
                    {
                        if (course.Period.Contains(period))
                            return true;
                    }
                }
            }
            return false;
        }

        public bool IsEqualProperty(SubjectClass a)
        {
            return
            this.Semester == a.Semester &&
            this.Subject == a.Subject &&
            this.StartDate == a.StartDate &&
            this.EndDate == a.EndDate &&
            this.Period == a.Period &&
            this.WeekDay == a.WeekDay &&
            this.Code == a.Code &&
            this.TrainingForm == a.TrainingForm &&
            this.MaxNumberOfStudents == a.MaxNumberOfStudents &&
            this.IdThumbnail == a.IdThumbnail &&
            this.DatabaseImageTable == a.DatabaseImageTable;
        }
    }
}
