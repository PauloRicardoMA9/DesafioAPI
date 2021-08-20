namespace ma9.Business.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public Sexo Sexo { get; set; }
        public Contato Contato { get; set; }
    }
}
