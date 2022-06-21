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
        #endregion

        #region Ctor
        public ToDo(int id, string titel, DateTime creatie, DateTime laatsteAanpassing)
        {
            Id = id;
            Titel = titel;
            Creatie = creatie;
            LaatsteAanpassing = laatsteAanpassing;
        }
        #endregion
    }
}
