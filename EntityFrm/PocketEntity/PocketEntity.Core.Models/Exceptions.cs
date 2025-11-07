using System;

namespace PocketEntity.Core.Models
{
    public partial class Exceptions
    {
        public long Id { get; set; }
        public System.Guid GUID { get; set; }
        public string ApplicationName { get; set; }
        public string MachineName { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string Type { get; set; }
        public bool IsProtected { get; set; }
        public string Host { get; set; }
        public string Url { get; set; }
        public string HTTPMethod { get; set; }
        public string IPAddress { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
        public Nullable<int> StatusCode { get; set; }
        public string SQL { get; set; }
        public Nullable<System.DateTime> DeletionDate { get; set; }
        public string FullJson { get; set; }
        public Nullable<int> ErrorHash { get; set; }
        public int DuplicateCount { get; set; }
    }
}