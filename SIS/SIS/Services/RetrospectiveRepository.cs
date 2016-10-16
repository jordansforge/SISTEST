using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.Models;

namespace SIS.Services
{
    //static class to be referenced anywhere, bad for threading but not an issue here.
    // the repository means we can point it to whatever data source we want later
    // also need to check for primary keys to make sure it doesnt already exist if it shouldnt
    public static class RetrospectiveRepository
    {
        public static List<Retrospective> GetAll
        {
            get { return all; }
            set { all = value; }
        }

        private static List<Retrospective> all = new List<Retrospective>();

        // using a string for now but should be datetime and more intelligent
        public static List<Retrospective> GetByDate(string date)
        {
            List<Retrospective> result = null;
            try
            { 
                result = all.FindAll(dt => dt.Date == date);
            }
            catch (Exception ex)
            {
                //log exception to elmah
            }
            return result;
        }

        //should really return success/fail for it to be acted upon and check inputs validity
        // id probably standardise the fuction naming if we had multiple repositories
        public static void Add(Retrospective retro)
        {
            try {
                all.Add(retro);
            }
            catch (Exception ex)
            {
                //log exception to elmah
            }
            return;
        }

        // we should also be trimming values, especially keys
        public static void Delete(string Name)
        {
            try { 
                // a bit long winded
                Retrospective retro = all.FirstOrDefault(dt => dt.Name == Name);

                if (retro != null)
                {
                    bool result = all.Remove(retro);
                }
            }
            catch (Exception ex)
            {
                //log exception to elmah
            }
        }

        public static void AddFeedback(string Name, FeedbackItem feedback)
        {
            try
            {
                Retrospective retro = all.FirstOrDefault(dt => dt.Name == Name);

                if (retro != null)
                {
                    // quick fix for now, should be in the object create
                    if (retro.Feedback == null)
                    {
                        retro.Feedback = new List<Models.FeedbackItem>();
                    }
                    retro.Feedback.Add(feedback);
                }
            }
            catch(Exception ex)
            {
                //log exception to elmah
            }
        }

        //needs improved checking
        public static Retrospective CreateRetro(string name, string summary, string date, List<string> participants)
        {
            Retrospective result = new Retrospective();
            
            result.Name = name ?? String.Empty;
            result.Summary = summary ?? String.Empty;
            result.Date = date ?? String.Empty;
            result.Participants = participants;
      
            return result;
        }
}           
}
