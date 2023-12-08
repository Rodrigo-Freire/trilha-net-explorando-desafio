namespace DesafioProjetoHospedagem.Models
	{
	public class Reserva
		{
		private List<Pessoa> _hospedes;
		public List<Pessoa> Hospedes
			{
			get => _hospedes;
			set => _hospedes = value ?? throw new ArgumentNullException(nameof(value), "A lista de hospedes não pode ser nula");
			}
		public Suite Suite { get; set; }
		public int DiasReservados { get; set; }

		public Reserva() { }

		public Reserva(int diasReservados)
			{
			DiasReservados = diasReservados;
			}

		public void CadastrarHospedes(List<Pessoa> hospedes)
			{
			if (hospedes == null) throw new ArgumentNullException(nameof(hospedes), "A lista de hospedes não pode ser nula");

			bool capacidadeHospedes = ValidarCapacidade(hospedes);

			if (capacidadeHospedes) Hospedes = hospedes;
			else throw new Exception($"Capacidade hospedes para a '{Suite.TipoSuite}' foi excedida, selecione uma suíte diferente ou diminua a quantidade de hóspedes.");
			}

		public void CadastrarSuite(Suite suite)
			{
			Suite = suite;
			}

		public int ObterQuantidadeHospedes()
			{
			return Hospedes.Count();
			}

		public decimal CalcularValorDiaria()
			{
			decimal valor = 0;
			decimal calculoValor = DiasReservados * Suite.ValorDiaria;

			if (DiasReservados >= 10) valor = calculoValor * 0.9m;
			else valor = calculoValor;
			return valor;
			}

		public bool ValidarCapacidade(List<Pessoa> hospedes)
			{
			if (hospedes.Count <= Suite.Capacidade) return true;
			return false;
			}
		}
	}