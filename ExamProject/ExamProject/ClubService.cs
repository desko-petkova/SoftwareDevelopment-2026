using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject
{
    internal class ClubService
    {
        public Club FindById(int id)
        {
            //foreach (var club in ?collection?)
            //{
            //    if (club.Id == id)
            //    {
            //        return club;
            //    }

            //}

            return null;
        }
        public void AddClub(string name, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Club> GetAllClubs()
        {
            throw new NotImplementedException();
        }

        public void DeleteClub(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Club> GetClubsByDate(DateOnly date)
        {
            throw new NotImplementedException();
        }
    }

    internal class Club
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly Date { get; set; }

        public Club() { }

        public Club(int id, string name, DateOnly date)
        {
            Id = id; Name = name; Date = date;
        }
    }
}
