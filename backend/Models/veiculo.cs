namespace TesteBenner.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public DateTime? HoraEntra { get; set; } 

        public DateTime? HoraSaida { get; set; }

        public int? valorTotal { get; set; }

        public TimeSpan? tempo { get; set; }

    }
}

