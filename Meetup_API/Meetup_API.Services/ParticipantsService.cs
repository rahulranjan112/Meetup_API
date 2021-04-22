using Meetup_API.DataAccess;
using Meetup_API.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Meetup_API.Services
{
    public class ParticipantsService
    {
        const int recordsPerPage = 2;
        private MeetupAPIDBContext context;
        public ParticipantsService() {
            context = new MeetupAPIDBContext();
        }
        public ParticipantsService(MeetupAPIDBContext context)
        {
            this.context = context;
        }

        public Participant GetParticipant(int ID)
        {
            using (context)
            {
                return context.Participants.Find(ID);
            }
        }

        public List<Participant> GetParticipants(string Name, string Locality, int pages)
        {
            using (context)
            {               
                return context.Participants.Where(p => p.Name.Contains(Name) && p.Locality.Contains(Locality)).OrderBy(p => p.ID).Skip((pages - 1) * recordsPerPage).Take(pages * recordsPerPage).ToList();                
            }
        }

        public List<Participant> GetParticipants()
        {
            using (context)
            {
                return context.Participants.ToList();
            }
        }

        public void SaveParticipant(Participant participant)
        {
            using (context)
            {
                context.Participants.Add(participant);
                context.SaveChanges();
            }
        }

        public void UpdateParticipant(Participant participant)
        {
            using (context)
            {
                context.Entry(participant).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteParticipant(int ID)
        {
            using (context)
            {              
                var participant = context.Participants.Find(ID);

                context.Participants.Remove(participant);
                context.SaveChanges();
            }
        }
    }
}
