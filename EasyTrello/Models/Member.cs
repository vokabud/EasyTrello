namespace EaseTrello.Models
{
    public class Member
    {
        public Member(
            string identifier, 
            string idMember)
        {
            this.Identifier = identifier;
            this.IdMember = idMember;
        }

        public string Identifier { get; }

        public string IdMember { get; }
    }
}
