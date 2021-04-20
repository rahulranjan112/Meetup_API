using Meetup_API.DataAccess;
using Meetup_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup_API.Services
{
    public class ParticipantsService
    {
        const int recordsPerPage = 2;

        public Participant GetParticipant(int ID)
        {
            using (var context = new MeetupAPIDBContext())
            {
                return context.Participants.Find(ID);
            }
        }

        public List<Participant> GetParticipants(string Name, string Locality, int pages)
        {
            using (var context = new MeetupAPIDBContext())
            {
                if(Name == "" && Locality == "")
                {
                    return context.Participants.OrderBy(p => p.ID).Skip((pages - 1) * recordsPerPage).Take(pages * recordsPerPage).ToList();
                }
                else if(Name == "")
                {
                    return context.Participants.Where(p => p.Locality.Contains(Locality)).OrderBy(p => p.ID).Skip((pages - 1) * recordsPerPage).Take(pages * recordsPerPage).ToList();
                }
                else if (Locality == "")
                {
                    return context.Participants.Where(p => p.Name.Contains(Name)).OrderBy(p => p.ID).Skip((pages - 1) * recordsPerPage).Take(pages * recordsPerPage).ToList();
                }
                else
                {
                    return context.Participants.Where(p => p.Name.Contains(Name) && p.Locality.Contains(Locality)).OrderBy(p => p.ID).Skip((pages - 1) * recordsPerPage).Take(pages * recordsPerPage).ToList();
                }
            }
        }

        public List<Participant> GetParticipants()
        {
            using (var context = new MeetupAPIDBContext())
            {
                return context.Participants.ToList();
            }
        }

        public void SaveParticipant(Participant participant)
        {
            using (var context = new MeetupAPIDBContext())
            {
                context.Participants.Add(participant);
                context.SaveChanges();
            }
        }

        public void UpdateParticipant(Participant participant)
        {
            using (var context = new MeetupAPIDBContext())
            {
                context.Entry(participant).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteParticipant(int ID)
        {
            using (var context = new MeetupAPIDBContext())
            {              
                var participant = context.Participants.Find(ID);

                context.Participants.Remove(participant);
                context.SaveChanges();
            }
        }
    }
}
