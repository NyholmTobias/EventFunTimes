using EventFunTimesAPI.Data;
using EventFunTimesAPI.Models;
using EventFunTimesAPI.Services.Interfaces;

namespace EventFunTimesAPI.Services
{
    public class OpeninghoursService : IOpeninghoursService
    {
        private readonly new ApplicationDbContext _db;

        public OpeninghoursService(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateOpeningHours(List<OpeningHours> newOpeninghour)
        {
            try
            {
                foreach (var oh in newOpeninghour)
                {
                    _db.OpeningHours.Add(oh);
                }
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateOpeningHours(List<OpeningHours> openinghoursToUpdate)
        {
            try
            {
                foreach (var oh in openinghoursToUpdate)
                {
                    _db.OpeningHours.Update(oh);
                }
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
