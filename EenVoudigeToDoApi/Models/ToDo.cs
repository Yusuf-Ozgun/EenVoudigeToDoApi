using Microsoft.AspNetCore.Http;

namespace EenVoudigeToDoApi.Models
{
    public class ToDo
    {
        #region Properties
        public int Id { get; set; }
        public string Titel { get; set; }
        public DateTime Creatie { get; set; }
        public DateTime LaatsteAanpassing { get; set; }
        public DateTime VervalDatum { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        #endregion

        #region Ctor
        public ToDo(int id, string titel, DateTime creatie, DateTime laatsteAanpassing, DateTime vervalDatum)
        {
            Id = id;
            Titel = titel;
            Creatie = creatie;
            LaatsteAanpassing = laatsteAanpassing;
            VervalDatum = vervalDatum;
        }
        #endregion
    }
}
