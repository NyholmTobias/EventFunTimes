using EventFunTimesAPI.Models;

namespace EventFunTimesAPI.Services.Interfaces
{
    public interface IOpeninghoursService
    {
        bool UpdateOpeningHours(List<OpeningHours> openinghoursToUpdate);
        bool CreateOpeningHours(List<OpeningHours> newOpeninghour);
    }
}
