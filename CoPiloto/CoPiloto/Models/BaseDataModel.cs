using SQLite;

namespace CoPiloto.Models
{
    public class BaseDataModel : IBusinessEntity
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
    }
}
