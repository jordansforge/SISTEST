using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SIS.Services;

namespace SIS.Controllers
{
    //This code is brittle, it needs consistent error checking
    public class RetrospectiveController : ApiController
    {
        public List<Models.Retrospective> Get()
        {
            //setTestData(); //uncomment to add soem test data
            return RetrospectiveRepository.GetAll;
        }

        public List<Models.Retrospective> Get(string Date)
        {
            //check input
            return RetrospectiveRepository.GetByDate(Date);
        }

        public void Post(Newtonsoft.Json.Linq.JObject data)
        {
            Models.Retrospective retro = new Models.Retrospective();

                retro.Name = data["params"]["Name"].ToString();
                retro.Summary = data["params"]["Summary"].ToString();
                retro.Date = data["params"]["Date"].ToString();
                retro.Participants = new List<string>(); // put this in the model create 
                retro.Feedback = new List<Models.FeedbackItem>(); // put this in the model create
                foreach (var participant in data["params"]["Participants"].Children())
                {
                    var Participant = participant["text"].ToString();
                    retro.Participants.Add(Participant);
                }
          
            // check input
            RetrospectiveRepository.Add(retro);
        }

        public void Put(Newtonsoft.Json.Linq.JObject data)
        {
            Models.FeedbackItem feedback = new Models.FeedbackItem();
            string name = data["params"]["RetroName"].ToString();
            feedback.Name = data["params"]["Name"].ToString();
            feedback.Body = data["params"]["Body"].ToString();
            feedback.Type = data["params"]["FeedbackType"].ToString();

            //checkinput
            RetrospectiveRepository.AddFeedback(name,feedback);
        }

        // used here for debug,makes multiple copies if used over
        private void setTestData()
        {
            Models.Retrospective rttest = new Models.Retrospective();
            rttest.Name = "Retrospective1";
            rttest.Summary = "PostRelease retrospective";
            rttest.Date = "27/07/2016";
            rttest.Participants = new List<string> { "Viktor", "Gareth", "Mike" };
            RetrospectiveRepository.Add(rttest);

            Models.Retrospective rttest2 = new Models.Retrospective();
            rttest2.Name = "Retrospective2";
            rttest2.Summary = "PostRelease retrospective2";
            rttest2.Date = "29/08/2016";
            rttest2.Participants = new List<string> { "Viktor", "Gareth", "Mike" };
            RetrospectiveRepository.Add(rttest2);

            Models.Retrospective rttest3 = new Models.Retrospective();
            rttest3.Name = "Retrospective3";
            rttest3.Summary = "PostRelease retrospective3";
            rttest3.Date = "30/08/2016";
            rttest3.Participants = new List<string> { "Viktor", "Gareth", "Mike" };
            RetrospectiveRepository.Add(rttest3);
        }

   

    }
}
