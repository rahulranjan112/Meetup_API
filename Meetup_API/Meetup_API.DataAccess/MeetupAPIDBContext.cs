using Meetup_API.Entities;
using MySql.Data.EntityFramework;
using System;
using System.Data.Entity;

namespace Meetup_API.DataAccess
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MeetupAPIDBContext : DbContext, IDisposable
    {
        
        public MeetupAPIDBContext() : base("MeetupAPIConnection") //Connection string name write here  
    { }

        public DbSet<Participant> Participants { get; set; }

    }
}
