using ClubsCore.Paging;
using System;

namespace ClubsCore.Parameters
{
    public class StudentParameters : QueryParameters
    {
        public uint MinYearOfBirth { get; set; }
        public uint MaxYearOfBirth { get; set; } = (uint)DateTime.Now.Year;
        public bool IsValidYearRange => MaxYearOfBirth > MinYearOfBirth;
    }
}