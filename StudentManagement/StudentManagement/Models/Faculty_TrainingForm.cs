//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentManagement.Models
{
    using StudentManagement.ViewModels;
    using System;
    using System.Collections.Generic;
    
    public partial class Faculty_TrainingForm : BaseViewModel
    {
        private System.Guid _id { get; set; }
        public System.Guid Id { get => _id; set { _id = value; OnPropertyChanged(); } }
        private System.Guid _idTrainingForm { get; set; }
        public System.Guid IdTrainingForm { get => _idTrainingForm; set { _idTrainingForm = value; OnPropertyChanged(); } }
        private System.Guid _idFaculty { get; set; }
        public System.Guid IdFaculty { get => _idFaculty; set { _idFaculty = value; OnPropertyChanged(); } }
        private Nullable<bool> _isDeleted { get; set; }
        public Nullable<bool> IsDeleted { get => _isDeleted; set { _isDeleted = value; OnPropertyChanged(); } }
    
        public virtual Faculty Faculty { get; set; }
        public virtual TrainingForm TrainingForm { get; set; }
    }
}
