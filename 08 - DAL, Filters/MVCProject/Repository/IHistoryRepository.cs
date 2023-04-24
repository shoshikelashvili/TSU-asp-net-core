using MVCProject.Models;

namespace MVCProject.Repository
{
    public interface IHistoryRepository
    {
        public void AddNewRecord(History record);
    }
}
