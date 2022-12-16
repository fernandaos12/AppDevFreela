using System;

namespace DevFreela.Core.Entities
{
    public class ProjectComment : BaseEntity
    {
        public ProjectComment(string content, int idProjet, int idUser)
        {
            Content = content;
            IdProjet = idProjet;
            IdUser = idUser;
            CreatedAt = DateTime.Now;
        }

        public string Content { get; private set; }
        public int IdProjet { get; private set; }
        public int IdUser { get; private set; }
        public DateTime CreatedAt { get; private set; }
    
    }
}
