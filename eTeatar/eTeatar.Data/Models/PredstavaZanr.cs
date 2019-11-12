namespace eTeatar.Data.Models
{
    public class PredstavaZanr : IIsDeleted
    {
        public int PredstavaId { get; set; }
        public virtual Predstava Predstava { get; set; }

        public int ZanrId { get; set; }
        public virtual Zanr Zanr { get; set; }
        public bool IsDeleted { get; set; }
    }
}
