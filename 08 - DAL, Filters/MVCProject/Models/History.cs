namespace MVCProject.Models
{
    public class History
    {
        public int Id { get; set; }

        public string EntityName { get; set; }

        public string Operation { get; set; }

        public DateTime OperationDate { get; set; }
    }
}
