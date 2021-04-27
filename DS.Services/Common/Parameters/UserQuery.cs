using System;
namespace DS.Services.Common.Parameters
{
    public class UserQuery : BaseQuery
    {
        public string ShortName { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }

        public UserQuery()
        {
            this.StartAt = DateTime.MaxValue;
            this.EndAt = DateTime.MaxValue;
        }
    }
}