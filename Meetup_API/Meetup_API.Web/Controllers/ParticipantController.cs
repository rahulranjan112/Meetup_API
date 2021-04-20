using Meetup_API.Entities;
using Meetup_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Meetup_API.Web.Controllers
{
    public class ParticipantController : ApiController
    {
        ParticipantsService participantService = new ParticipantsService();
        // GET: api/Participant
        //public IEnumerable<Participant> Get()
        //{
        //    var particpants = participantService.GetParticipants();          
        //    return particpants;
        //}

        // GET: api/Participant
        public IEnumerable<Participant> Get(string Name = "", string Locality = "", int PageNo=1)
        {
            var particpants = participantService.GetParticipants(Name, Locality, PageNo);
            return particpants;
        }

        // POST: api/Participant
        public string Post(Participant participant)
        {
           participantService.SaveParticipant(participant);
           return "Paticipant Added";
        }

        // PUT: api/Participant/5
        public string Put(int id, Participant participant)
        {
            if (id != participant.ID) return "Invalid ID";

            participantService.UpdateParticipant(participant);
            return "Participant updated";
        }

        // DELETE: api/Participant/5
        public void Delete(int id)
        {
        }
    }
}
