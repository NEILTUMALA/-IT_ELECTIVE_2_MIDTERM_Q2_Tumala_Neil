using GymAttendanceSystem.Models;

namespace GymAttendanceSystem.Repositories
{
    public interface IMemberVisitRepository
    {
        IEnumerable<MemberVisit> GetAll();
        MemberVisit? GetById(int id);
        void Add(MemberVisit visit);
        void Update(MemberVisit visit);
        void CheckOut(int id);
        IEnumerable<MemberVisit> Search(string query);
    }

    public class MemberVisitRepository : IMemberVisitRepository
    {
        private static readonly List<MemberVisit> _visits = new();
        private static int _nextId = 1;

        public IEnumerable<MemberVisit> GetAll() => _visits.OrderByDescending(v => v.TimeIn);

        public MemberVisit? GetById(int id) => _visits.FirstOrDefault(v => v.Id == id);

        public void Add(MemberVisit visit)
        {
            visit.Id = _nextId++;
            visit.Status = "Inside Gym"; 
            _visits.Add(visit);
        }

        public void Update(MemberVisit visit)
        {
            var existing = GetById(visit.Id);
            if (existing != null)
            {
                existing.VisitNumber = visit.VisitNumber;
                existing.MemberId = visit.MemberId;
                existing.FirstName = visit.FirstName;
                existing.LastName = visit.LastName;
                existing.MembershipType = visit.MembershipType;
                existing.ContactNumber = visit.ContactNumber;
                existing.WorkoutPurpose = visit.WorkoutPurpose;
                existing.Notes = visit.Notes;
            }
        }

        public void CheckOut(int id)
        {
            var visit = GetById(id);
            if (visit != null)
            {
                visit.TimeOut = DateTime.Now;
                visit.Status = "Checked Out"; 
            }
        }

        public IEnumerable<MemberVisit> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return GetAll();

            return _visits.Where(v =>
                v.MemberId.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                v.FirstName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                v.LastName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                v.VisitNumber.Contains(query, StringComparison.OrdinalIgnoreCase)
            );
        }
    }
}